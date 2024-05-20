
using Ecommerce.API.Controllers.DataModel;

namespace Ecommerce.API.DataModel
{
    public class PRODUCTS_CATEGORIES
    {
        //[Key]
        //[Column(TypeName = "int")]
        //public int PRODUCT_CATEGORY_ID { get; set; }
        ////---------------------------------------

        //[Required]
        //[Column(TypeName = "int")]
        //public int PRODUCT_ID { get; set; }
        //[ForeignKey("PRODUCT_ID")]
        //public PRODUCTS PRODUCTS { get; set; }
        ////---------------------------------------

        //[Required]
        //[Column(TypeName = "int")]
        //public int CATEGORY_ID { get; set; }
        //[ForeignKey("CATEGORY_ID")]
        //public CATEGORIES CATEGORIES { get; set; }

        public int PRODUCT_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public PRODUCTS PRODUCT { get; set; }
        public CATEGORIES CATEGORY { get; set; }
        
    }
}
