using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Wallets
{
	class Repository
	{
		public void SaveWallets(Wallet[] wallets)
		{
			using (var db = GetConnection())
			{
				using (var transaction = db.BeginTransaction())
				{
					try
					{
						db.Execute("DELETE FROM Wallets", null, transaction);
						db.Execute("INSERT INTO Wallets (Date, Sum, Description) VALUES(@Date, @Sum, @Description)", wallets, transaction);

						transaction.Commit();
					}
					catch
					{
						transaction.Rollback();
					}
				}
			}
		}

		public Wallet[] GetWallets()
		{
			using (var db = GetConnection())
			{
				var wallets = db.Query<Wallet>("SELECT * FROM Wallets").ToArray();
				return wallets;
			}
		}

		public SqlConnection GetConnection()
		{
			string cs = ConfigurationManager.ConnectionStrings["Wallet"].ConnectionString;
			var connection = new SqlConnection(cs);
			connection.Open();
			return connection;
		}
	}
}
