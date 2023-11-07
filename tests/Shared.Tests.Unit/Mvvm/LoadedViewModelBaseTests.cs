using FluentAssertions;
using Shared.Mvvm;

namespace Shared.Tests.Unit.Mvvm;

public class LoadedViewModelBaseTests
{
    [Fact]
    public void LoadedCommand_ShouldCallLoadedExecute_WhenCalled()
    {
        //Arrange
        var vm = new LoadedViewModel();

        //Act
        vm.LoadedCommand.Execute(null);
        //Assert
        vm.LoadedCalled.Should().BeTrue();
    }
    [Fact]
    public void UnLoadedCommand_ShouldCallLoadedExecute_WhenCalled()
    {
        //Arrange
        var vm = new LoadedViewModel();

        //Act
        vm.UnloadedCommand.Execute(null);
        //Assert
        vm.UnloadedCalled.Should().BeTrue();
    }
    
    
    private class LoadedViewModel : LoadedViewModelBase
    {
        public bool LoadedCalled { get; set; }

        public bool UnloadedCalled { get; set; }

        protected override void LoadedExecute()
        {
            LoadedCalled = true;
        }

        protected override void UnloadedExecute()
        {
            UnloadedCalled = true;
        }
    }
}