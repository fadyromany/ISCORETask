using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DTOs.Request
{
    public class BookDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(256, ErrorMessage = "Title length cannot exceed 256 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(256, ErrorMessage = "Author length cannot exceed 256 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        [StringLength(256, ErrorMessage = "ImageURL length cannot exceed 256 characters.")]
        public string Image { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative integer.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Publication Date is required.")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }



    }
}
