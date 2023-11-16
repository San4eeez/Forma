using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Npgsql;
using System;

namespace Forma;

public partial class Window3 : Window
{
    NpgsqlDataSource dataSource;
    private int kart;
    private string correct;
    private bool kaptchaProsel = false;

    public Window3()
    {
        var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=forma";
        dataSource = NpgsqlDataSource.Create(connectionString);

        // Insert some data
        

        
        InitializeComponent();
    }


    public void ShowPic()
    {
        Random random = new Random();

        int RandomKart = random.Next(1, 4);
        switch (RandomKart)
        {
            case 1:
                Ca1.IsVisible = true;
                Ca2.IsVisible = false;
                Ca3.IsVisible = false;

                correct = "774";
                break;
            case 2:
                Ca1.IsVisible = false;
                Ca2.IsVisible = true;
                Ca3.IsVisible = false;

                correct = "6643";
                break;
            case 3:
                Ca1.IsVisible = false;
                Ca2.IsVisible = false;
                Ca3.IsVisible = true;

                correct = "6411";
                break;
        }
        kart = RandomKart;
        
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        if (kaptchaProsel == true)
        {



            if (Passw.Text == Passw2.Text)
            {

                try
                {

                    using (var cmd = dataSource.CreateCommand("INSERT INTO users (email, parol) VALUES ($1, $2)"))
                    {
                        cmd.Parameters.AddWithValue(Email.Text);
                        cmd.Parameters.AddWithValue(Passw.Text);
                        cmd.ExecuteNonQuery();
                    }
                    new Window1().Show();
                }

                catch
                {
                    Durak.IsVisible = true;
                }

            }
            else
            {
            
                Dyrak.IsVisible = true;
            }
        }
        else //не прошёл капчу
        {
            AlertCapt.IsVisible = true;
        }


    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ShowPic();

    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(CaptEnter.Text == correct)
        {
            kaptchaProsel = true;
            AlertCapt.IsVisible = false;
        }
        else
        {
            AlertCapt.IsVisible = true;
        }
    }
}