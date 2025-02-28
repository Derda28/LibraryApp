using FluentAssertions;
using Newtonsoft.Json;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.IntegrationTests.CourseTests;
internal class UpdateCourseTests : IntegrationTestBase
{
    public UpdateCourseTests() : base()
    { }

    [Test]
    public async Task UpdateCourse_WhenCalled_ReturnsCorrectUpdatedCourse()
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

        var updatedCourse = new Course
        {
            ID = courseList[0].ID,
            Title = "testUpdate",
            Credits = 4
        };

        var json = JsonConvert.SerializeObject(updatedCourse);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PutAsync("/courses/" + courseList[0].ID, content);
        var response2 = await client.GetAsync("/courses/" + courseList[0].ID);

        var result = await response2.Content.ReadAsStringAsync();
        var responseCourse = JsonConvert.DeserializeObject<Course>(result);

        responseCourse!
            .Should()
            .BeEquivalentTo(courseList[0],
                options => options
                    .Excluding(s => s.Enrollments));

    }
}
