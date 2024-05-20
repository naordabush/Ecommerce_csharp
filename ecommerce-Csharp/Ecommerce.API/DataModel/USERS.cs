using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controllers.DataModel
{
    public class USERS
    {
        [Key]
        [Column(TypeName = "int")]
        public int USER_ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String USER_USERNAME { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String USER_FIRSTNAME { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String USER_LASTNAME { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public String USER_PASSWORD { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String USER_EMAIL { get; set; }
         }
}
