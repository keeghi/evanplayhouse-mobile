using System;
using EvanPlayHouse.Data.Models;
using ReactiveUI;

namespace EvanPlayHouse.Controls.ViewCells
{
    public class FeaturedItemViewModel : ReactiveObject
    {
        public FeaturedItemViewModel(FeaturedToy featuredToy)
        {
            FeaturedToy = featuredToy;
        }

        #region Bindable Properties

        private FeaturedToy _toy;
        public FeaturedToy FeaturedToy
        {
            get => _toy;
            set => this.RaiseAndSetIfChanged(ref _toy, value);
        }

        #endregion
    }
}
