namespace Ecommerce.API.DTO
{
    public class READ_CART_DTO :WRITE_CART_DTO
    {
        public int CART_ID { get; set; }
        public int USER_ID { get; set; }
        public new READ_USER_DTO USER { get; set; }
    }
}
