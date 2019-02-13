using System;
using System.Reactive;
using ReactiveUI;

namespace EvanPlayHouse.Core.Commons
{
    public static class Interactions
    {
        public static readonly Interaction<Unit, Unit> LoadingDataStarted = new Interaction<Unit, Unit>();
        public static readonly Interaction<Unit, Unit> LoadingDataFinished = new Interaction<Unit, Unit>();
        public static readonly Interaction<Exception, Unit> LoadingDataFailed = new Interaction<Exception, Unit>();
    }
}
