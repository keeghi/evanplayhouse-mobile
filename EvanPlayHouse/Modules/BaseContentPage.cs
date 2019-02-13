using System.Reactive;
using EvanPlayHouse.Core.Commons;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace EvanPlayHouse.Modules
{
    public class BaseContentPage<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : BaseViewModel
    {
        public BaseContentPage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
            this.WhenActivated(disposable =>
            {              
                Interactions
                    .LoadingDataStarted
                    .RegisterHandler((arg) =>
                    {
                        arg.SetOutput(Unit.Default);
                    });
                Interactions
                    .LoadingDataFinished
                   .RegisterHandler((arg) =>
                   {
                       arg.SetOutput(Unit.Default);
                   });
                Interactions
                    .LoadingDataFailed
                   .RegisterHandler((arg) =>
                   {
                       arg.SetOutput(Unit.Default);
                   });
            });
        }
    }
}
