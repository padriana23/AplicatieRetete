using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieRetete.Models
{
    public class ListProduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Retete))]
        public int ReteteID { get; set; }
        public int ProductID { get; set; }
    }
}