using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameNAT.Models
{
	public class GamesContext : DbContext
	{
		private readonly string apiKey = "b09b6521e4db2bbbaf82fc09dfea64c1";
		private XboxVotingService.XboxVotingServiceSoap xboxClient = new XboxVotingService.XboxVotingServiceSoapClient("XboxVotingServiceSoap");

		public GamesContext() : base("name=GamesContext")
		{

		}

		/// <summary>
		/// Adds a new game with the specified title.
		/// </summary>
		/// <param name="title">The title of the game to add.</param>
		/// <returns></returns>
		public bool AddGame(string title)
		{
			return xboxClient.AddGame(title, apiKey);
		}

		/// <summary>
		/// Adds a vote to the game with the specified id.
		/// </summary>
		/// <param name="id">The id of the game to add a vote for.</param>
		/// <returns></returns>
		public bool AddVote(int id)
		{
			return xboxClient.AddVote(id, apiKey);
		}

		/// <summary>
		/// Clears the games collection.
		/// </summary>
		/// <returns></returns>
		public bool ClearGames()
		{
			return xboxClient.ClearGames(apiKey);
		}

		/// <summary>
		/// Returns a list of the current games.
		/// </summary>
		/// <returns>An array containing the current games.</returns>
		public XboxVotingService.XboxGame[] GetGames()
		{
			return xboxClient.GetGames(apiKey);
		}

		/// <summary>
		/// Sets the specified game id to got it.
		/// </summary>
		/// <param name="id">The id of the game.</param>
		/// <returns></returns>
		public bool SetGotIt(int id)
		{
			return xboxClient.SetGotIt(id, apiKey);
		}

		/// <summary>
		/// Gets or sets the XBox games data context.
		/// </summary>
		public DbSet<GameNAT.XboxVotingService.XboxGame> XboxGames
		{
			get;
			set;
		}
	}
}