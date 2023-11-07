using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Shared.Mvvm.Behaviors;

public class GridBehavior : Behavior<Grid>
{

    public static readonly DependencyProperty RowStringProperty = DependencyProperty.Register(
        nameof(RowString), 
        typeof(string),
        typeof(GridBehavior), 
        new PropertyMetadata(default(string), RowsChangedCallback));

    public string RowString
    {
        get => (string)GetValue(RowStringProperty);
        set => SetValue(RowStringProperty, value);
    }

    public static readonly DependencyProperty ColumnsStringProperty = DependencyProperty.Register(
        nameof(ColumnsString),
        typeof(string), 
        typeof(GridBehavior),
        new PropertyMetadata(default(string), ColumnsChangedCallback));

    public string ColumnsString
    {
        get => (string)GetValue(ColumnsStringProperty);
        set => SetValue(ColumnsStringProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        UpdateColumns();
        UpdateRows();
    }

    private void UpdateRows()
    {
        UpdateGrid<RowDefinition>(
            stringValue: RowString, 
            setGridLength: (row, length)=> row.Height = length,
            getDefinitions: (grid)=> grid.RowDefinitions);
    }

    private void UpdateColumns()
    {
        UpdateGrid<ColumnDefinition>(
            stringValue: ColumnsString,
            setGridLength:(column, length)=> column.Width = length,
            getDefinitions:(grid)=> grid.ColumnDefinitions);
    }

    private static void ColumnsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is GridBehavior{AssociatedObject:Grid} behavior)
        {
            if (behavior.ColumnsString == e.OldValue?.ToString())
            {
                return;
            }
            behavior.AssociatedObject.ColumnDefinitions.Clear();
            behavior.UpdateColumns();
        }
    }

    private static void RowsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is GridBehavior{AssociatedObject:Grid} behavior)
        {
            if (behavior.RowString == e.OldValue?.ToString())
            {
                return;
            }
            behavior.AssociatedObject.RowDefinitions.Clear();
            behavior.UpdateRows();
        }
    }

    private void UpdateGrid<T>(string stringValue, 
        Action<T, GridLength> setGridLength,
        Func<Grid, IList<T>> getDefinitions)
        where T:DefinitionBase, new()
    {
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            var collection = getDefinitions(AssociatedObject);
            collection.Clear();
            collection.Add(new T());
            return;
        }
        var gridLengths = GetColumnWidths(stringValue);
        foreach (var length in gridLengths)
        {
            var definition = new T();
            setGridLength(definition, length);
            var collection = getDefinitions(AssociatedObject);
            collection.Add(definition);
        }
    }

    private GridLength[] GetColumnWidths(string stringValue)
    {
        var stringValues = stringValue
            .Split(",")
            .Select(x=>x.Trim().ToLower())
            .ToArray();
        var lengths = new List<GridLength>();
        foreach (var value in stringValues)
        {
            if (value == "auto")
            {
                lengths.Add(GridLength.Auto);
                continue;
            }
            if (value == "*")
            {
                lengths.Add(new GridLength(1, GridUnitType.Star));
                continue;
            }
            if (MultipleStars.IsMatch(value))
            {
                var match = value.Replace("*", string.Empty);
                var doubleValue = double.Parse(match);
                lengths.Add(new GridLength(doubleValue, GridUnitType.Star));
                continue;
            }

            if (double.TryParse(value, out var sizeValue))
            {
                lengths.Add(new GridLength(sizeValue, GridUnitType.Pixel));
            }
        }

        return lengths.ToArray();
    }

    private readonly static Regex MultipleStars = new(@"([0-9]+)\*");
    private readonly static Regex MultipleNumbers = new(@"([0-9]+)\*");
}