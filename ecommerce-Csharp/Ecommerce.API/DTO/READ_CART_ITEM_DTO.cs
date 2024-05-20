namespace Ecommerce.API.DTO
{
    public class READ_CART_ITEM_DTO : WRITE_CART_ITEM_DTO
    {
        public int CART_ITEM_ID { get; set; }
        public int CART_ID { get; set; }
        public int PRODUCT_ID { get; set; }
        public new READ_CART_DTO CART { get; set; }
        public new READ_PRODUCT_DTO PRODUCT { get; set; }
    }
}
