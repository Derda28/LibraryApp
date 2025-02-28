using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace QimiaSchool.IntegrationTests.EnrollmentTests
{
    internal class GetEnrollmentsTests : IntegrationTestBase
    {
        public GetEnrollmentsTests() : base()
        {
        }

        [Test]
        public async Task GetEnrollments_WhenCalled_ReturnsAllEnrollments()
        {
            // Arrange
            var studentList = new List<Student>()
            {
                new Student
                {
                    EnrollmentDate = DateTime.Now,
                    FirstMidName = "Test1",
                    LastName = "Test1",
                },
                new Student
                {
                    EnrollmentDate = DateTime.Now,
                    FirstMidName = "Test2",
                    LastName = "Test2",
                }
            };

            databaseContext.Students.AddRange(studentList);
            await databaseContext.SaveChangesAsync();

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

            var enrollmentList = new List<Enrollment>()
            {
                new Enrollment
                {
                    StudentID = studentList[0].ID,
                    CourseID = courseList[0].ID,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    StudentID = studentList[1].ID,
                    CourseID = courseList[1].ID,
                    Grade = Grade.A
                }
            };

            databaseContext.Enrollments.AddRange(enrollmentList);
            await databaseContext.SaveChangesAsync();

            // Act
            var response = await client.GetAsync("/enrollments");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var responseEnrollments = JsonConvert.DeserializeObject<List<EnrollmentDto>>(result);

            // Assert
            responseEnrollments.Should().BeEquivalentTo(enrollmentList, options => options
                .Excluding(e => e.Student)
                .Excluding(e => e.Course));
        }
    }
}