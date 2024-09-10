
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
        public async Task<IActionResult> CreateAsync(CustomerEntity customer)
        {
            try
            {
                var result = await _customerService.CreateAsync(customer);

                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
