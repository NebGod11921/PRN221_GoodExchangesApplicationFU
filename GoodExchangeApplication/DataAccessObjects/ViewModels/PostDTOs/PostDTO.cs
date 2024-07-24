using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.PostDTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ImageURL {  get; set; }
        public byte? Status { get; set; } 

        public int? UserId { get; set; }
        public int? ProductId { get; set; }
    }
}
