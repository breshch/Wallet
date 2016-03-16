using System.Windows;
using Wallets.ViewModels;
using Wallets.Views;

namespace Wallets
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var viewModel = new WalletViewModel();
			var view = new WalletView();
			view.DataContext = viewModel;
			view.ShowDialog();
		}
	}
}
