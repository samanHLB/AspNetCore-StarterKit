namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{nameof(Roles.SuperAdmin)}, {nameof(Roles.Admin)}")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
