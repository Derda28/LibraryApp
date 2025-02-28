using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using QimiaSchool.Business.Implementations.Queries.Courses.Dtos;
using QimiaSchool.DataAccess.Entities;
using System.Net;

namespace QimiaSchool.IntegrationTests.CourseTests;

internal class DeleteCourseTests : IntegrationTestBase
{
    public DeleteCourseTests() : base()
    {
    }

    [Test]
    public async Task DeleteCourse_WhenCalled_ReturnsCorrectCourse()
    {
        // Arrange
        var CourseList = new List<Course>()
        {
            new ()
            {
                  Credits = 2,
                Title = "Test"
            },
            new ()
            {
                  Credits = 2,
                Title = "Test"
            }
        };

        databaseContext.Courses.AddRange(CourseList);
        await databaseContext.SaveChangesAsync();

        // Act
        var response = await client.DeleteAsync("/Courses/" + CourseList[0].ID);
        var response2 = await client.GetAsync("/Courses/" + CourseList[0].ID);


        // Assert error message or status code 500
        var contentString = await response2.Content.ReadAsStringAsync();
        contentString.Should().Contain("QimiaSchool.DataAccess.Exceptions.EntityNotFoundException");


        // Assert
        response
            .StatusCode
            .Should()
            .Be(HttpStatusCode.NoContent);//204


        // Assert

    }

    [Test]

    public async Task DeleteCourses_WhenCourseISNotExist_ReturnsNotFound()
    {
        // Act
        var response = await client.DeleteAsync("/Course/NonExistingId");

        // Assert
        response
            .StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

}