
namespace Efcore.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpPost]
    [ProducesResponseType(typeof(uint), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(OrderCreateRequest order)
    {
        var result = await _orderService.CreateAsync(order);

        return Ok(result);
    }

    [HttpDelete("{id:int:min(1)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteById (uint id)
    {
        await _orderService.DeleteAsync(id);

        return NoContent();
    }

    [HttpGet("{id:int:min(1)}")]
    [ProducesResponseType(typeof(OrderGetByIdResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] uint id)
    {
        var result = await _orderService.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateAsync(OrderUpdateRequest order)
    {
        _orderService.UpdateAsync(order);

        return NoContent();
    }
}
