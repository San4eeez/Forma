using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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
        using (var cmd = dataSource.CreateCommand($"SELECT email FROM users"))
        {
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string tapok = reader[0].ToString();

                // Создаем новый TextBlock
                var newTextBlock = new TextBlock
                {
                    Text = tapok,
                    Margin = new Thickness(5) // Можно настроить отступы по вашему желанию
                };

                // Добавляем новый TextBlock в ItemsControl
                TextBlocksContainer.Items.Add(newTextBlock);
            }
        }
    }


    
}