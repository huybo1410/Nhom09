namespace Nhom09.Models
{
    public class invoice_detail
    {
        public int Id { get; set; }


        public int Product_id { get; set; }
        public product product { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public int Invoice_id { get; set; }
        public invoice invoice { get; set; }

    }
}
