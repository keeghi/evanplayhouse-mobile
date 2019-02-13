using Realms;

namespace EvanPlayHouse.Data.Models
{
    public class FeaturedToy : RealmObject
    {
        public int FeaturedToyID { get; set; }
        public Toy Toy { get; set; }
    }
}
