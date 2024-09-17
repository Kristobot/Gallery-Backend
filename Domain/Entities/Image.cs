using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Path { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime? CreationTimeStamp { get; set; }
    }
}
