using System;
using System.Collections.Generic;
using System.Linq;
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
        string miasto = Miasto.Text;
        if (!string.IsNullOrWhiteSpace(miasto))
        {
            Miasta.Items.Add(miasto);
        }
    }

    private void Button_OnClick2(object? sender, RoutedEventArgs e)
    {
        string imie = ImieNazwisko.Text;
        string kraj = (Kraj.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
        
        List<string> atrakcje = new();
        if (MuzeaAtrakcje.IsChecked == true)
        {
            atrakcje.Add("Muzea");
        }
        if (ParkiNarodoweAtrakcje.IsChecked == true)
        {
            atrakcje.Add("Parki Narodowe");
        }
        if (ZabytkiAtrakcje.IsChecked == true)
        {
            atrakcje.Add("Zabytki");
        }
        if (RestauracjeAtrakcje.IsChecked == true)
        {
            atrakcje.Add("Restauracje");
        }
        if (GalerieSztukiAtrakcje.IsChecked == true)
        {
            atrakcje.Add("GalerieSztuki");
        }
        if (FestiwaleAtrakcje.IsChecked == true)
        {
            atrakcje.Add("Festiwale i koncerty");
        }

        string transport = Samolot.IsChecked == true ? "Samolot" :
            Samochód.IsChecked == true ? "Samochód" :
            Pociag.IsChecked == true ? "Pociag" :
            Statek.IsChecked == true ? "Statek" : "";
        
        var miasta = string.Join(", ", Miasta.Items.Cast<string>());
        
        var SecondWindow = new SecondWindow(imie, kraj, atrakcje, transport, miasta);
        SecondWindow.Show();
    }
}