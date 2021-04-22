namespace SecureDemoApi.CommonCode.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The email data transfer object.
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [Required(ErrorMessage = "Enter email address")]
        [EmailAddress(ErrorMessage = "This is not a valid  email address")]
        public string EmailAddress { get; set; }
    }
}
