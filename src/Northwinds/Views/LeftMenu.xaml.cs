using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using ImTools;

namespace Northwinds.Views;

public partial class LeftMenu : UserControl
{
    public LeftMenu()
    {
        InitializeComponent();
        Width = SmallSize;
    }

    private static readonly double SmallSize = 45.0;
    private static readonly double ExpandedSize = 300.0;
    
    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
        nameof(IsExpanded), 
        typeof(bool), 
        typeof(LeftMenu), 
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsExpandedCallback));

    public static readonly DependencyProperty PinnedProperty = DependencyProperty.Register(
        nameof(Pinned), typeof(bool), typeof(LeftMenu), new PropertyMetadata(default(bool)));

    public bool Pinned
    {
        get => (bool)GetValue(PinnedProperty);
        set => SetValue(PinnedProperty, value);
    }
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    private static void IsExpandedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is LeftMenu menu)
        {
            menu.Resize();
        }
    }

    private void Resize()
    {
        if (_expandingInProgress)
        {
            return;
        }
        _expandingInProgress = true;
        var animation = new DoubleAnimation
        {
            Duration = new(TimeSpan.FromMilliseconds(200)),
        };
        Storyboard.SetTarget(animation, this);
        Storyboard.SetTargetProperty(animation, new PropertyPath(nameof(WidthProperty)));
        if (Math.Abs(Width - SmallSize) < 1)
        {
            animation.From = SmallSize;
            animation.To = ExpandedSize;
        }
        else
        {
            animation.From = ExpandedSize;
            animation.To = SmallSize;
        }

        _widthStoryboard = new Storyboard();
        _widthStoryboard.BeginAnimation(WidthProperty, animation);

    }

    private void HanldeMouseChange(object sender, MouseEventArgs e)
    {
        if (!Pinned)
        {
            Resize();
        }

        e.Handled = true;
    }

    private bool _expandingInProgress = false;
    private Storyboard? _widthStoryboard;
}