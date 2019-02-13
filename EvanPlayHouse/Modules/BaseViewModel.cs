using System;
using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;
using RxNavigation;
using Splat;
using Xamarin.Forms;

namespace EvanPlayHouse.Modules
{
    public abstract class BaseViewModel : ReactiveObject, ISupportsActivation, IPageViewModel, IEnableLogger
    {
        public string UrlPathSegment
        {
            get;
            protected set;
        }

        public readonly ReactiveCommand<Unit, Unit> GoBack;
        public readonly ReactiveCommand<Unit, Unit> GoBackToRoot;
        public readonly ReactiveCommand<Unit, Unit> GoBackModal;

        public ViewModelActivator Activator => ViewModelActivator;

        protected readonly ViewModelActivator ViewModelActivator = new ViewModelActivator();

        protected IViewStackService ViewStackService { get; }

        public string Title => GetType().Name;

        protected BaseViewModel(IViewStackService viewStackService = null)
        {
            this.Log().Write("", GetType(), LogLevel.Info);
            ViewStackService = viewStackService ?? Locator.Current.GetService<IViewStackService>();
            GoBack = ReactiveCommand.CreateFromObservable(() => ViewStackService.PopPages());
            GoBackModal = ReactiveCommand.CreateFromObservable(() => ViewStackService.PopModal());
            GoBackToRoot = ReactiveCommand.CreateFromObservable(() => ViewStackService.PopToRoot());
            this.WhenActivated((CompositeDisposable disposable) =>
            {
                GoBack
                    .ThrownExceptions
                    .Subscribe(x =>
                    {
                        this.Log().ErrorException(nameof(GoBack), x);
                    }).DisposeWith(disposable);
                GoBackModal
                  .ThrownExceptions
                  .Subscribe(x =>
                  {
                      this.Log().ErrorException(nameof(GoBackModal), x);
                  }).DisposeWith(disposable);
                GoBackToRoot
                  .ThrownExceptions
                  .Subscribe(x =>
                  {
                      this.Log().ErrorException(nameof(GoBackToRoot), x);
                  }).DisposeWith(disposable);
            });
        }
    }
}
