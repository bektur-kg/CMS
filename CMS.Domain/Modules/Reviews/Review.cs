using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Reviews;

public class Review : Entity
{
    public long? PatientId { get; set; }

    public long DoctorId { get; set; }

    [Range(ReviewAttributeConstants.RatingMinValue, ReviewAttributeConstants.RatingMaxValue)]
    public byte Rating { get; set; }

    [MaxLength(ReviewAttributeConstants.CommentMaxLength)]
    public string? Comment { get; set; }

    public DateTime CreatedDate { get; set; }

    public User? Patient { get; set; }

    public User? Doctor { get; set; }
}