using QimiaSchool.Business.Abstracts;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.Repositories.Abstractions;
using Serilog;

namespace QimiaSchool.Business.Implementations;

public class CourseManager : ICourseManager
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILogger _courseLogger;
    public CourseManager(ICourseRepository courseRepository, ILogger courseLogger)
    {
        _courseRepository = courseRepository;
        _courseLogger = courseLogger;
    }

    public Task CreateCourseAsync(
        Course course,
        CancellationToken cancellationToken)
    {
        // No id should be provided while insert.
        course.ID = default;

        // Serilog with context
        _courseLogger.Information(
            "Create course request is accepted. Course:{@course}",
            course);

        return _courseRepository.CreateAsync(course, cancellationToken);
    }

    public Task DeleteCourseAsync(int courseId, CancellationToken cancellationToken)
    {

        // Serilog with context
        _courseLogger.Information(
            "Delete course request is accepted. CourseId:{@courseId}",
            courseId);
        return _courseRepository.DeleteAsync(courseId, cancellationToken);
    }

    public Task<Course> GetCourseByIdAsync(
        int courseId,
        CancellationToken cancellationToken)
    {

        // Serilog with context
        _courseLogger.Information(
            "Get course by id request is accepted. CourseId:{@courseId}",
            courseId);
        return _courseRepository.GetByIdAsync(courseId, cancellationToken);
    }

    public async Task<List<Course>> GetCoursesAsync(CancellationToken cancellationToken)
    {

        // Serilog with context
        _courseLogger.Information(
            "Get courses request is accepted");
        return await _courseRepository.GetAllAsync(cancellationToken);
    }

    public Task UpdateCourseAsync(int courseId, Course course, CancellationToken cancellationToken)
    {

        // Serilog with context
        _courseLogger.Information(
            "Update course request is accepted. Course:{@course}",
            course);
        // No id should be provided while insert.
        course.ID = courseId;

        return _courseRepository.UpdateAsync(course, cancellationToken);
    }
}
