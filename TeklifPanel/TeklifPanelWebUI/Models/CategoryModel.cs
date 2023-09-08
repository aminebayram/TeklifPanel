namespace TeklifPanelWebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public int CompanyId { get; set; }
        public decimal KDV { get; set; }
    }
}
