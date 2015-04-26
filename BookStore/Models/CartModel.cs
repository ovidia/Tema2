using System;

namespace BookStore.Models
{
    public class CartModel
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public String Title { set; get; }
        public String Author { set; get; }
        public String Gender { set; get; }
        public float Price { set; get; }
        public int Count { set; get; }
    }
}