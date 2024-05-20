namespace Ecommerce.API.DTO
{
    public class READ_PRODUCT_CATEGORY_DTO : WRITE_PRODUCT_CATEGORY_DTO
    {
        public int PRODUCT_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public new READ_CATEGORY_DTO CATEGORY { get; set; }
        public new READ_PRODUCT_DTO PRODUCT { get; set; }

    }
}
