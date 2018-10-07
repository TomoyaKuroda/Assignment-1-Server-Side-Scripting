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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int question_id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(1000)]
        public string contents_of_question { get; set; }
        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int questioner_id { get; set; }

        public virtual questioner questioner { get; set; }
    }
}
