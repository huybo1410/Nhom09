namespace Nhom09.Models
{
    public class product
    {
        public int Id { get; set; }

        public string Product_name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public int Product_type_id { get; set; }
        public product_type Product_type { get; set; }

        public List<invoice_detail> invoice_Details { get; set; }
    }
}
