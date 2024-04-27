using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using OnStore.Models;
using OnStore.Views;
namespace OnStore;


public partial class MainWindow : Window, INotifyPropertyChanged
{
    private Car newCar;
    public Car NewCar
    {
        get { return newCar; }
        set { newCar = value; OnPropertyChange(); }
    }

    private ObservableCollection<Car>? cars = new();
    public ObservableCollection<Car>? Cars { get => cars; set { cars = value; } }

    public MainWindow()
    {
        NewCar = new();
        InitializeComponent();
        DataContext = this;
    }

    public void OnPropertyChange([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    private void listView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        Hide();
        AddCar1 editCar = new(Cars, listView1.SelectedIndex, this);
        editCar.ShowDialog();
        if (editCar.DialogResult == false)
            this.ShowDialog();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (NewCar is not null)
            Cars!.Add(NewCar);
        NewCar = new();
    }
}