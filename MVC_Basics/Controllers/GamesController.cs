using Microsoft.AspNetCore.Mvc;

namespace MVC_Basics.Controllers
{
    public class GamesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // Since I only have one game, 
        // I let this action/view merge with that one game for now
        public IActionResult Player()
        {
            return View("GuessingGameDisplay");
        }

        [HttpPost]
        public IActionResult Player(string player)
        {
            // Replaces null with the name Anonymous and empty spaces in the name with underscore '_'.
            if (player == null)
            {
                player = "Anonymous";
            }
            string newPlayer = player.Replace(' ', '_');

            HttpContext.Session.SetString("Player", newPlayer);
            ViewBag.NewMessage = "Your player name is set to " + HttpContext.Session.GetString("Player");
            return View("GuessingGameDisplay");
        }


        // A. "When the page is loaded for the first time,
        // the controller should generate a random number between 1 and 100,
        // that it will save in a session so it remembers it for the page even if it is refreshed."
        // B. "When the page is loaded through a GET request (such as through the URL),
        // the app should reset, and start over with a new number."
        // A&B is achived by havíng one view (GuessingGame) represent & process the game 
        // and then have another view (GuessingGameDisplay) handle the front-end presentation.
        public IActionResult GuessingGame()
        {

            // If the player has no name it is set to Anonymous
            if (HttpContext.Session.GetInt32("Player") == null)
            {
                HttpContext.Session.SetString("Player", "Anonymous");
            }

            if(TempData["Input"] != null) {
            // If the program got here by the player guessing the correct number 
            // the game types out the winning message & a highscore list.
            if (HttpContext.Session.GetInt32("TargetNumber") == (int)TempData["Input"]) 
            {
                // Some hardcoded scores to fill out the highscore list with
                var highscoreList = new List<Tuple<string, int>>
                    {
                        Tuple.Create("Minkinen", 6),
                        Tuple.Create("Minkinen", 5),
                        Tuple.Create("Minkinen", 7)
                    };

                // Add the player's name & score to the highscore list
                highscoreList.Add(new Tuple<string, int>(HttpContext.Session.GetString("Player"), (int)HttpContext.Session.GetInt32("Guesses")));

                // Sort the highscore list
                highscoreList = highscoreList.OrderBy(t => t.Item2).ToList();

                // Turning the highscore tuple-list into a string seperated by spaces 
                // that I plan to use when I have learned how to store text in cookies.
                string highscoreString = string.Join(" ", highscoreList.Select(t => string.Format("{0} {1}", t.Item1, t.Item2)));

                ViewBag.NewMessage = "Correct! You got the hidden number " + HttpContext.Session.GetInt32("TargetNumber") + " on guess " + HttpContext.Session.GetInt32("Guesses");
                ViewBag.Highscore = highscoreList;
            }
            }

            Random random = new Random();
            int num = random.Next();
            int number = random.Next(101);
            HttpContext.Session.SetInt32("TargetNumber", number);
            HttpContext.Session.SetInt32("Guesses", 0);
            return View("GuessingGameDisplay");
        }


        // "Guessing should be handled through overloaded Actions, referring to the same View."
        [HttpPost]
        public IActionResult GuessingGame(int input)
        {
            var guesses = HttpContext.Session.GetInt32("Guesses") + 1;
            HttpContext.Session.SetInt32("Guesses", (int)guesses);

            if (input > HttpContext.Session.GetInt32("TargetNumber"))
            {
                ViewBag.NewMessage = "Your guess " + input + " was too high!" + " Used guesses: " + HttpContext.Session.GetInt32("Guesses");
                return View("GuessingGameDisplay");
            }
            else
            {
                if (input < HttpContext.Session.GetInt32("TargetNumber"))
                {
                    ViewBag.NewMessage = "Your guess " + input + " was too low!" +  " Used guesses: " + HttpContext.Session.GetInt32("Guesses");
                    return View("GuessingGameDisplay");
                }
                else
                {
                    TempData["Input"] = input;
                    return RedirectToAction("GuessingGame");
                }
            }
        }
    }
}
