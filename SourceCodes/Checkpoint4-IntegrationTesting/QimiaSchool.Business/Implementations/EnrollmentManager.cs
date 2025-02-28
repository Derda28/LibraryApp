using QimiaSchool.Business.Abstracts;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.Repositories.Abstractions;
using QimiaSchool.DataAccess.Repositories.Implementations;
using Serilog;

namespace QimiaSchool.Business.Implementations;

public class EnrollmentManager : IEnrollmentManager
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly Serilog.ILogger _enrollmentLogger;
    public EnrollmentManager(IEnrollmentRepository enrollmentRepository, ILogger enrollmentLogger)
    {
        _enrollmentRepository = enrollmentRepository;
        _enrollmentLogger = enrollmentLogger;
    }

    public Task CreateEnrollmentAsync(
        Enrollment enrollment,
        CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        enrollment.ID = default;

        // Serilog with context
        _enrollmentLogger.Information(
            "Create enrollment request is accepted. Enrollment:{@enrollment}",
            enrollment);

        return _enrollmentRepository.CreateAsync(enrollment, cancellationToken);
    }

    public Task DeleteEnrollmentAsync(int enrollmentId, CancellationToken cancellationToken)
    {

        // Serilog with context
        _enrollmentLogger.Information(
            "Delete enrollment request is accepted. EnrollmentId:{@enrollmentId}",
            enrollmentId);
        return _enrollmentRepository.DeleteAsync(enrollmentId, cancellationToken);
    }

    public Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId, CancellationToken cancellationToken)
    {

        // Serilog with context
        _enrollmentLogger.Information(
            "Get enrollment by id request is accepted. EnrollmentId:{@enrollmentId}",
            enrollmentId);
        return _enrollmentRepository.GetByIdAsync(enrollmentId, cancellationToken);
    }

    public async Task<List<Enrollment>> GetEnrollmentsAsync(CancellationToken cancellationToken)
    {

        // Serilog with context
        _enrollmentLogger.Information(
            "Get enrollments request is accepted.");
        return await _enrollmentRepository.GetAllAsync(cancellationToken);
    }

    public Task UpdateEnrollmentAsync(int enrollmentId, Enrollment enrollment, CancellationToken cancellationToken)
    {
        enrollment.ID = enrollmentId;

        // Serilog with context
        _enrollmentLogger.Information(
            "Update enrollment request is accepted. Enrollment:{@enrollment}",
            enrollment);

        return _enrollmentRepository.UpdateAsync(enrollment, cancellationToken);
    }
}
