using System;
using Moq;
using NUnit.Framework;
using TaskManager.Tracker.Contracts;

namespace TaskManager.Tracker.UnitTests;

[TestFixture]
public sealed class TaskValidationServiceTests
{
    private TaskValidationService _taskValidationService;

    private Mock<IDateTimeProvider> _dateTimeProviderMock;

    [SetUp]
    public void SetUp()
    {
        _dateTimeProviderMock = new Mock<IDateTimeProvider>();
        _taskValidationService = new TaskValidationService(_dateTimeProviderMock.Object);
    }
        
    [Test]
    public void Title_ShouldBe_Set()
    {
        var requestDto = new CreateTaskRequestDto(
            string.Empty, 
            "Test Description",
            DateTime.Now.AddDays(1),
            false);

        var errors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
            
        Assert.Contains("The title is required.", errors);
    }
        
    [Test]
    public void Description_ShouldBe_Set()
    {
        var requestDto = new CreateTaskRequestDto(
            "Test Title", 
            string.Empty,
            DateTime.Now.AddDays(1), 
            false);

        var errors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
            
        Assert.Contains("The description is required.", errors);
    }
        
    [Test]
    public void Date_ShouldBe_InTheFuture()
    {
        _dateTimeProviderMock.Setup(provider => provider.Now).Returns(DateTime.Now);
            
        var requestDto = new CreateTaskRequestDto(
            "Test Title", 
            "Test Description",
            DateTime.Now.AddDays(-1),
            false);

        var errors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
            
        Assert.Contains("The date should be in the future.", errors);
    }
        
    [Test]
    public void Request_ShouldBe_Initialized()
    {
        var errors = _taskValidationService.ValidateCreateTaskRequest(null);
            
        Assert.Contains("The request must be initialized.", errors);
    }
        
    [Test]
    public void Title_ShouldHave_ValidLength()
    {
        var requestDto = new CreateTaskRequestDto(
            new string('T', 1000),
            "Test Description",
            DateTime.Now.AddDays(1),
            false);
            
        var errors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
            
        Assert.Contains("The title should not exceed 250 characters.", errors);
    }
        
    [Test]
    public void Description_ShouldHave_ValidLength()
    {
        var requestDto = new CreateTaskRequestDto(
            "Test Title",
            new string('T', 2000),
            DateTime.Now.AddDays(1),
            false);
            
        var errors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
            
        Assert.Contains("The description should not exceed 1000 characters.", errors);
    }
        
    [Test]
    public void Request_Is_Valid()
    {
        var requestDto = new CreateTaskRequestDto(
            "Test Title", 
            "Test Description",
            DateTime.Now.AddDays(1),
            false);
            
        var errors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
            
        Assert.IsEmpty(errors);
    }
}