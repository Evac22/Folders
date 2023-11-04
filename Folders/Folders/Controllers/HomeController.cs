using System.Diagnostics;
using Folders.Context;
using Folders.Models;
using Microsoft.AspNetCore.Mvc;

namespace Folders.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(int? parentFolderId = null)
    {
        Console.WriteLine("ParentFolderId: " + parentFolderId);

        var directories = _context.Folders
            .Where(d => d.ParentFolderId == parentFolderId)
            .ToList();

        Console.WriteLine("Directories count: " + directories.Count);

        return View(directories);
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