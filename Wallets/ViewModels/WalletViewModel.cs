using System;
using System.Collections.ObjectModel;
using System.Linq;
using Wallets.Helpers;
using Wallets.Models;

namespace Wallets.ViewModels
{
	class WalletViewModel : PropertyChangedBase
	{
		private readonly Repository _repository;

		public WalletViewModel()
		{
			_repository = new Repository();
			
			var walletsDb = _repository.GetWallets();
			Wallets = new ObservableCollection<Wallet>(walletsDb);

			SaveCommand = new RelayCommand(Save);
		}

		public RelayCommand SaveCommand { get; set; }

		private ObservableCollection<Wallet> _wallets;

		public ObservableCollection<Wallet> Wallets
		{
			get { return _wallets; }
			set
			{
				_wallets = value;
				OnPropertyChanged();
			}
		}

		private void Save(object parameter)
		{
			_repository.SaveWallets(Wallets.ToArray());
		}
	}
}
