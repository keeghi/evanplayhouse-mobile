using System;
using EvanPlayHouse.Core.Services.Fakes;
using EvanPlayHouse.Modules.Homes;
using ReactiveUI;
using RxNavigation;
using RxNavigation.XamForms;
using Splat;
using Xamarin.Forms;

namespace EvanPlayHouse
{
    public static class AppBootstrapper
    {
        public static void Initialize()
        {
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();
           
            RegisterViews();
            RegisterServices();
           
        }



        private static void RegisterServices()
        {

        }

        private static void RegisterViews()
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    Locator.CurrentMutable.Register(() => new HomePhoneView(), typeof(IViewFor<HomeViewModel>));

                    break;
                case TargetIdiom.Tablet:
                    Locator.CurrentMutable.Register(() => new HomeTabletView(), typeof(IViewFor<HomeViewModel>));
                    break;
            }
        }

        public static NavigationPage CreateMainView()
        {
            var mainView = new MainView(RxApp.TaskpoolScheduler, RxApp.MainThreadScheduler, ViewLocator.Current);
            var viewStackService = new ViewStackService(mainView, Device.RuntimePlatform == Device.Android);
            Locator.CurrentMutable.RegisterConstant(viewStackService, typeof(IViewStackService));
            viewStackService.PushPage(new HomeViewModel(new FakeToyService())).Subscribe();
            return mainView;
        }
    }
}
