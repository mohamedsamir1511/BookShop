using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Entities.Models
{
    public class Category
    {
        // [Key]
        public int Id { get; set; }
        // [Required,MaxLength(20)]
        public string CatName { get; set; }
        //[Required]
        public int CatOrder { get; set; }
        //[NotMapped]
        public DateTime CreatedDate { get; set; }
        //[Column("isDeleted")]
        public bool MarkedAsDeleted { get; set; }




    }
}
