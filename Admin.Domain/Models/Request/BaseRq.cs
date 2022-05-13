namespace Admin.Domain.Models.Request
{
    public class BaseRq<T>
    {
        public string Search { get; set; } = null;
        public T Data { get; set; } = default(T);
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
