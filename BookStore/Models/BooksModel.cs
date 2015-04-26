using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BookStore.Models
{
    public class BooksModel

    {
        public int Id { set; get; }
       [Required(ErrorMessage = "You need to insert the title.")]
        public String Title { set; get; }

          [Required(ErrorMessage = "You need to insert the author.")]
        public String  Author{ set; get; }

          [Required(ErrorMessage = "You need to insert the gender.")]
        public String Gender { set; get; }

          [Required(ErrorMessage = "You need to insert the price.")]
          [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
          public float Price { set; get; }
    }


    public class BooksDb : DbContext
    {
     

        public DbSet<BooksModel> Books { get; set; }

        public DbSet<UserModel> Users { get; set; }

       public DbSet<CartModel> Cart { get; set; }

    }
}



