using ReactiveUI;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace EvanPlayHouse.Modules.Homes
{
    public partial class HomePhoneView : BaseContentPage<HomeViewModel>
    {
        public HomePhoneView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.FeaturedToys, v => v.FeaturedToysCarousel.ItemsSource);
                this.OneWayBind(this.ViewModel, vm => vm.AvailableToys, v => v.AvailableToysStackLayout.ItemsSource);
            });
        }
    }
}
