using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cartId { get; set; }
        [Required]
        public int GroceryId { get; set; }

        [NotMapped]
        public string Groceryname { get; set; }

    }
}
