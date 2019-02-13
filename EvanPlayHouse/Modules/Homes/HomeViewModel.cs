using System;
using System.Collections.Generic;
using System.Linq;
using EvanPlayHouse.Controls.ViewCells;
using EvanPlayHouse.Core.Services;
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
                    FeaturedToys = featuredToys.Select(featuredToy => new FeaturedItemViewModel(featuredToy)).ToList();
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

        #endregion
    }
}
