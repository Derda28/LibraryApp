using FluentAssertions;
using Newtonsoft.Json;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using QimiaSchool.DataAccess.Entities;
using System.Net;

namespace QimiaSchool.IntegrationTests.EnrollmentTests;
internal class GetEnrollmentByIdTests : IntegrationTestBase
{
    public GetEnrollmentByIdTests() : base() { }

    [Test]
    public async Task GetEnrollmentById_WhenCalled_ReturnsCorrectEnrollment()
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

        // Arrange
        var enrollmentList = new List<Enrollment>()
        {
            new ()
            {
                CourseID = courseList[0].ID,
                StudentID = studentList[0].ID,
                Grade = Grade.A,
            },
            new ()
            {
                CourseID = courseList[1].ID,
                StudentID = studentList[1].ID,
                Grade = Grade.A,
            },
        };

        databaseContext.Enrollments.AddRange(enrollmentList);
        await databaseContext.SaveChangesAsync();

        // Act
        var response = await client.GetAsync("/enrollments/" + enrollmentList[0].ID);
        var result = await response.Content.ReadAsStringAsync();
        var responseEnrollment = JsonConvert.DeserializeObject<EnrollmentDto>(result);

        // Assert
        responseEnrollment
            .Should()
            .BeEquivalentTo(enrollmentList[0],
                options => options
                    .Excluding(s => s.Student)
                    .Excluding(s => s.Course));
    }

    [Test]
    public async Task GetEnrollments_WhenEnrollmentISNotExist_ReturnsNotFound()
    {
        // Act
        var response = await client.GetAsync("/enrollment/NonExistingId");

        // Assert
        response
            .StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }


}
