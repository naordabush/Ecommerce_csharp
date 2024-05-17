using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lezioniEcommerce.API.Controllers.DataModel
{
    public class CARTS
    {
        [Key]
        [Column(TypeName = "int")]
        public int CART_ID { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int USER_ID { get; set; }

        [ForeignKey("USER_ID")]
        public USERS USER { get; set; }
    }
}
