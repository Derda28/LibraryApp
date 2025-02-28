using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using QimiaSchool.DataAccess.Entities;
using System.Net;
using System;
using System.Collections.Generic;//These directives are required for the classes and types used in your code, such as List<T>, DateTime, Task, and Task<T>. Adding these directives should resolve the compilation errors.
using System.Threading.Tasks;


namespace QimiaSchool.IntegrationTests.EnrollmentTests;

internal class DeleteEnrollmentTests : IntegrationTestBase
{
    public DeleteEnrollmentTests() : base()
    {
    }

    [Test]
    public async Task DeleteEnrollment_WhenCalled_ReturnsCorrectEnrollment()
    {
        // Arrange
        var studentList = new List<Student>()
        {
            new ()
            {
                EnrollmentDate = DateTime.Now,
                FirstMidName = "Test",
                LastName = "Test",
            },
            new ()
            {
                EnrollmentDate = DateTime.Now,
                FirstMidName = "Test",
                LastName = "Test",
            }
        };

        databaseContext.Students.AddRange(studentList);
        await databaseContext.SaveChangesAsync();

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
        var EnrollmentList = new List<Enrollment>()
        {
            new ()
            {
               StudentID=studentList[0].ID,
                     CourseID=CourseList[0].ID,
                    Grade=Grade.A
            },
            new ()
            {
                StudentID=studentList[0].ID,
                     CourseID=CourseList[0].ID,
                    Grade=Grade.A
            }
        };

        databaseContext.Enrollments.AddRange(EnrollmentList);
        await databaseContext.SaveChangesAsync();

        // Act
        var response = await client.DeleteAsync("/Enrollments/" + EnrollmentList[0].ID);
        var response2 = await client.GetAsync("/Enrollments/" + EnrollmentList[0].ID);


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

    public async Task DeleteEnrollments_WhenEnrollmentISNotExist_ReturnsNotFound()
    {
        // Act
        var response = await client.DeleteAsync("/Enrollment/NonExistingId");

        // Assert
        response
            .StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

}