using System.Windows;
using System.Windows.Controls;
using EduScore.ViewModels;
using EduScoreDatabase;

namespace EduScore.Views;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class Login : Window
{
    private readonly LoginVM _loginVm = new(new EduScoreContext());

    public Login()
    {
        InitializeComponent();
        DataContext = _loginVm;
    }

    private void PassTick(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox) _loginVm.Password = passwordBox.Password;
    }
}