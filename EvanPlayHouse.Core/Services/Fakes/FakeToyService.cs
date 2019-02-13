using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using EvanPlayHouse.Data.Models;

namespace EvanPlayHouse.Core.Services.Fakes
{
    public class FakeToyService : IToyService
    {
        public IObservable<IEnumerable<FeaturedToy>> GetFeaturedToys()
        {
            var featuredToys = new List<FeaturedToy>
            {
                new FeaturedToy
                {
                    FeaturedToyID = 1,
                    Toy = new Toy
                    {
                        Description = "Test 1",
                        Images = "gambar1.png",
                        IsAvailable = true,
                        Thumbnail = "gambar1.png",
                        ToyID = 1,
                        ToyTitle = "Test 1",
                    },
                },
                new FeaturedToy
                {
                    FeaturedToyID = 2,
                    Toy = new Toy
                    {
                        Description = "Test 2",
                        Images = "gambar2.png",
                        IsAvailable = true,
                        Thumbnail = "gambar2.png",
                        ToyID = 2,
                        ToyTitle = "Test 2",
                    },
                },
                new FeaturedToy
                {
                    FeaturedToyID = 3,
                    Toy = new Toy
                    {
                        Description = "Test 3",
                        Images = "gambar3.png",
                        IsAvailable = true,
                        Thumbnail = "gambar3.png",
                        ToyID = 3,
                        ToyTitle = "Test 3",
                    },
                },
                new FeaturedToy
                {
                    FeaturedToyID = 4,
                    Toy = new Toy
                    {
                        Description = "Test 4",
                        Images = "gambar4.png",
                        IsAvailable = true,
                        Thumbnail = "gambar4.png",
                        ToyID = 4,
                        ToyTitle = "Test 4",
                    },
                },
                new FeaturedToy
                {
                    FeaturedToyID = 5,
                    Toy = new Toy
                    {
                        Description = "Test 5",
                        Images = "gambar5.png",
                        IsAvailable = true,
                        Thumbnail = "gambar5.png",
                        ToyID = 5,
                        ToyTitle = "Test 5",
                    },
                }
            };
            return Observable.Return(featuredToys);
        }
    }
}
