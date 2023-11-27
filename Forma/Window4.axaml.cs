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
        using (var cmd = dataSource.CreateCommand($"SELECT name,forlink,price, id from magaz"))
        {
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string id_tapok = reader[0].ToString();
                string tapok = reader[1].ToString();
                string tapok_price = reader[2].ToString();
                string id = reader[3].ToString();

                var newTextBlockId = new TextBlock
                {
                    Text = id_tapok,
                    Foreground = Brushes.Red,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(5)
                };

                var newTextBlockPrice = new TextBlock
                {
                    Text = tapok_price,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                var newImg = new Image()
                {
                    Source = ImageHelper.LoadFromResource(new Uri($"avares://Forma/Assets/{tapok}")),
                    Width = 100,
                    Height = 100
                };

                var newBorder = new Border()
                {
                    
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };

                var newButton = new Button()
                {
                    Content = "Купить",
                    Foreground = Brushes.White,
                    Background = Brushes.Green,                    
                };

                newButton.Click += (sender, args) => new MagazGood(id).Show(); 

                // Добавляем новый TextBlock, Image в Border
                newBorder.Child = new StackPanel()
                {
                    Children =
                    {
                        newImg,
                        newTextBlockId,
                        newTextBlockPrice,
                        newButton
                    }
                };

                // Добавляем Border в ItemsControl
                TextBlocksContainer.Items.Add(newBorder);
            }
        }
    }

   
    
}