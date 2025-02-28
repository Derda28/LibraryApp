using QimiaSchool.Business.Abstracts;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.Repositories.Abstractions;

namespace QimiaSchool.Business.Implementations;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepository _studentRepository;
    public StudentManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task CreateStudentAsync(
        Student student,
        CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        student.ID = default;


        return _studentRepository.CreateAsync(student, cancellationToken);
    }

    public Task<Student> GetStudentByIdAsync(
        int studentId,
        CancellationToken cancellationToken)
    {
        return _studentRepository.GetByIdAsync(studentId, cancellationToken);
    }

    public async Task<List<Student>> GetStudentsAsync(CancellationToken cancellationToken)
    {
        return await _studentRepository.GetAllAsync(cancellationToken);
    }

    public Task UpdateStudentAsync(
        int studentId,
        Student student,
        CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        student.ID = studentId;

        return _studentRepository.UpdateAsync(student, cancellationToken);
    }

    public Task DeleteStudentAsync(
    int studentId,
    CancellationToken cancellationToken)
    {
        return _studentRepository.DeleteAsync(studentId, cancellationToken);
    }
}
