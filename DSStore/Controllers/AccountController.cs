using DSStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DSStore.ViewModels;
using NuGet.ProjectModel;

namespace DSStore.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<Usuario> _singInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IWebHostEnvironment _host;


    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<Usuario> singInManager,
        UserManager<Usuario> userManager,
        IWebHostEnvironment host
        )
    {
        _logger = logger;
        _singInManager = singInManager;
        _userManager = userManager;
        _host = host;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUrl ?? Url.Content("~/")
        };
        return View(login);
    }
}