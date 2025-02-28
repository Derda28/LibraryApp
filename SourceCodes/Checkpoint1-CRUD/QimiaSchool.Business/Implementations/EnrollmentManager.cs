using QimiaSchool.Business.Abstracts;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.Repositories.Abstractions;
using QimiaSchool.DataAccess.Repositories.Implementations;

namespace QimiaSchool.Business.Implementations;

public class EnrollmentManager : IEnrollmentManager
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public Task CreateEnrollmentAsync(
        Enrollment enrollment,
        CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        enrollment.ID = default;

        return _enrollmentRepository.CreateAsync(enrollment, cancellationToken);
    }

    public Task DeleteEnrollmentAsync(int enrollmentId, CancellationToken cancellationToken)
    {
        return _enrollmentRepository.DeleteAsync(enrollmentId, cancellationToken);
    }

    public Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId, CancellationToken cancellationToken)
    {
        return _enrollmentRepository.GetByIdAsync(enrollmentId, cancellationToken);
    }

    public async Task<List<Enrollment>> GetEnrollmentsAsync(CancellationToken cancellationToken)
    {
        return await _enrollmentRepository.GetAllAsync(cancellationToken);
    }

    public Task UpdateEnrollmentAsync(int enrollmentId, Enrollment enrollment, CancellationToken cancellationToken)
    {
        enrollment.ID = enrollmentId;

        return _enrollmentRepository.UpdateAsync(enrollment, cancellationToken);
    }
}
