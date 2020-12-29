using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ilovecoffee.Models
{
    public class Product : BaseModel
    {
        public string Name {get;set;}
        public string Description {get;set;}
        [Column( TypeName = "decimal(8.2)")]
        public decimal Price{get;set;}
    }
}