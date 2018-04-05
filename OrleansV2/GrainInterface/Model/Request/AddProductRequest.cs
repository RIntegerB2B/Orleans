namespace Dell.Solution.ItemApi.Model.Request
{
    public class AddProductRequest
    {
        public string Country { get; set; }
        public string Language { get; set; }
        public int Catalog { get; set; }
        public string CustomerSet { get; set; }
        public string OrderCodeId { get; set; }
    }
}
