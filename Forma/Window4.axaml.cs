using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Npgsql;

namespace Forma;

public partial class Window4 : Window
{
    NpgsqlDataSource dataSource;
    public Window4()
    {
        var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=forma";
        dataSource = NpgsqlDataSource.Create(connectionString);
        InitializeComponent();
        vas();
    }
    
    private void vas()
    {
        using (var cmd = dataSource.CreateCommand($"SELECT name,forlink,price from magaz"))
        {
            var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                string id_tapok = reader[0].ToString();
                string tapok = reader[1].ToString();
                string tapok_price = reader[2].ToString();
                


                // Создаем новый TextBlock
                var newTextBlockId = new TextBlock
                {
                    Text = id_tapok,
                    Foreground = Brushes.Red,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };
                
                var newTextBlock = new TextBlock
                {
                    Text = tapok,
                    Foreground = Brushes.Green,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };

                var newTextBlockPrice = new TextBlock
                {
                    Text = tapok_price
                };
                
                
                
                var newBorder = new Border()
                {
                    Background = Brushes.Yellow,
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };

                var newImg = new Image()
                {
                    Source = ImageHelper.LoadFromResource(new Uri($"avares://Forma/Assets/{tapok}"))
                };
                
                var newStack = new StackPanel()
                {
                    
                };

                // Добавляем новый TextBlock в ItemsControl
                newStack.Children.Add(newBorder);
                newStack.Children.Add(newTextBlockId);
                newStack.Children.Add(newTextBlock);
                newStack.Children.Add(newTextBlockPrice);
                newStack.Children.Add(newImg);

                TextBlocksContainer.Items.Add(newStack);
            }
        }
    }


    
}