namespace PMSAPP.Entities
{
    public class ProductServiceResponseMessage<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
