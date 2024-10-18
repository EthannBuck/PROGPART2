using Microsoft.AspNetCore.Mvc;
using PROGPART1.Models;
using System.Collections.Generic;
using System.IO;

namespace PROGPART1.Controllers
{
    public class ClaimController : Controller
    {
        private static List<Claim> claims = new List<Claim>();
        private static int claimCounter = 1; 

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim, IFormFile SupportingDocument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (SupportingDocument != null && SupportingDocument.Length > 0)
                    {
                        var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                        if (!Directory.Exists(uploadsDir))
                        {
                            Directory.CreateDirectory(uploadsDir);
                        }

                        var filePath = Path.Combine(uploadsDir, SupportingDocument.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            SupportingDocument.CopyTo(stream);
                        }

                        claim.SupportingDocumentPath = "uploads/" + SupportingDocument.FileName;
                    }

                    claim.ClaimId = claimCounter++;
                    claims.Add(claim);
                    return RedirectToAction("Success");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while submitting the claim: " + ex.Message);
            }

            return View(claim);
        }

        public IActionResult ViewClaims()
        {
            return View(claims);
        }

        public IActionResult VerifyClaims()
        {
            var pendingClaims = claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        [HttpPost]
        public IActionResult ApproveClaim(int claimId)
        {
            var claim = claims.FirstOrDefault(c => c.ClaimId == claimId);
            if (claim != null)
            {
                claim.Status = "Approved";
                claim.UpdatedAt = DateTime.Now;
            }

            return RedirectToAction("VerifyClaims");
        }

        [HttpPost]
        public IActionResult RejectClaim(int claimId)
        {
            var claim = claims.FirstOrDefault(c => c.ClaimId == claimId);
            if (claim != null)
            {
                claim.Status = "Rejected";
                claim.UpdatedAt = DateTime.Now;
            }

            return RedirectToAction("VerifyClaims");
        }
    }
}
