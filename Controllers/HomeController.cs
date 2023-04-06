using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewsWise.Models;

namespace NewsWise.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewswiseDbContext _context;
        public HomeController(NewswiseDbContext context)
        {
            _context = context;
        }
        public IActionResult Landing()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Landing(string password)
        {
            if (password == "ITScamps@FIT5120")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect password. Please try again.";
                return View();
            }
        }
        public IActionResult Definition()
        {
            return View();
        }

        public IActionResult Article1()
        {
            return View();
        }
        public IActionResult Article2()
        {
            return View();
        }

        public IActionResult Article3()
        {
            return View();
        }

        public IActionResult Article4()
        {
            return View();
        }

        public IActionResult Article5()
        {
            return View();
        }

        public IActionResult Article6()
        {
            return View();
        }
        public IActionResult Importance() 
        {   
            return View();
        }

        public IActionResult RealLifeExamples()
        {
            return View();
        }
        public async Task<IActionResult> SearchResult(int? reviewId)
        {
            if (reviewId == null || _context.Review == null)
            {
                return NotFound();
            }

            var claimReview = await _context.Review
                .FirstOrDefaultAsync(m => m.ClaimReviewId == reviewId);
            if (claimReview == null)
            {
                return NotFound();
            }

            return View(claimReview);
        }

        public IActionResult Search(string searchString)
        {
            ClaimReview match = null;
            List<ClaimReview> articles = _context.Review.ToList();
            foreach (var article in articles)
            {
                if (article.Title != null)
                    if (article.Title.ToUpper().Contains(searchString.ToUpper()))
                    {
                        match = article;
                        break;
                    }
            }
            if (match != null)
            {
                return RedirectToAction("Details", "CLaimReviews", new { id = match.ClaimReviewId });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Autofill()
        {
            string prefix = HttpContext.Request.Query["term"].ToString();
            var articleList = _context.Review.Where(i => i.Title.Contains(prefix) || i.Url.Contains(prefix))
                     .Select(i => i.Title).ToList().Take(20);
            return Ok(articleList);
        }
        public IActionResult Existence()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_context.Review.ToList());
        }
        public IActionResult SpotTip()
        {
            return View();
        }
        public IActionResult Education()
        {
            return View();
        }

        public IActionResult NewsSpotter() 
        {
            return View();
        }
        public IActionResult Quiz()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}