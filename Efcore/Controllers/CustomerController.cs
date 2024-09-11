
namespace Efcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [ProducesResponseType(typeof(CustomerResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(uint id)
        {
            try
            {
                var result = await _customerService.GetAsync(id);

                return Ok(result);

            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateAsync(CustomerCreateRequest customer)
        {
            return Ok(customer);
        }
    }
}
