using OnStore.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace OnStore.Views;

public partial class AddCar1 : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    MainWindow? main;
    private Car? newCar;
    public Car? NewCar { get => newCar; set { newCar = value; OnPropertyChange(); } }
    ObservableCollection<Car>? Cars;
    int selectedIndex;
    public AddCar1(ObservableCollection<Car>? Cars, int selectedIndex, MainWindow main)
    {
        InitializeComponent();
        DataContext = this;
        NewCar = new();
        this.Cars = Cars;
        this.selectedIndex = selectedIndex;
        this.main = main;
    }
    public void OnPropertyChange([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (NewCar is not null)
            Cars![selectedIndex] = NewCar!;
        Hide();
        main!.ShowDialog();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        Hide();

        main!.ShowDialog();
    }
    
}
