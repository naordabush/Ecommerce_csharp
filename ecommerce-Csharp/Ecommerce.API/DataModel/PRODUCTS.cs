using Ecommerce.API.DataModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Controllers.DataModel
{
    public class PRODUCTS
    {
        [Key]
        [Column(TypeName = "int")]
        public int PRODUCT_ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PRODUCT_NAME { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PRODUCT_DESCRIPTION { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public double PRODUCT_PRICE { get; set; }

        [Column(TypeName = "bit")]
        public bool PRODUCT_ISACTIVE { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PRODUCT_IMAGE { get; set; }

        //[Required]
        //[Column(TypeName = "int")]
        //public int BRAND_ID { get; set; }

        //[ForeignKey("BRAND_ID")]
        //public BRANDS BRAND { get; set; }

        public ICollection<PRODUCTS_CATEGORIES> ProductsCategories { get; set; }
    }
}