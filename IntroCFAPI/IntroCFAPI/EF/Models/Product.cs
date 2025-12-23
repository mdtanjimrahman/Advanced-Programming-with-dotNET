using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFAPI.EF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }

        [ForeignKey("CatId")]
        public int Cid { get; set; }
        public virtual Category CatId { get; set; }
    }
}
