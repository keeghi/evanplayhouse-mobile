using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using EvanPlayHouse.Data.Models;

namespace EvanPlayHouse.Core.Services.Fakes
{
    public class FakeToyService : IToyService
    {
        public IObservable<IEnumerable<Toy>> GetAvailableToys()
        {
            var toys = new List<Toy>
            {
                new Toy
                {
                        Description = "Test 1",
                        Images = "https://i5.walmartimages.com/asr/a4ac67fe-2313-49c0-9995-0ad038ae3b47_1.494ce428e4fd02edb749e69ac2458790.jpeg",
                        IsAvailable = true,
                        Thumbnail = "https://i5.walmartimages.com/asr/a4ac67fe-2313-49c0-9995-0ad038ae3b47_1.494ce428e4fd02edb749e69ac2458790.jpeg",
                        ToyID = 1,
                        ToyTitle = "Test 1",
                    },
                        new Toy
                    {
                        Description = "Test 2",
                        Images = "https://images-na.ssl-images-amazon.com/images/I/41j7sUcAvwL.jpg",
                        IsAvailable = true,
                        Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/41j7sUcAvwL.jpg",
                        ToyID = 2,
                        ToyTitle = "Test 2",
                    },
                new Toy
                {
                    Description = "Test 3",
                    Images = "https://dimg.dillards.com/is/image/DillardsZoom/zoom/starting-out-10-bear-plush-toy/05151397_zi_brown.jpg",
                    IsAvailable = true,
                    Thumbnail = "https://dimg.dillards.com/is/image/DillardsZoom/zoom/starting-out-10-bear-plush-toy/05151397_zi_brown.jpg",
                    ToyID = 3,
                    ToyTitle = "Test 3",
                },
                new Toy
                    {
                        Description = "Test 4",
                        Images = "https://images-na.ssl-images-amazon.com/images/I/51tBuAmAkdL._SY300_QL70_.jpg",
                        IsAvailable = true,
                        Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51tBuAmAkdL._SY300_QL70_.jpg",
                        ToyID = 4,
                        ToyTitle = "Test 4",
                    },
                new Toy
                    {
                        Description = "Test 5",
                        Images = "https://www.bluefrogtoys.co.uk/images/stories/virtuemart/product/minion-10-inch-soft-toys.jpg",
                        IsAvailable = true,
                        Thumbnail = "https://www.bluefrogtoys.co.uk/images/stories/virtuemart/product/minion-10-inch-soft-toys.jpg",
                        ToyID = 5,
                        ToyTitle = "Test 5",
                    },
            };
            return Observable.Return(toys);
        }

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
