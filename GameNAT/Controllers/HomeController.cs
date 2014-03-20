using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameNAT.Controllers
{
	public class HomeController : Controller
	{
		private readonly string apiKey = "b09b6521e4db2bbbaf82fc09dfea64c1";
		private XboxVotingService.XboxVotingServiceSoap xboxClient = new XboxVotingService.XboxVotingServiceSoapClient("XboxVotingServiceSoap");

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "GameNAT is an XBox 360 game management system written for The Nerdery by Steve McAllister.";

			return View();
		}

		public ActionResult GetGames()
		{
			return View();
		}
	}
}
