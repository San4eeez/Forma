using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Npgsql;

namespace Forma;

public partial class Window2 : Window
{
    NpgsqlDataSource dataSource;
    private int tempPic;
    private int kart;
    private string correct = "0";
    private bool loginCorrect = false;
    private bool kaptchaProsel = false;
    public Window2()
    {
        var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=forma";
        dataSource = NpgsqlDataSource.Create(connectionString);
        InitializeComponent();
        vas();

    }

    private void vas()
    {
        string tapok;

        using (var cmd = dataSource.CreateCommand($"SELECT email FROM users where id = 14"))
        {
            var reader = cmd.ExecuteReader();
            reader.Read();
            tapok = reader[0].ToString();
        }
        Valer.Text = tapok;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using (var cmd = dataSource.CreateCommand($"SELECT COUNT(*) FROM users WHERE email = @email AND parol = @pwd"))
        {
            cmd.Parameters.AddWithValue("email", email.Text);
            cmd.Parameters.AddWithValue("pwd", pwd.Text);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int count = reader.GetInt32(0);
                if (count > 0)
                {
                    loginCorrect = true;
                    Close();
                    new Window4().Show();
                }
                else
                {
                    InCorrectAlert.IsVisible = true;
                   
                }
            }
        }

    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window3().Show();
        Close();
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

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        ShowPic();


    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void Button_Click_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(Captcha.Text == correct)
        {
            Verno.IsVisible= true;
            Neverno.IsVisible = false;
            kaptchaProsel = true;
        }
        else
        {
            Neverno.IsVisible = true;
            Verno.IsVisible = false;
        }
    }
}