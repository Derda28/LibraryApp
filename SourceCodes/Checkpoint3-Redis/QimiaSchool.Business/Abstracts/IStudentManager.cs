using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Abstracts;

public interface IStudentManager
{
    Task CreateStudentAsync(
        Student student,
        CancellationToken cancellationToken);

    Task<Student> GetStudentByIdAsync(
        int studentId,
        CancellationToken cancellationToken);

    Task<List<Student>> GetStudentsAsync(
        CancellationToken cancellationToken);

    Task UpdateStudentAsync(
        int studentId,
        Student student,
        CancellationToken cancellationToken);

    Task DeleteStudentAsync(
        int studentId,
        CancellationToken cancellationToken);
}
