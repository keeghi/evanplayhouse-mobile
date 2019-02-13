using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;

namespace EvanPlayHouse.Modules.Homes
{
    public partial class HomePhoneView : BaseContentPage<HomeViewModel>
    {
        public HomePhoneView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.WhenActivated(disposable =>
            {
                //this.WhenAnyValue(x => x.ViewModel.FeaturedToys)
                //.Where(featuredToys => featuredToys != null && featuredToys.Any())
                //.Do(featuredToys=>
                //{
                //    FeaturedToysCarousel.ItemsSource = featuredToys;
                //})
                //.Subscribe().DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, vm => vm.FeaturedToys, v => v.FeaturedToysCarousel.ItemsSource).DisposeWith(disposable);
            });
        }

    }
}
