namespace RestaurantWebAPI.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }  // nullable in case DB returns null
        public decimal? TotalPrice { get; set; }  // nullable
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public int? CreatedBy { get; set; }       // nullable
        public string? OrderName { get; set; }
    }
}