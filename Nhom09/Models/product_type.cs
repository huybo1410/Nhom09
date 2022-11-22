namespace Nhom09.Models
{
    public class product_type
    {
        public int Id { get; set; }

        public string Product_type_name { get; set; }
        public List<product> products { get; set; }
    }
}
