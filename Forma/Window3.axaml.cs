using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Npgsql;
using System;

namespace Forma;

public partial class Window3 : Window
{
    NpgsqlDataSource dataSource;

    public Window3()
    {
        var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=forma";
        dataSource = NpgsqlDataSource.Create(connectionString);

        // Insert some data
        

        
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        using (var cmd = dataSource.CreateCommand("INSERT INTO users (email, parol) VALUES ($1, $2)"))
        {
            cmd.Parameters.AddWithValue(Email.Text);
            cmd.Parameters.AddWithValue(Passw.Text);
            cmd.ExecuteNonQuery();
        }

    }
}