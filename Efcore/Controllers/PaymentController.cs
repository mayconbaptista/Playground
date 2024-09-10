
namespace Efcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync(PaymentEntity payment)
        {
            var result = await _paymentService.CreateAsync(payment);
            return Ok(result);
        }

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteByIdAsync(uint id)
        {
            _paymentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(uint id)
        {
            var result = await _paymentService.GetAsync(id);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync(PaymentEntity payment)
        {
            var result = await _paymentService.UpdateAsync(payment);
            return Ok(result);
        }
    }
}
