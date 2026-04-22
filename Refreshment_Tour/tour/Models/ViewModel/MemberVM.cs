using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.Models.ViewModel
{
    public class MemberVM
    {
        public int MemberId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, StringLength(20)]
        public string RollNo { get; set; } = default!;

        [Display(Name = "Department")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public bool PaymentDone { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }


        public List<int> CourseList { get; set; } = new List<int>();
    }
}
