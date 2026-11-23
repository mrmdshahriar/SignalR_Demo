using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Demo.Models;

namespace SignalR_Demo.Controllers;

public class HomeController : Controller
{
    private readonly IHubContext<NotificationHub> _hub;

    private readonly ILogger<HomeController> _logger;

    public HomeController(IHubContext<NotificationHub> hub, ILogger<HomeController> logger)
    {
        _logger = logger;
        _hub = hub;
    }

    public async Task<IActionResult> SendNotification()
    {
        await _hub.Clients.All.SendAsync(
            "ReceiveMessage",
            "New patient registered!"
        );

        return Content("Notification sent!");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

