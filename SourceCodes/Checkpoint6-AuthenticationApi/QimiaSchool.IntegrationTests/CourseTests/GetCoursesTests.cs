using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using QimiaSchool.Business.Implementations.Queries.Courses.Dtos;
using QimiaSchool.DataAccess.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace QimiaSchool.IntegrationTests.CourseTests
{
    internal class GetCoursesTests : IntegrationTestBase
    {
        public GetCoursesTests() : base()
        {
        }

        [Test]
        public async Task GetCourses_WhenCalled_ReturnsAllCourses()
        {
            // Arrange
            var courseList = new List<Course>()
            {
                new Course
                {
                    Credits = 2,
                    Title = "Test1"
                },
                new Course
                {
                    Credits = 2,
                    Title = "Test2"
                }
            };

            databaseContext.Courses.AddRange(courseList);
            await databaseContext.SaveChangesAsync();

            // Act
            var response = await client.GetAsync("/courses");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var responseCourses = JsonConvert.DeserializeObject<List<CourseDto>>(result);

            // Assert
            responseCourses.Should().BeEquivalentTo(courseList, options => options
                .Excluding(c => c.Enrollments));
        }
    }
}