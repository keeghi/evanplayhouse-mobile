using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace EvanPlayHouse.Modules.Homes
{
    public partial class HomeTabletView : BaseContentPage<HomeViewModel>
    {
        public HomeTabletView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.WhenActivated(disposable =>
            {
                this.WhenAnyValue(x => x.ViewModel.FeaturedToys)
                .Where(featuredToys => featuredToys != null && featuredToys.Any())
                .Do(featuredToys =>
                {
                    FeaturedToysCarousel.ItemsSource = featuredToys;
                })
                .Subscribe().DisposeWith(disposable);
            });
        }
    }
}
