using Microsoft.AspNetCore.Mvc;
using blm_web_app.Services;

public class HomeController : Controller
{
    private readonly NewsService _newsService;

    public HomeController(NewsService newsService)
    {
        _newsService = newsService;
    }

    public async Task<IActionResult> Index()
    {
        // API'yi çaðýr ve gelen haberleri al
        var apiUrl = "https://newsapi.org/v2/top-headlines?sources=techcrunch&apiKey=f10459f5324a4fc5b59334dffce68b05";
        var newsList = await _newsService.GetNewsAsync(apiUrl);

        // View'e haberleri geçir
        return View(newsList);
    }
}
