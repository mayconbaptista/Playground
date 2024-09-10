
namespace Efcore.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(OrderEntity order)
    {
        var result = await _orderService.CreateAsync(order);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(OrderEntity order)
    {
        var result = await _orderService.DeleteAsync(order);
        return Ok(result);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetAsync([FromRoute] uint id)
    {
        var result = await _orderService.GetAsync(id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(OrderEntity order)
    {
        var result = await _orderService.UpdateAsync(order);
        return Ok(result);
    }
}
