using ASM.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Demo6.Models
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Decs { get; set; }
        public string? Imgurl { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }       
        //public Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

    }
}
