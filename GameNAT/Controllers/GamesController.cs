using System.Linq;
using System.Web.Mvc;
using GameNAT.Models;

namespace GameNAT.Controllers
{
    public class GamesController : Controller
    {
        private GamesContext db = new GamesContext();

		// GET: /Games/AddGame/
		/// <summary>
		/// Displays the add game page.
		/// </summary>
		/// <returns>The add game view.</returns>
		[HttpGet]
		public ActionResult AddGame()
		{
			return View();
		}

		/// <summary>
		/// Adds a new game with the specified title.
		/// </summary>
		/// <param name="title">The title of the game to add.</param>
		/// <returns></returns>
		[HttpPost]
		public ViewResult AddGame(string title)
		{
			db.AddGame(title);
			return View();
		}

		// GET: /Games/AddVote/
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult AddVote()
		{
			return View();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost]
		public ViewResult AddVote(int id)
		{
			db.AddVote(id);
			return View();
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		// GET: /Games/
		public ActionResult Index()
		{
			return View(db.GetGames().ToList());
		}
    }
}
