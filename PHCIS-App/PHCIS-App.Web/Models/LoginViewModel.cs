using System.ComponentModel.DataAnnotations;

namespace PHCISApp.Web.Models
{
    public class LoginViewModel
{
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please provide UserName")]
        public string? UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Password")]
        public string? Password { get; set; }
    }
}
