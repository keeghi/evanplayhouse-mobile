using System;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace EvanPlayHouse.Data.Models
{
    public class Toy : RealmObject
    {
        public int ToyID { get; set; }
        public string ToyTitle { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int Price2W { get; set; }
        public int Price4W { get; set; }
        public DateTimeOffset? NextAvailableDate { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }

        [Ignored]
        public List<string> ImagesData => !string.IsNullOrWhiteSpace(Images) ? Images.Split(';').ToList() : new List<string>();
    }
}
