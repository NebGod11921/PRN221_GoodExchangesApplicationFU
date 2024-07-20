using BusinessObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ProductDTOs
{
    public class RequestProductDTO: BaseEntity
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public float? Price { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 50, ErrorMessage = "Quantity must be at least 1 and not exceed 50")]
        public int? Quantity { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Image is required")]
        public IFormFile? ImageFile { get; set; }
    }
}
