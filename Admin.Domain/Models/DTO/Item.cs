namespace Admin.Domain.Models.DTO
{
    public class Item
    {
        public string label { get; set; } = null;
        public string value { get; set; } = null;
        public string code { get; set; } = null;
        public int? step { get; set; }
    }
}