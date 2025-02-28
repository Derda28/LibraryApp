using FluentAssertions;
using Newtonsoft.Json;
using QimiaSchool.Business.Implementations.Queries.Courses.Dtos;
using QimiaSchool.DataAccess.Entities;
using System.Net;

namespace QimiaSchool.IntegrationTests.CourseTests;
internal class GetCourseByIdTests : IntegrationTestBase
{
    public GetCourseByIdTests() : base()
    {
    }

    [Test]
    public async Task GetCourseById_WhenCalled_ReturnsCorrectCourse()
    {
        // Arrange
        var courseList = new List<Course>()
        {
            new ()
            {
                Title = "test",
                Credits = 6,
            },
            new ()
            {
                Title = "test2",
                Credits = 2,
            }
        };

        databaseContext.Courses.AddRange(courseList);
        await databaseContext.SaveChangesAsync();

        // Act
        var response = await client.GetAsync("/courses/" + courseList[0].ID);
        var result = await response.Content.ReadAsStringAsync();
        var responseCourse = JsonConvert.DeserializeObject<CourseDto>(result);

        // Assert
        responseCourse
            .Should()
            .BeEquivalentTo(courseList[0],
                options => options
                    .Excluding(s => s.Enrollments));
    }

    [Test]
    public async Task GetCourses_WhenCourseISNotExist_ReturnsNotFound()
    {
        // Act
        var response = await client.GetAsync("/course/NonExistingId");

        // Assert
        response
            .StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }
}
