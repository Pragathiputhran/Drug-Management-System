namespace DrugManagementAPI.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierId { get; set; }
    }
}
