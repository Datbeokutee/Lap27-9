using System.ComponentModel.DataAnnotations;

namespace MyWebAppLab1.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên

        [Required(ErrorMessage = "Họ tên bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có ít nhất 4 ký tự và tối đa 100 ký tự")]
        [Display(Name = "Họ tên")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Địa chỉ email phải có đuôi gmail.com")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc phải được nhập")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)[A-Za-z\d\W]{8,}$", ErrorMessage = "Mật khẩu từ 8 ký tự trở lên, phải có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ngành học bắt buộc phải được chọn")]
        [Display(Name = "Ngành học")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc phải được chọn")]
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ ĐT")]
        public bool IsRegular { get; set; } // Hệ: true-chính quy, false-phi chính quy

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "01/01/1963", "31/12/2005", ErrorMessage = "Ngày sinh phải nằm trong khoảng từ 01/01/1963 đến 31/12/2005")]
        public DateTime DateOfBorth { get; set; }

        [Required(ErrorMessage = "Điểm bắt buộc phải được nhập")]
        [Display(Name = "Điểm")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        public decimal? Score { get; set; } // Điểm
    }
}
