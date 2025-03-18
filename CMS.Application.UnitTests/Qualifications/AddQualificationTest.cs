using AutoMapper;
using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Features.DoctorProfiles;
using CMS.Application.Features.Qualifications.Add;
using CMS.Application.Features.Users;
using CMS.Domain.Modules.DoctorProfiles;
using CMS.Domain.Modules.Qualifications;
using FluentAssertions;
using NSubstitute;

namespace CMS.Application.UnitTests.Qualifications;

public class AddQualificationTest
{
    private readonly AddQualificationCommand _command = new(new()
    {
        Name = "BSc Medicine",
        QualificationType = QualificationType.Education,
        IssuingAuthority = "University of Example",
        DateObtained = new DateTime(2020, 6, 1),
        ExpiryDate = null,
        Description = "Bachelor of Science in Medicine",
        Level = "Graduated"
    });

    private readonly IDoctorProfileRepository _doctorProfileRepositoryMock;
    private readonly IUserContext _userContextMock;
    private readonly IMapper _mapperMock;
    private readonly IUnitOfWork _unitOfWorkMock;
    private readonly AddQualificationCommandHandler _handler;

    public AddQualificationTest()
    {
        _doctorProfileRepositoryMock = Substitute.For<IDoctorProfileRepository>();
        _userContextMock = Substitute.For<IUserContext>();
        _mapperMock = Substitute.For<IMapper>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _handler = new AddQualificationCommandHandler(_doctorProfileRepositoryMock, _userContextMock, _mapperMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenDoctorProfileIsNull()
    {
        // Arrange
        _userContextMock.GetUserId().Returns(1);
        _doctorProfileRepositoryMock.GetByUserIdAsync(1, Arg.Any<CancellationToken>()).Returns((DoctorProfile?)null);

        // Act
        var result = await _handler.Handle(_command, default);

        // Assert
        result.Error.Should().Be(UserErrors.UserNotFoundById);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_QualificationIsAdded()
    {
        // Arrange
        var userId = 1L;
        var doctorProfile = new DoctorProfile 
        {
            UserId = userId,
            Qualifications = [],
            Bio = "Doctor Bio"
        };
        var qualification = new Qualification
        {
            Name = _command.Data.Name,
            QualificationType = _command.Data.QualificationType,
            IssuingAuthority = _command.Data.IssuingAuthority,
            DateObtained = _command.Data.DateObtained,
            ExpiryDate = _command.Data.ExpiryDate,
            Description = _command.Data.Description,
            Level = _command.Data.Level
        };

        _userContextMock.GetUserId().Returns(userId);
        _doctorProfileRepositoryMock.GetByUserIdAsync(userId, Arg.Any<CancellationToken>())
            .Returns(doctorProfile);

        _mapperMock.Map<Qualification>(_command.Data).Returns(qualification);

        // Act
        var result = await _handler.Handle(_command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        doctorProfile.Qualifications.Should().Contain(qualification);
    }
}
