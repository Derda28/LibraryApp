using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Abstracts;

public interface ICourseManager
{
    public Task CreateCourseAsync(
        Course course,
        CancellationToken cancellationToken);

    public Task<Course> GetCourseByIdAsync(
        int courseId,
        CancellationToken cancellationToken);

    public Task<List<Course>> GetCoursesAsync(
        CancellationToken cancellationToken);

    public Task UpdateCourseAsync(
        int courseId,
        Course course,
        CancellationToken cancellationToken);

    public Task DeleteCourseAsync(
        int courseId,
        CancellationToken cancellationToken);


}
