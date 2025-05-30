using System;
using System.Collections.Generic;
using System.Net;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace TravelPlanner;

public partial class SecondWindow : Window
{
    public SecondWindow(string imie, string kraj, List<string> atrakcje, string transport, string miasta)
    {
        InitializeComponent();

        Podsumowanie.Text = $"Imię i nazwisko: {imie}\n" +
                            $"Kraj docelowy: {kraj}\n" +
                            $"Wybrane atrakcje: {string.Join(", ", atrakcje)}\n" +
                            $"Wybrany transport: {transport}\n" +
                            $"Miasta do odwiedzenia: {miasta}\n";
        
        string path = $"avares://TravelPlanner/Assets/{kraj.ToLower()}.png";
        
        using var stream = AssetLoader.Open(new Uri(path));
        ZdjecieKraju2.Source = new Bitmap(stream);
        
    }

}