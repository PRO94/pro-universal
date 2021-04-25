using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro.Universal.Data.Models
{
    [Table("__PROTransmogrificationHistory")]
    public class TransmogrificationHistory
    {
        [Key]
        public string TransmogrificationId { get; set; }

        public string ProductVersion { get; set; }

        public DateTime AppliedAt { get; set; }
    }
}