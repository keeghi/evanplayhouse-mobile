using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EvanPlayHouse.Controls.ViewCells;
using EvanPlayHouse.Core.Services;
using EvanPlayHouse.Helpers;
using ReactiveUI;
using Splat;

namespace EvanPlayHouse.Modules.Homes
{
    public class HomeViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly IToyService _toyService;

        #endregion

        #region Constructor

        public HomeViewModel(IToyService toyService = null)
        {
            _toyService = toyService ?? Locator.Current.GetService<IToyService>();
            _toyService
                .GetFeaturedToys()
                .Subscribe(featuredToys =>
                {
                    if (featuredToys == null || !featuredToys.Any())
                    {
                        return;
                    }
                    FeaturedToys = featuredToys.Select(featuredToy => new FeaturedItemViewModel(featuredToy)).ToList();
                });
            _toyService
                .GetAvailableToys()
                .Subscribe(availableToys =>
                {
                    if (availableToys == null || !availableToys.Any())
                    {
                        return;
                    }
                    var allAvailableToys= availableToys.Select(availableToy => new AvailableItemViewModel(availableToy)).ToList();
                    AvailableToys.AddRange(allAvailableToys);
                });
        }

        #endregion

        #region Bindable Properties

        private List<FeaturedItemViewModel> _featuredToys = new List<FeaturedItemViewModel>();
        public List<FeaturedItemViewModel> FeaturedToys
        {
            get => _featuredToys;
            set => this.RaiseAndSetIfChanged(ref _featuredToys, value);
        }

        private ObservableRangeCollection<AvailableItemViewModel> _availableToys = new ObservableRangeCollection<AvailableItemViewModel>();
        public ObservableRangeCollection<AvailableItemViewModel> AvailableToys
        {
            get => _availableToys;
            set => this.RaiseAndSetIfChanged(ref _availableToys, value);
        }


        #endregion
    }
}
