using System;
using EvanPlayHouse.Data.Models;
using ReactiveUI;

namespace EvanPlayHouse.Controls.ViewCells
{
    public class AvailableItemViewModel : ReactiveObject
    {
        public AvailableItemViewModel(Toy toy)
        {
            Toy = toy;
        }

        #region Bindable Properties

        private Toy _toy;
        public Toy Toy
        {
            get => _toy;
            set => this.RaiseAndSetIfChanged(ref _toy, value);
        }

        #endregion
    }
}
