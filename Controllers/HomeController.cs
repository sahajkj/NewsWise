using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewsWise.Models;
using Newtonsoft.Json;

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
            if (!searchString.IsNullOrEmpty())
            {
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
            }
            if (match != null)
            {
                return RedirectToAction("Details", "ClaimReviews", new { id = match.ClaimReviewId });
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

        [HttpPost]
        public async Task<IActionResult> SubmitQuizAsync()
        {
            var score = 0;
            var chosenOption = new List<string>();
            // Check answer for Question 1
            var q1Answer = Request.Form["One"];
            chosenOption.Add(q1Answer);
            if (q1Answer == "B")
            {
                score += 1;
            }

            // Check answer for Question 2
            var q2Answer = Request.Form["Two"];
            chosenOption.Add(q2Answer);
            if (q2Answer == "B")
            {
                score += 1;
            }
            var q3Answer = Request.Form["Three"];
            chosenOption.Add(q3Answer);
            if (q3Answer == "C")
            {
                score += 1;
            }
            // Display result
            var q4Answer = Request.Form["Four"];
            chosenOption.Add(q4Answer);
            if (q4Answer == "B")
            {
                score += 1;
            }
            var q5Answer = Request.Form["Five"];
            chosenOption.Add(q5Answer);
            if (q5Answer == "B")
            {
                score += 1;
            }
            var q6Answer = Request.Form["Six"];
            chosenOption.Add(q6Answer);
            if (q6Answer == "B")
            {
                score += 1;
            }
            var q7Answer = Request.Form["Seven"];
            chosenOption.Add(q7Answer);
            if (q7Answer == "A")
            {
                score += 1;
            }
            var q8Answer = Request.Form["Eight"];
            chosenOption.Add(q8Answer);
            if (q8Answer == "A")
            {
                score += 1;
            }
            var answerList = new List<int>();
            foreach (string answer in chosenOption)
            {
                switch (answer)
                {
                    case "A":
                        answerList.Add(0);
                        break;
                    case "B":
                        answerList.Add(1);
                        break;
                    case "C":
                        answerList.Add(2);
                        break;
                }
            }
            // Prepare quiz data to send to Flask API
            var quizData = new
            {
                q1 = "MC1",
                q2 = "MC3",
                q3 = "MC6",
                q4 = "MC8",
                q5 = "MC5",
                q6 = "A1",
                q7 = "A2",
                q8 = "A3",
                a1 = answerList[0],
                a2 = answerList[1],
                a3 = answerList[2],
                a4 = answerList[3],
                a5 = answerList[4],
                a6 = answerList[5],
                a7 = answerList[6],
                a8 = answerList[7]
            };

            // Send quiz data to Flask API and receive feedback
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://newswiseapi.azurewebsites.net/quiz_feedback", quizData);
            var feedbackJson = await response.Content.ReadAsStringAsync();
            var feedback = JsonConvert.DeserializeObject<dynamic>(feedbackJson);
            string SuggestedPage = feedback["Suggested Page"];
            string quizFeedback = feedback["Feedback"];
            switch (SuggestedPage)
            {
                case "The definition of fake news":
                    SuggestedPage = "Definition";
                    break;
                case "The existence of fake news":
                    SuggestedPage = "Existence";
                    break;
                case "The importance of identifying fake news":
                    SuggestedPage = "Importance";
                    break;
                case "Tips to spot fake news":
                    SuggestedPage = "SpotTip";
                    break;
                case "Real life examples":
                    SuggestedPage = "RealLifeExamples";
                    break;
            }

            // Display result and feedback
            return View("QuizResults", new { Score = score, Feedback = quizFeedback.Replace("\n", "<br><br>"), SuggestedPage });


            //return View("QuizResults",score);
        }
        public IActionResult QuizContent()
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