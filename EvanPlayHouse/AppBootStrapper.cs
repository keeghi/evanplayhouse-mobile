using System;
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

            RegisterServices();
            RegisterViews();
        }

        private static void RegisterServices()
        {

        }

        private static void RegisterViews()
        {

        }

        public static NavigationPage CreateMainView()
        {
            var mainView = new MainView(RxApp.TaskpoolScheduler, RxApp.MainThreadScheduler, ViewLocator.Current);
            var viewStackService = new ViewStackService(mainView, Device.RuntimePlatform == Device.Android);
            Locator.CurrentMutable.RegisterConstant(viewStackService, typeof(IViewStackService));
            //TODO: push first mainPage
            return mainView;
        }
    }
}
