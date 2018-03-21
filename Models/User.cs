using System;
using System.ComponentModel.DataAnnotations;

namespace login_registration.Models{
public class User: BaseEntity{
      public int UserId { get; set; }

      [Required]
      [MinLength(2)]
      [RegularExpression(@"^[a-zA-Z]+$")]
      public string FirstName { get; set; }

      [Required]
      [MinLength(2)]
      [RegularExpression(@"^[a-zA-Z]+$")]
      public string LastName { get; set; }

      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [MinLength(8)]
      public string Password { get; set; }

      [Compare("Password", ErrorMessage = "Password confirmation must match Password")]
      public string PasswordConfirmation { get; set; }
  }
}
