using System.Collections.Generic;
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

        public async Task<IActionResult> Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var match = await _context.Review
                    .FirstOrDefaultAsync(a => a.Title != null && a.Title.ToUpper().Contains(searchString.ToUpper()));

                if (match != null)
                {
                    return RedirectToAction("Details", "ClaimReviews", new { id = match.ClaimReviewId });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Autofill()
        {
            string prefix = HttpContext.Request.Query["term"].ToString();
            var articleList = _context.Review.Where(i => i.Title.Contains(prefix))
                     .Select(i => i.Title).Take(10).ToList();
            return Ok(articleList);
        }
        public IActionResult Existence()
        {
            return View();
        }
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var records = _context.Review
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return View(records);
        }

        public IActionResult SpotTip()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitQuizAsync()
        {
            var quizName = Request.Form["quizName"];
            var score = 0;
            var chosenOption = new List<string>();

            var quizData = new
            {
                q1 = "",
                q2 = "",
                q3 = "",
                q4 = "",
                q5 = "",
                q6 = "",
                q7 = "",
                q8 = "",
                a1 = 0,
                a2 = 0,
                a3 = 0,
                a4 = 0,
                a5 = 0,
                a6 = 0,
                a7 = 0,
                a8 = 0
            };

            var q1Answer = Request.Form["One"];
            var q2Answer = Request.Form["Two"];
            var q3Answer = Request.Form["Three"];
            var q4Answer = Request.Form["Four"];
            var q5Answer = Request.Form["Five"];
            var q6Answer = Request.Form["Six"];
            var q7Answer = Request.Form["Seven"];
            var q8Answer = Request.Form["Eight"];

            chosenOption.Add(q1Answer);
            chosenOption.Add(q2Answer);
            chosenOption.Add(q3Answer);
            chosenOption.Add(q4Answer);
            chosenOption.Add(q5Answer);
            chosenOption.Add(q6Answer);
            chosenOption.Add(q7Answer);
            chosenOption.Add(q8Answer);

            switch (quizName)
            {
                case "Quiz1":
                    // Process answers for Quiz1
                    // Check answer for Question 1
                    if (q1Answer == "B")
                    {
                        score += 1;
                    }

                    // Check answer for Question 2
                    if (q2Answer == "B")
                    {
                        score += 1;
                    }
                    if (q3Answer == "C")
                    {
                        score += 1;
                    }
                    // Display result
                    if (q4Answer == "B")
                    {
                        score += 1;
                    }
                    if (q5Answer == "B")
                    {
                        score += 1;
                    }
                    if (q6Answer == "B")
                    {
                        score += 1;
                    }
                    if (q7Answer == "A")
                    {
                        score += 1;
                    }
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
                            default:
                                answerList.Add(0);
                                break;
                        }
                    }
                    // Prepare quiz data to send to Flask API
                    quizData = new
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
                    break;
                case "Quiz2":
                    // Process answers for QuizContent1
                    if (q1Answer == "C")
                    {
                        score += 1;
                    }

                    if (q2Answer == "B")
                    {
                        score += 1;
                    }
                    if (q3Answer == "C")
                    {
                        score += 1;
                    }
                    if (q4Answer == "A")
                    {
                        score += 1;
                    }
                    if (q5Answer == "B")
                    {
                        score += 1;
                    }
                    if (q6Answer == "A")
                    {
                        score += 1;
                    }
                    if (q7Answer == "A")
                    {
                        score += 1;
                    }
                    if (q8Answer == "B")
                    {
                        score += 1;
                    }
                    answerList = new List<int>();
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
                            default:
                                answerList.Add(0);
                                break;
                        }
                    }
                    // Prepare quiz data to send to Flask API
                    quizData = new
                    {
                        q1 = "MC9",
                        q2 = "MC10",
                        q3 = "MC11",
                        q4 = "MC12",
                        q5 = "MC13",
                        q6 = "T1",
                        q7 = "T2",
                        q8 = "T3",
                        a1 = answerList[0],
                        a2 = answerList[1],
                        a3 = answerList[2],
                        a4 = answerList[3],
                        a5 = answerList[4],
                        a6 = answerList[5],
                        a7 = answerList[6],
                        a8 = answerList[7]
                    };
                    break;
                case "Quiz3":
                    // Process answers for QuizContent2
                    // Check answer for Question 1
                    if (q1Answer == "B")
                    {
                        score += 1;
                    }

                    // Check answer for Question 2
                    if (q2Answer == "C")
                    {
                        score += 1;
                    }
                    if (q3Answer == "B")
                    {
                        score += 1;
                    }
                    // Display result
                    if (q4Answer == "C")
                    {
                        score += 1;
                    }
                    if (q5Answer == "B")
                    {
                        score += 1;
                    }
                    if (q6Answer == "A")
                    {
                        score += 1;
                    }
                    if (q7Answer == "A")
                    {
                        score += 1;
                    }
                    if (q8Answer == "A")
                    {
                        score += 1;
                    }
                    answerList = new List<int>();
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
                            default:
                                answerList.Add(0);
                                break;
                        }
                    }
                    // Prepare quiz data to send to Flask API
                    quizData = new
                    {
                        q1 = "MC14",
                        q2 = "MC15",
                        q3 = "MC16",
                        q4 = "MC17",
                        q5 = "MC18",
                        q6 = "T5",
                        q7 = "T6",
                        q8 = "T7",
                        a1 = answerList[0],
                        a2 = answerList[1],
                        a3 = answerList[2],
                        a4 = answerList[3],
                        a5 = answerList[4],
                        a6 = answerList[5],
                        a7 = answerList[6],
                        a8 = answerList[7]
                    };
                    break;
            }

            // Send quiz data to Flask API and receive feedback
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://newswise.online/quiz_feedback", quizData);
            var feedbackJson = await response.Content.ReadAsStringAsync();
            var feedback = JsonConvert.DeserializeObject<dynamic>(feedbackJson);
            string SuggestedPage = feedback["Suggested Page"];
            string quizFeedback = feedback["Feedback"];
            switch (SuggestedPage)
            {
                case "The definition of fake news":
                    SuggestedPage = "Definition";
                    break;
                case "The existence of fake news/Biased Information":
                    SuggestedPage = "Existence";
                    break;
                case "The importance of identifying fake news":
                    SuggestedPage = "Importance";
                    break;
                case "Tips to spot fake news/How can you spot biased news":
                    SuggestedPage = "SpotTip";
                    break;
                case "Real life examples":
                    SuggestedPage = "RealLifeExamples";
                    break;
            }

            // Display result and feedback
            return View("QuizResults", new { Score = score, Feedback = quizFeedback.Replace("\n", "<br><br>"), SuggestedPage, SuggestedText = feedback["Suggested Page"] });
        }
        public IActionResult QuizContent()
        {
            return View();
        }
        public IActionResult QuizContent1()
        {
            return View();
        }

        public IActionResult QuizContent2()
        {
            return View();
        }

        public IActionResult RandomQuizPage()
        {
            Random random = new Random();
            int randomQuiz = random.Next(1, 4);

            switch (randomQuiz)
            {
                case 1:
                    return RedirectToAction("QuizContent", "Home");
                case 2:
                    return RedirectToAction("QuizContent1", "Home");
                case 3:
                    return RedirectToAction("QuizContent2", "Home");
                default:
                    return RedirectToAction("Index", "Home");
            }
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