using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OnStore.Models;

public class Car: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;


    private string? name1;
    private string? color1;
    private double cost1;


    public string? Name1 { get => name1; set { name1 = value; OnPropertyChange(); }  } 
    public string? Color1 { get => color1; set { color1 = value; OnPropertyChange(); } }
    public double Cost1 { get => cost1; set { cost1 = value; OnPropertyChange(); } }

    public void OnPropertyChange([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString() => $"Name: {Name1} - Color: {Color1} - Cost: {Cost1}";
}
