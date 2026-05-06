using Gruppe20App.Controllers;
using Gruppe20App.Data;
using Gruppe20App.Models;
using Gruppe20App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Gruppe20App.Tests
{
    public class OrganisasjonerControllerTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Create_AddsOrganisasjonToDatabase()
        {
            using var context = CreateContext();

            var httpClient = new HttpClient();
            var brregService = new BrregService(httpClient);

            var controller = new OrganisasjonerController(context, brregService);

            var organisasjon = new Organisasjon
            {
                Navn = "Test Organisasjon",
                Organisasjonsnummer = "123456789",
                Organisasjonsform = "Testform"
            };

            var result = await controller.Create(organisasjon);

            Assert.IsType<RedirectToActionResult>(result);
            Assert.Single(context.Organisasjoner);
            Assert.Equal("Test Organisasjon", context.Organisasjoner.First().Navn);
        }

        [Fact]
        public async Task Index_ReturnsViewWithOrganisasjoner()
        {
            using var context = CreateContext();

            context.Organisasjoner.Add(new Organisasjon
            {
                Navn = "Test AS",
                Organisasjonsnummer = "987654321",
                Organisasjonsform = "Aksjeselskap"
            });

            await context.SaveChangesAsync();

            var httpClient = new HttpClient();
            var brregService = new BrregService(httpClient);

            var controller = new OrganisasjonerController(context, brregService);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Organisasjon>>(viewResult.Model);

            Assert.Single(model);
        }
    }
}
