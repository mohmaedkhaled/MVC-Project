using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ASPDay4.Models
{
    [Table("client")]
    public class user
    {
        [Display(Name ="user id")]
        public int id { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name = "Full Name")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="short name")]
        public string name { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(20,60,ErrorMessage ="age must between 20 and 60")]
        public int? age { get; set; }
        //[DataType(DataType.)]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",ErrorMessage ="invalid Email")]
        public string email { get; set; }
        public string password { get; set; }
        [NotMapped]
        [Compare("password",ErrorMessage ="password not match")]
        public string confirm_password { get; set; }

        public string photo { get; set; }
        public virtual List<news> News { get; set; }
        [ForeignKey("Department")]
        public int? dept_id { get; set; }
        public department Department { get; set; }

    }
}