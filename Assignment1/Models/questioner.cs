namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("questioner")]
    public partial class questioner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public questioner()
        {
            question = new HashSet<question>();
        }

        [Key]
        [Display(Name = "Questioner ID")]
        public int questioner_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string phone_number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string email_address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<question> question { get; set; }
    }
}
