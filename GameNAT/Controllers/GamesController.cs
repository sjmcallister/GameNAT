using System.Linq;
using System.Web.Mvc;
using GameNAT.Models;
using System;

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
			try
			{
				if (db.AddGame(title))
				{
					// If we are able to add the new title, let the user know.
					ViewBag.StatusMessage = string.Format("Game {0} added successfully.", title);
				}
				else
				{
					// Otherwise, let the user know the title couldn't be added.
					ViewBag.StatusMessage = string.Format("Unable to add the game {0}.  Please try again.", title);
				}
				return View();
			}
			catch
			{
				// An error has occured and the user needs to be notified.
				ViewBag.StatusMessage = "An error has occured.  Please try again.";
				return View();
			}
		}

		// GET: /Games/AddVote/
		/// <summary>
		/// Displays the add vote page.
		/// </summary>
		/// <returns>The add vote view.</returns>
		[HttpGet]
		public ActionResult AddVote()
		{
			return View();
		}

		/// <summary>
		/// Adds a vote to the specified id.
		/// </summary>
		/// <param name="id">The id of the game.</param>
		/// <returns></returns>
		[HttpPost]
		public ViewResult AddVote(int id)
		{
			try
			{
				if (db.AddVote(id))
				{
					// If we are able to find the id and a vote has been added, let the user know.
					ViewBag.StatusMessage = string.Format("Vote added successfully to game {0}.", id);
				}
				else
				{
					// Otherwise, let the user know the id couldn't be found.
					ViewBag.StatusMessage = string.Format("Unable to find the game id {0}.  Please try again.", id);
				}
				return View();
			}
			catch
			{
				// An error has occured and the user needs to be notified.
				ViewBag.StatusMessage = string.Format("Unable to find game id {0}.  Please try again.", id);
				return View();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult ClearGames()
		{
			return View();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public ActionResult ClearGames(bool clear = true)
		{
			try
			{
				if (db.ClearGames())
				{
					// If we are able to clear all games, let the user know.
					ViewBag.StatusMessage = "All games have been cleared.";
				}
				else
				{
					// Otherwise, let the user know it couldn't be done.
					ViewBag.StatusMessage = "Unable to clear all games.  Please try again.";
				}
				return View();
			}
			catch
			{
				// An error has occured and the user needs to be notified.
				ViewBag.StatusMessage = "An error has occured.  Please try again.";
				return View();
			}
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
		/// <summary>
		/// Displays the games page with a list of the current games.
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View(db.GetGames().ToList());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult SetGotIt()
		{
			return View();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult SetGotIt(int id)
		{
			try
			{
				if (db.SetGotIt(id))
				{
					// If we are able to find the id and set got it, let the user know.
					ViewBag.StatusMessage = string.Format("Set got it successfully for game {0}.", id);
				}
				else
				{
					// Otherwise, let the user know the id couldn't be found.
					ViewBag.StatusMessage = string.Format("Unable to set got it for the game id {0}.  Please try again.", id);
				}
				return View();
			}
			catch
			{
				// An error has occured and the user needs to be notified.
				ViewBag.StatusMessage = string.Format("Unable to find game id {0}.  Please try again.", id);
				return View();
			}
		}
	}
}