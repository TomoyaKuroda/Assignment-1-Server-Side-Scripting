namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("question")]
    public partial class question
    {
        [Key]
        [Display(Name = "Question ID")]
        public int question_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Contents of Question")]
        public string contents_of_question { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Deadline")]
        public DateTime? date { get; set; }

        public int questioner_id { get; set; }

        public virtual questioner questioner { get; set; }
    }
}
