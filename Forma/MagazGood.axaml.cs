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

public partial class MagazGood : Window
{
    NpgsqlDataSource dataSource;
    public MagazGood(string tid)
    {
        int id = Convert.ToInt32(tid);
        var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=forma";
        dataSource = NpgsqlDataSource.Create(connectionString);
        InitializeComponent();
        vas(id);
        
    }
    
     private void vas(int id)
    {
        using (var cmd = dataSource.CreateCommand($"SELECT name,forlink,price,description from magaz where id = {id}"))
        {
            var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                string id_tapok = reader[0].ToString();
                string tapok = reader[1].ToString();
                string tapok_price = reader[2].ToString();
                string tapok_description = reader[3].ToString();
                
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

                var newDesc = new TextBlock()
                {
                    Text = tapok_description
                };
                
                
               
                var newImg = new Image()
                {
                    Source = ImageHelper.LoadFromResource(new Uri($"avares://Forma/Assets/{tapok}")),
                    MaxHeight = 300,
                    MaxWidth = 400,
                    HorizontalAlignment = HorizontalAlignment.Center
                    
                };

                var newStack = new StackPanel()
                {
                    
                };
                // Все теги пихаю в стак, его и отсылаю
                
                newStack.Children.Add(newTextBlockId);
                newStack.Children.Add(newTextBlock);
                newStack.Children.Add(newTextBlockPrice);
                newStack.Children.Add(newDesc);
                /*
                newStack.Children.Add(newImg);
                */
                
                TextBlocksContainer2.Items.Add(newImg);
                TextBlocksContainer.Items.Add(newStack);
            }
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}