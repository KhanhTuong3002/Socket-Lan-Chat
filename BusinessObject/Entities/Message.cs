using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class Message : BaseEntity
    {
        [ForeignKey(nameof(AppUser))]
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public string? UserName { get; set; }
        public string? Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;

        public virtual AppUser Sender { get; set; } = null!;
    }
}
