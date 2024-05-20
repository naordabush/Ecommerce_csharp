using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.DataModel
{
    public class CATEGORIES
    {
        [Key]
        [Column(TypeName = "int")]
        public int CATEGORY_ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CATEGORY_NAME { get; set; }
        public ICollection<PRODUCTS_CATEGORIES> ProductsCategories { get; set; }
    }
}
