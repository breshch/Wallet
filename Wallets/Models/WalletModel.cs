using System;

namespace Wallets.Models
{
	class WalletModel
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public decimal Sum { get; set; }
		public string Description { get; set; }
	}
}
