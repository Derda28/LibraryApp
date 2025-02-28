using FluentAssertions;
using Newtonsoft.Json;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.IntegrationTests.StudentTests;
internal class UpdateStudentTests : IntegrationTestBase
{
    public UpdateStudentTests() : base()
    { }

    [Test]
    public async Task UpdateStudent_WhenCalled_ReturnsCorrectUpdatedStudent()
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


        studentList[0].FirstMidName = "TestUpdate";
        studentList[0].LastName = "TestUpdate";

        var json = JsonConvert.SerializeObject(studentList[0]);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PutAsync("/students/" + studentList[0].ID, content);
        var response2 = await client.GetAsync("/students/" + studentList[0].ID);

        var result = await response2.Content.ReadAsStringAsync();
        var responseStudent = JsonConvert.DeserializeObject<Student>(result);

        responseStudent
            .Should()
            .BeEquivalentTo(studentList[0],
                options => options
                    .Excluding(s => s.Enrollments)
                    .Excluding(s => s.EnrollmentDate));

    }
}
