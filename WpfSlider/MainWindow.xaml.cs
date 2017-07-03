using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSlider
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    MyDataContext _myDataContext = new MyDataContext();
    public MainWindow()
    {
      InitializeComponent();
      DataContext = _myDataContext;

      mySlider.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(MySlider_MouseLeftButtonDown), true);
      mySlider.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler(MySlider_MouseLeftButtonUp), true);
    }

    private void MySlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      _myDataContext.IsPressed = false;
    }

    private void MySlider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      _myDataContext.IsPressed = true;
    }
  }

  public class MyDataContext : INotifyPropertyChanged
  {
    private bool _isPressed = false;
    public bool IsPressed
    {
      get
      {
        return _isPressed;
      }

      set
      {
        if (value != this._isPressed)
        {
          _isPressed = value;
          NotifyPropertyChanged();
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
