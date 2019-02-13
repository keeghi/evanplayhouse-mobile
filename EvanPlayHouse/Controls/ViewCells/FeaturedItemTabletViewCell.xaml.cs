using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.XamForms;

namespace EvanPlayHouse.Controls.ViewCells
{
    public partial class FeaturedItemTabletViewCell : ReactiveContentView<FeaturedItemViewModel>
    {
        public FeaturedItemTabletViewCell()
        {
            InitializeComponent();
            this.WhenAnyValue(x => x.ViewModel)
                .Where(vm => vm != null)
                .Do(vm =>
                {
                    Image.Source = vm.FeaturedToy.Toy.Thumbnail;
                }).Subscribe();
        }
    }
}
