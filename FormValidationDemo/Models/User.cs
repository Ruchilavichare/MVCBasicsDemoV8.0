using System.ComponentModel.DataAnnotations;

namespace FormValidationDemo.Models
{
    public class User
    {
        // Required field with custom error message
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        // Email validation
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        // Range validation for age
        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        // Regular expression validation for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        // Password validation with minimum length
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        // Compare validation to ensure passwords match
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        // Date of Birth validation (must be a past date)
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [CustomValidation(typeof(User), "ValidateDateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        // Custom validation method for Date of Birth
        public static ValidationResult ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext context)
        {
            if (dateOfBirth > DateTime.Now)
            {
                return new ValidationResult("Date of Birth cannot be in the future");
            }
            return ValidationResult.Success;
        }

        // URL validation
        [Url(ErrorMessage = "Invalid URL")]
        public string Website { get; set; }

        // Credit card validation
        [CreditCard(ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }

        // Enum validation (e.g., Gender)
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        // Boolean validation (e.g., Terms and Conditions)
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions")]
        public bool AcceptTerms { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
//Explanation of Data Annotations
//[Required]: Ensures the field is not empty.

//[StringLength]: Specifies the minimum and maximum length of a string.

//[EmailAddress]: Validates that the input is a valid email address.

//[Range]: Validates that the input falls within a specified range (e.g., age between 18 and 100).

//[RegularExpression]: Validates the input against a regular expression (e.g., phone number format).

//[MinLength]: Ensures the input has a minimum length (e.g., password must be at least 8 characters).

//[Compare]: Compares two fields (e.g., Password and ConfirmPassword).

//[DataType]: Specifies the type of data (e.g., DataType.Date for date fields).

//[Url]: Validates that the input is a valid URL.

//[CreditCard]: Validates that the input is a valid credit card number.

//[Enum]: Validates that the input is a valid enum value.

//[CustomValidation]: Allows you to define custom validation logic (e.g., ValidateDateOfBirth).
