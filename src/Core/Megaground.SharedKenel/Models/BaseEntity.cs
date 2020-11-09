using System;
using System.ComponentModel.DataAnnotations;

namespace Megaground.SharedKenel.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }
        [StringLength(50)]
        public string UpdatedByUserId { set; get; }
    }
}
