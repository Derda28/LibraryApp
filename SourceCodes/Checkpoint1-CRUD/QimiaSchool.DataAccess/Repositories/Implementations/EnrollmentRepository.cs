using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.Repositories.Abstractions;

namespace QimiaSchool.DataAccess.Repositories.Implementations;

public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(QimiaSchoolDbContext dbContext) : base(dbContext)
    {

    }
}
