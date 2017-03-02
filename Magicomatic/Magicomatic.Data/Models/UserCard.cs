
namespace Magicomatic.Data.Models
{
    public class UserCard : Card
    {
        public int Amount { get; set; }
        public int ForTrade { get; set; }
        public string Language { get; set; }
        public string Condition { get; set; }
        public string Foil { get; set; }
    }
}
