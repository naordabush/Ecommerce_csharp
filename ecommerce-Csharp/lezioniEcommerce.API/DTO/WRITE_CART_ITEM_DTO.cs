namespace lezioniEcommerce.API.DTO
{
    public class WRITE_CART_ITEM_DTO
    {
        public int CART_ITEM_QUANTITY { get; set; }
        public WRITE_CART_DTO CART { get; set; }
        public WRITE_PRODUCT_DTO PRODUCT { get; set; }
    }
}
