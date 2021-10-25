using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace HousingManagementSystemApi.Controllers
{
    using UseCases;

    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IRetrieveAddressesUseCase retrieveAddressesUseCase;

        public AddressController(IRetrieveAddressesUseCase retrieveAddressesUseCase)
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
