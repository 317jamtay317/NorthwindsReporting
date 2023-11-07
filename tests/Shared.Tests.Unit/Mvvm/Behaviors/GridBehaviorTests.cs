using System.Windows;
using System.Windows.Controls;
using FluentAssertions;
using Shared.Mvvm.Behaviors;

namespace Shared.Tests.Unit.Mvvm.Behaviors;

public class GridBehaviorTests
{
    [StaFact]
    public void RowString_ShouldHave1RowByDefault()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act

        //Assert
        grid.RowDefinitions.Count.Should().Be(1);
    }

    [StaFact]
    public void RowString_ShouldSupportAutoValue()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act
        behavior.RowString = "auto";

        //Assert
        grid.RowDefinitions.Count.Should().Be(1);
        grid.RowDefinitions.First().Height.Should().Be(GridLength.Auto);
    }

    [StaFact]
    public void RowString_ShouldSupportStarValues()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act
        behavior.RowString = "*";
        //Assert
        grid.RowDefinitions.Count.Should().Be(1);
        grid.RowDefinitions.First().Height.Should().Be(new GridLength(1, GridUnitType.Star));
    }

    [StaFact]
    public void RowString_ShouldSupportNXStar()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act
        behavior.RowString = "3*";
        //Assert
        grid.RowDefinitions.Count.Should().Be(1);
        grid.RowDefinitions.First().Height.Should().BeEquivalentTo(new GridLength(3, GridUnitType.Star));
    }

    [StaFact]
    public void RowString_ShouldSupportMultipleValues()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act
        behavior.RowString = "auto,*,auto";
        //Assert
        grid.RowDefinitions.Count.Should().Be(3);
        grid.RowDefinitions.First().Height.Should().BeEquivalentTo(GridLength.Auto);
        grid.RowDefinitions[1].Height.Should().BeEquivalentTo(new GridLength(1, GridUnitType.Star));
        grid.RowDefinitions.Last().Height.Should().BeEquivalentTo(GridLength.Auto);
    }

    [StaFact]
    public void ColumnString_ShouldSupportMultipleValues()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act
        behavior.ColumnsString = "auto,*,auto";
        //Assert
        grid.ColumnDefinitions.Count.Should().Be(3);
        grid.ColumnDefinitions.First().Width.Should().BeEquivalentTo(GridLength.Auto);
        grid.ColumnDefinitions[1].Width.Should().BeEquivalentTo(new GridLength(1, GridUnitType.Star));
        grid.ColumnDefinitions.Last().Width.Should().BeEquivalentTo(GridLength.Auto);
    }

    [StaFact]
    public void ColumnString_ShouldParsePixalValues()
    {
        //Arrange
        var grid = Create(out var behavior);

        //Act
        behavior.ColumnsString = "75";

        //Assert
        grid.ColumnDefinitions.First().Width.Should().BeEquivalentTo(new GridLength(75.0, GridUnitType.Pixel));
    }

    private static Grid Create(out GridBehavior behavior)
    {
        var grid = new Grid();
        behavior = new GridBehavior();
        behavior.Attach(grid);
        return grid;
    }
}