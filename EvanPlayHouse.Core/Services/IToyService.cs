using System;
using System.Collections.Generic;
using EvanPlayHouse.Data.Models;

namespace EvanPlayHouse.Core.Services
{
    public interface IToyService
    {
        IObservable<IEnumerable<FeaturedToy>> GetFeaturedToys();
        IObservable<IEnumerable<Toy>> GetAvailableToys();
    }
}
