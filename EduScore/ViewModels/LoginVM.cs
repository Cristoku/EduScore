﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EduScore.Views;
using EduScoreDatabase;
using EduScoreDatabase.CommandsQueries;

namespace EduScore.ViewModels;

/// <summary>
/// Represents a view model for handling the login process in the EduScore application.
/// </summary>
public class LoginVM : INotifyPropertyChanged
{
    private readonly EduScoreContext _context;
    private readonly LoginStudent _loginstudent;

    private string _password;

    private string _username;

    /// <summary>
    /// Initializes a new instance of the LoginVM class with the specified EduScoreContext.
    /// </summary>
    /// <param name="context">The EduScoreContext database context.</param>
    public LoginVM(EduScoreContext context)
    {
        _context = context;
        LoginComm = new BasicCommand(Login);
        _loginstudent = new LoginStudent(_context);
    }

    /// <summary>
    /// Gets or sets the username property.
    /// </summary>
    public string Name
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged();
            }
        }
    }
    
    /// <summary>
    /// Gets or sets the password property.
    /// </summary>
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
    
    /// <summary>
    /// Gets the command for the login action.
    /// </summary>
    public ICommand LoginComm { get; }
    private void Login()
    {
        if (_loginstudent.LoginUser(Name, Password))
        {
            var window = new Logged(Name);
            if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();
            Application.Current.MainWindow = window;
            window.Show();
        }
        else
        {
            MessageBox.Show("Name or password didn't matched. Please try again!");
        }
    }

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
}