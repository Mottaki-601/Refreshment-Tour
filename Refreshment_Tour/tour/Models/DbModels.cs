using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = default!;

        [Required, StringLength(20)]
        public string RollNo { get; set; } = default!;

        [Display(Name = "Department")]
        public int CourseId { get; set; }

        public Course? Course { get; set; }

        public string? Image { get; set; }

        [Required, Display(Name = "Tk.")]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public bool PaymentDone { get; set; }

        public int EventId { get; set; }

        public Event? Event { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; } = default!;

        public ICollection<Member> Members { get; set; } = new List<Member>();
    }

    public class Cost
    {
        public int CostId { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Cost Item")]
        public string CostItem { get; set; } = default!;

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Cost Date")]
        public DateTime CostDate { get; set; }

        [Required]
        [Precision(18, 2)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Amount (Tk.)")]
        public decimal CostAmount { get; set; }

        public int EventId { get; set; }

        public Event? Event { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; } = default!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Member> Members { get; set; } = new List<Member>();

        public ICollection<Cost> Costs { get; set; } = new List<Cost>();
    }

    public class TourDbContext : DbContext
    {
        public TourDbContext(DbContextOptions<TourDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}