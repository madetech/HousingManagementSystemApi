using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace HousingManagementSystemApi.Controllers
{
    using UseCases;

    [ApiController]
    [Route("[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IRetrieveAddressesUseCase retrieveAddressesUseCase;

        public AddressesController(IRetrieveAddressesUseCase retrieveAddressesUseCase)
        {
            this.retrieveAddressesUseCase = retrieveAddressesUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Address([FromQuery] string postcode)
        {
            var result = await retrieveAddressesUseCase.Execute(postcode);
            return Ok(result);
        }
    }
}
