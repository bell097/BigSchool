namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LectureId { get; set; }

        [Required(ErrorMessage ="Địa điểm không được để trống")]
        [StringLength(100, ErrorMessage ="Địa điểm không được quá 100 ký tự")]
        [Display(Name ="Địa điểm")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Ngày giờ không được để trống")]
        [Display(Name = "Ngày giờ")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Môn học không được để trống")]
        [Display(Name = "Môn học")]
        public int CategoryId { get; set; }

        public List<Category> ListCategory = new List<Category>();
        public String Name;
    }
}
