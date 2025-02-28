using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Abstracts;

public interface IEnrollmentManager
{
    Task CreateEnrollmentAsync(
        Enrollment enrollment,
        CancellationToken cancellationToken);

    Task<Enrollment> GetEnrollmentByIdAsync(
        int enrollmentId,
        CancellationToken cancellationToken);

    Task<List<Enrollment>> GetEnrollmentsAsync(    
        CancellationToken cancellationToken);

    Task UpdateEnrollmentAsync(
        int enrollmentId,
        Enrollment enrollment,
        CancellationToken cancellationToken);

    Task DeleteEnrollmentAsync(
        int enrollmentId,
        CancellationToken cancellationToken);
}
