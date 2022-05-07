using ASM.Areas.Identity.Data;


namespace Demo6.Models
{
    public class Cart
    {
        public string UId { get; set; }
        public string BookIsbn { get; set; }
        public AppUser? User { get; set; }
        public Book? Book { get; set; }
    }
}
