using System;
using System.Collections.Generic;

namespace ilovecoffee.Models
{
    public class ProductMockList
    {
        private List<Product> productList = new List<Product>();
        private long IdInc = 0;
        public void SeedData( bool fullfill){
            if(fullfill){
                productList.AddRange(new Product[]{
                new Product{ Id = IdIncrement(), Name = "Bota", Description = "Bota doida", Price = 10.5M },
                new Product{ Id = IdIncrement(), Name = "Bone", Description = "Bone doido", Price = 15.5M }});
            }
        }
        private long IdIncrement(){
            System.Console.WriteLine($"product Id = {IdInc}");
            return IdInc+= 1;

        }
        public  void Add(Product product){
            product.Id = IdIncrement();
            productList.Add(product);
        }
        public  List<Product> AllProducts(){
            return productList;
        }

        public Product FindOne(long id)
        {
            return productList.Find(item => item.Id == id);
        }

        public void Delete(long id){
            Product toDelete = productList.Find(item => item.Id == id);
            productList.Remove(toDelete);
        }
        public void Update(Product toUpdate){
            System.Console.WriteLine($"toUpdate id = {toUpdate.Id}, name{toUpdate.Name}");
            for(int i =0; i <= productList.Count - 1; i++){
                if(productList[i].Id == toUpdate.Id){
                    productList[i].Name = toUpdate.Name;
                    productList[i].Description = toUpdate.Description;
                    productList[i].Price = toUpdate.Price;
                }
            }
        }
    }
}