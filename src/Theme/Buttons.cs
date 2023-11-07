using System.Windows;
using MaterialDesignThemes.Wpf;

namespace Theme;

public class Buttons : DependencyObject
{
    public static readonly DependencyProperty GlyphProperty = DependencyProperty.RegisterAttached(
        "Glyph", typeof(PackIconKind), typeof(Buttons), new PropertyMetadata(default(PackIconKind)));

    public static void SetGlyph(DependencyObject element, PackIconKind value)
    {
        element.SetValue(GlyphProperty, value);
    }

    public static PackIconKind GetGlyph(DependencyObject element)
    {
        return (PackIconKind)element.GetValue(GlyphProperty);
    }
}