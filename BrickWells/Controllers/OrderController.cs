using BrickWells.Models;
using BrickWells.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrickWells.Controllers;

public class OrderController : Controller
{
    private IOrderRepository repository;
    private Cart cart;
    
    public OrderController(IOrderRepository repo, Cart cartService)
    {
        repository = repo;
        cart = cartService;
    }
    public ViewResult Checkout() => View(new Order());
    
    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (cart.Lines.Count() == 0)
        {
            ModelState.AddModelError("", "Sorry, your cart is empty!");
        }
        if (ModelState.IsValid)
        {
            // order.Amount = cart.Lines.Sum(x => x.Product.Price * x.Quantity);
            repository.SaveOrder(order);
            cart.Clear();
            return RedirectToPage("/Completed", new { orderId = order.TransactionId });
        }
        
        {
            return View(order);
        }
    }
}