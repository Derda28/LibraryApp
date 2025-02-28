using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Implementations.Handlers.Enrollments.Commands;
public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, int>
{
    private readonly IEnrollmentManager _enrollmentManager;
    private readonly IStudentManager _studentManager;
    private readonly ICourseManager _courseManager;

    public CreateEnrollmentCommandHandler(IEnrollmentManager enrollmentManager, IStudentManager studentManager, ICourseManager courseManager)
    {
        _enrollmentManager = enrollmentManager;
        _studentManager = studentManager;
        _courseManager = courseManager;
    }

    public async Task<int> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentManager.GetStudentByIdAsync(request.Enrollment.StudentID, cancellationToken);

        var course = await _courseManager.GetCourseByIdAsync(request.Enrollment.CourseID, cancellationToken);
        var enrollment = new Enrollment
        {
            Grade = request.Enrollment.Grade,
            Student = student,
            Course = course,
        };

        await _enrollmentManager.CreateEnrollmentAsync(enrollment, cancellationToken);

        return enrollment.ID;
    }
}
