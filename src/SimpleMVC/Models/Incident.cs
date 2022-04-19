using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVC.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        public Status Status { get; set; }
        [MaxLength(200)]
        public string FirstName { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        [Required]
        public int? ClassificationId { get; set; }
        public Classification Classification { get; set; }
    }
}
