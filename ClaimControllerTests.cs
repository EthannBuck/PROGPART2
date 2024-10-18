using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PROGPART1.Controllers;
using PROGPART1.Models;
using Xunit;

namespace PROGPART1.Tests
{
    public class ClaimControllerTests
    {
        [Fact]
        public void SubmitClaim_ValidClaim_RedirectsToSuccess()
        {
            var controller = new ClaimController();
            var claim = new Claim
            {
                Title = "Test Claim",
                HoursWorked = 10,
                HourlyRate = 15,
                Notes = "Test notes"
            };

            var fileMock = new FormFile(new MemoryStream(), 0, 1024, "SupportingDocument", "test.pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            };

            var result = controller.SubmitClaim(claim, fileMock) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Success", result.ActionName);
        }

        [Fact]
        public void SubmitClaim_InvalidClaim_ReturnsViewWithErrors()
        {
            var controller = new ClaimController();
            var claim = new Claim(); // Invalid claim with no data

            var result = controller.SubmitClaim(claim, null) as ViewResult;

            Assert.NotNull(result);
            Assert.False(controller.ModelState.IsValid); // Ensure model state is invalid
        }
    }
}
