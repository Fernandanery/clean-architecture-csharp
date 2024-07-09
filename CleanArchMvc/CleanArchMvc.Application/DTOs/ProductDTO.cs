using CleanArchMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        // Data annotations de name
        [Required(ErrorMessage = "The name is required")] 
        [MinLength(3)] 
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        // Data annotations de name
        [Required(ErrorMessage = "The description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        // Data annotations de price
        [Required(ErrorMessage = "The price is required")]
        [Column(TypeName ="decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        // Data annotations de stock
        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        // Data annotations de Image
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; set; }

        public Category Category { get; set; }

        // Data annotations de CategoryId
        [DisplayName("Categories")]
        public int CategoryId { get; set; }

    }
}
