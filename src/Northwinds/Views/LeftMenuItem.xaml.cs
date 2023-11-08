using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace Northwinds.Views;

public partial class LeftMenuItem : UserControl
{
    public LeftMenuItem()
    {
        InitializeComponent();
        PreviewMouseLeftButtonUp += OnClick;
    }

    #region Events

    // Register a custom routed event using the Bubble routing strategy.
    public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
        name: "Click",
        routingStrategy: RoutingStrategy.Bubble,
        handlerType: typeof(RoutedEventHandler),
        ownerType: typeof(LeftMenuItem));

    // Provide CLR accessors for assigning an event handler.
    public event RoutedEventHandler Click
    {
        add => AddHandler(ClickEvent, value);
        remove => RemoveHandler(ClickEvent, value);
    }
    

    #endregion

    #region Properties

    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), 
        typeof(string),
        typeof(LeftMenuItem), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(
        nameof(IconSize), 
        typeof(double),
        typeof(LeftMenuItem),
        new PropertyMetadata(20.0));

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph), 
        typeof(PackIconKind),
        typeof(LeftMenuItem),
        new (default(PackIconKind)));

    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
        nameof(Command), 
        typeof(ICommand),
        typeof(LeftMenuItem),
        new PropertyMetadata(default(ICommand), CommandCallback));

    public static readonly DependencyProperty LabelVisibilityProperty = DependencyProperty.Register(
        nameof(LabelVisibility),
        typeof(Visibility), 
        typeof(LeftMenuItem), 
        new PropertyMetadata(Visibility.Visible));

    public Visibility LabelVisibility
    {
        get => (Visibility)GetValue(LabelVisibilityProperty);
        set => SetValue(LabelVisibilityProperty, value);
    }

    /// <summary>
    /// the label that you'd like to display
    /// </summary>
    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    /// <summary>
    /// the icon
    /// </summary>
    public PackIconKind Glyph
    {
        get => (PackIconKind)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    /// <summary>
    /// the command fired when clicked
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
        nameof(CommandParameter), typeof(object), typeof(LeftMenuItem), new PropertyMetadata(default(object)));

    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public double IconSize
    {
        get => (double)GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }
    #endregion

    private void HandleLeftMouseButtonUp(object sender, MouseButtonEventArgs e)
    {
        e.Handled = false;
    }

    private static void CommandCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is LeftMenuItem { Command: ICommand } leftMenuItem)
        {
            if (e.OldValue is not null)
            {
                ((ICommand)e.OldValue).CanExecuteChanged -= leftMenuItem.OnCanExecuteChanged;
            }
            leftMenuItem.Command.CanExecuteChanged += leftMenuItem.OnCanExecuteChanged;
        }
    }

    private void OnCanExecuteChanged(object? sender, EventArgs e)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }

    private void OnClick(object sender, MouseButtonEventArgs e)
    {
        RaiseEvent(new(ClickEvent));
        if (Command is not null)
        {
            Command.Execute(CommandParameter);
        }
    }
}