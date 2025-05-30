using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace TravelPlanner;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Kraj_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        string[] paths =
        {
            "avares://TravelPlanner/Assets/włochy.png",
            "avares://TravelPlanner/Assets/japonia.png",
            "avares://TravelPlanner/Assets/norwegia.png",
            "avares://TravelPlanner/Assets/usa.png",
            "avares://TravelPlanner/Assets/francja.png",
            "avares://TravelPlanner/Assets/polska.png",
        };

        if (Kraj.SelectedIndex >= 0)
        {
            using var stream = AssetLoader.Open(new Uri(paths[Kraj.SelectedIndex]));
            ZdjecieKraju.Source = new Bitmap(stream);
        }
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Button_OnClick2(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}