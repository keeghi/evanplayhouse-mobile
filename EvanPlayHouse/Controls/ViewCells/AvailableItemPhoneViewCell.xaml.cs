using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.XamForms;

namespace EvanPlayHouse.Controls.ViewCells
{
    public partial class AvailableItemPhoneViewCell : ReactiveContentView<AvailableItemViewModel>
    {
        public AvailableItemPhoneViewCell()
        {
            InitializeComponent();
            this.WhenAnyValue(x => x.ViewModel)
                .Where(vm => vm != null)
                .Do(vm =>
                {
                    Image.Source = vm.Toy.Thumbnail;
                    NameLabel.Text = vm.Toy.ToyTitle;
                }).Subscribe();
        }
    }
}
