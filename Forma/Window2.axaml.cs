using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Forma;

public partial class Window2 : Window
{

    private int tempPic;
    public Window2()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window3().Show();
        Close();
    }

    public void ShowPic(object sender, RoutedEventArgs args)
    {

    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Random random = new Random();

        int RandomKart = random.Next(1,4);
        switch (RandomKart)
        {
            case 1:
                Ca1.IsVisible= true;
                Ca2.IsVisible = false;
                Ca3.IsVisible = false;
                break;
            case 2:
                Ca1.IsVisible = false;
                Ca2.IsVisible = true;
                Ca3.IsVisible = false;
                break;
            case 3:
                Ca1.IsVisible = false;
                Ca2.IsVisible = false;
                Ca3.IsVisible = true;
                break;
        }



    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}