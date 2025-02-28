using QimiaSchool.Business.Abstracts;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.Repositories.Abstractions;
using QimiaSchool.DataAccess.Repositories.Implementations;

namespace QimiaSchool.Business.Implementations;

public class CourseManager : ICourseManager
{
    private readonly ICourseRepository _courseRepository;
    public CourseManager(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Task CreateCourseAsync(
        Course course,
        CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        course.ID = default;

        return _courseRepository.CreateAsync(course, cancellationToken);
    }

    public Task DeleteCourseAsync(int courseId, CancellationToken cancellationToken)
    {
        return _courseRepository.DeleteAsync(courseId, cancellationToken);
    }

    public Task<Course> GetCourseByIdAsync(
        int courseId,
        CancellationToken cancellationToken)
    {
        return _courseRepository.GetByIdAsync(courseId, cancellationToken);
    }

    public async Task<List<Course>> GetCoursesAsync(CancellationToken cancellationToken)
    {
        return await _courseRepository.GetAllAsync(cancellationToken);
    }

    public Task UpdateCourseAsync(int courseId, Course course, CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        course.ID = courseId;

        return _courseRepository.UpdateAsync(course, cancellationToken);
    }
}
