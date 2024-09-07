using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Objects
{
    [Table("Books")]
    public class BookVM
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string Author { get; set; }
        public string  ImageUrl { get; set; }
        public int Quantity { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
