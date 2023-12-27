using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieRetete.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        [OneToMany]
        public List<ListProduct> ListProducts { get; set; }
    }
}