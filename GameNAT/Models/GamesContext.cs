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

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GamesContext() : base("name=GamesContext")
        {

        }

		/// <summary>
		/// Adds a new game with the specified title.
		/// </summary>
		/// <param name="title">The title of the game to add.</param>
		public void AddGame(string title)
		{
			xboxClient.AddGame(title, apiKey);
		}

		/// <summary>
		/// Adds a vote to the game with the specified id.
		/// </summary>
		/// <param name="id">The id of the game to add a vote for.</param>
		public void AddVote(int id)
		{
			xboxClient.AddVote(id, apiKey);
		}

		/// <summary>
		/// Returns a list of the current games.
		/// </summary>
		/// <returns>An array containing the current games.</returns>
		public XboxVotingService.XboxGame[] GetGames()
		{
			return xboxClient.GetGames(apiKey);
		}

		public DbSet<GameNAT.XboxVotingService.XboxGame> XboxGames { get; set; }
    
    }
}
