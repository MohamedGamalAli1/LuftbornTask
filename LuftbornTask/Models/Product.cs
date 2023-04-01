using System.ComponentModel.DataAnnotations;

namespace LuftbornTask.Models
{
    public class Product:BaseObject
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
