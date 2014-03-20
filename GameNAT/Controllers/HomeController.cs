using System.Web.Mvc;
using GameNAT.Models;

namespace GameNAT.Controllers
{
	public class HomeController : Controller
	{
		private GamesContext db = new GamesContext();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "GameNAT is an XBox 360 game management system written for The Nerdery by Steve McAllister.";

			return View();
		}
	}
}