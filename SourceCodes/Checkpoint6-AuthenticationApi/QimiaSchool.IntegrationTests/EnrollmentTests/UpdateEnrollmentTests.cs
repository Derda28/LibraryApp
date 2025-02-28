using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.IntegrationTests.EnrollmentTests
{
    internal class UpdateEnrollmentTests : IntegrationTestBase
    {
        public UpdateEnrollmentTests() : base()
        { }

        [Test]
        public async Task UpdateEnrollment_WhenCalled_ReturnsCorrectUpdatedEnrollment()
        {
            // Arrange
            var studentList = new List<Student>()
            {
                new Student
                {
                    EnrollmentDate = DateTime.Now,
                    FirstMidName = "Test",
                    LastName = "Test",
                },
                new Student
                {
                    EnrollmentDate = DateTime.Now,
                    FirstMidName = "Test",
                    LastName = "Test",
                }
            };

            databaseContext.Students.AddRange(studentList);
            await databaseContext.SaveChangesAsync();

            var courseList = new List<Course>()
            {
                new Course
                {
                    Credits = 2,
                    Title = "Test"
                },
                new Course
                {
                    Credits = 2,
                    Title = "Test"
                }
            };

            databaseContext.Courses.AddRange(courseList);
            await databaseContext.SaveChangesAsync();

            var enrollmentList = new List<Enrollment>()
            {
                new Enrollment
                {
                    CourseID =  courseList[0].ID,
                    StudentID = studentList[0].ID,
                    Grade=Grade.A,
                },
                new Enrollment
                {
                   CourseID =  courseList[0].ID,
                   StudentID = studentList[0].ID,
                   Grade=Grade.A,
                },
            };

            enrollmentList[0].StudentID = studentList[1].ID;
            enrollmentList[0].CourseID = courseList[1].ID;
            enrollmentList[0].Grade = Grade.B;

            // Save the initial enrollment to the database
            databaseContext.Enrollments.AddRange(enrollmentList);
            await databaseContext.SaveChangesAsync();

            // Update the enrollment
            var updatedEnrollment = enrollmentList[0];
            updatedEnrollment.StudentID = studentList[1].ID;
            updatedEnrollment.CourseID = courseList[1].ID;

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var json = JsonConvert.SerializeObject(updatedEnrollment, jsonSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/enrollments/{updatedEnrollment.ID}", content);
            response.EnsureSuccessStatusCode();

            var updatedEnrollmentFromDb = await databaseContext.Enrollments.FindAsync(updatedEnrollment.ID);

            // Assert
            updatedEnrollmentFromDb.StudentID.Should().Be(updatedEnrollment.StudentID);
            updatedEnrollmentFromDb.CourseID.Should().Be(updatedEnrollment.CourseID);
            updatedEnrollmentFromDb.Grade.Should().Be(updatedEnrollment.Grade);
        }
    }
}