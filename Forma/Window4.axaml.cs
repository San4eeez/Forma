using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
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
        using (var cmd = dataSource.CreateCommand($"SELECT id, email, is_admin FROM users"))
        {
            var reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                string id_tapok = reader[0].ToString();
                string tapok = reader[1].ToString();
                string is_admin_tapok = reader[2].ToString();


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
                
                var newTextBlockAdm = new TextBlock
                {
                    Text = is_admin_tapok,
                    Foreground = Brushes.Blue,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };
                
                var newBorder = new Border()
                {
                    Background = Brushes.Yellow,
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };
                
                var newStack = new StackPanel()
                {
                    
                };

                // Добавляем новый TextBlock в ItemsControl
                newStack.Children.Add(newBorder);
                newStack.Children.Add(newTextBlockId);
                newStack.Children.Add(newTextBlock);
                newStack.Children.Add(newTextBlockAdm);

                TextBlocksContainer.Items.Add(newStack);
            }
        }
    }


    
}