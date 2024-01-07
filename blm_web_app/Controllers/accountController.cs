using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        try
        {
            // Firebase Authentication ile giriş yapma işlemi
            var user = await FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password);

            // Kullanıcıyı Identity ile oturum açma işlemi
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Uid, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Giriş başarısız
                return View();
            }
        }
        catch (Exception ex)
        {
            // Firebase Authentication hatası
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(string email, string password)
    {
        try
        {
            // Firebase Authentication ile kayıt olma işlemi
            var user = await FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email, password);

            // Kullanıcıyı Identity ile oturum açma işlemi
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Uid, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Kayıt başarısız
                return View();
            }
        }
        catch (Exception ex)
        {
            // Firebase Authentication hatası
            return View();
        }
    }
}
