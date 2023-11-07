using FluentAssertions;
using Shared.Mvvm;

namespace Shared.Tests.Unit.Mvvm;

public class ViewModelBaseTests
{
    [Fact]
    public void GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var vm = new TestViewModelBase() { Name = "Test" };

        //Act

        //Assert
        vm.Name.Should().Be("Test");
    }

    [Fact]
    public void SetValue_ShouldSetThePropertyValue_WhenCalled()
    {
        //Arrange
        var vm = new TestViewModelBase() { Name = "Test" };

        //Act
        vm.Name = "My Test";

        //Assert
        vm.Name.Should().Be("My Test");
    }

    [Fact]
    public void SetValue_ShouldCallPropertyChangedEvent_WhenCalled()
    {
        //Arrange
        var vm = new TestViewModelBase() { Name = "Test" };
        var fired = false;
        vm.PropertyChanged += (s, e) => fired = true;

        //Act
        vm.Name = "My Test";

        //Assert
        fired.Should().BeTrue();
    }

    private class TestViewModelBase : ViewModelBase
    {
        public string? Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
    }
}