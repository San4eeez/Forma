using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
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
                    HorizontalAlignment = HorizontalAlignment.Center,

                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };
                
                

                var newTextBlockPrice = new TextBlock
                {
                    Text = tapok_price,
                    HorizontalAlignment = HorizontalAlignment.Center

                };
                
                
                
                /*var newBorder = new Border()
                {
                    Background = Brushes.Yellow,
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };*/

                var newImg = new Image()
                {
                    Source = ImageHelper.LoadFromResource(new Uri($"avares://Forma/Assets/{tapok}")),
                    Width = 100,
                    Height = 100
                    
                };
                
                var newStack = new StackPanel()
                {
                    Height = 100,
                    Width = 100
                    
                    
                };

                // Добавляем новый TextBlock в ItemsControl
                /*
                newStack.Children.Add(newBorder);
                */
                newStack.Children.Add(newImg);
                newStack.Children.Add(newTextBlockId);
                newStack.Children.Add(newTextBlockPrice);

                TextBlocksContainer.Items.Add(newStack);
            }
        }
    }


    
}