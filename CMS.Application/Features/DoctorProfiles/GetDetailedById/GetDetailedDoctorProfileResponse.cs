﻿using CMS.Application.CommonContracts;
using CMS.Domain.Modules.DoctorProfiles;

namespace CMS.Application.Features.DoctorProfiles.GetDetailedById;

public record GetDetailedDoctorProfileResponse
{
    public long Id { get; set; }

    public SpecializationType SpecializationType { get; set; }

    public required string Bio { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Patronymic { get; set; }

    public required string Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<QualificationResponse> Qualifications { get; set; } = [];

    public List<TimeSlotResponse> TimeSlots { get; set; } = [];
}
