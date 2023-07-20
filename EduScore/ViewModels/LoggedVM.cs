using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Controls;
using EduScore.Views;
using EduScoreDatabase;
using EduScoreDatabase.CommandsQueries;

namespace EduScore.ViewModels
{
public class LoggedVM : INotifyPropertyChanged
{
    private readonly ShowData _showData;

    private ObservableCollection<Grade> _displayGrades;

    public LoggedVM()
    {
        _showData = new ShowData(new EduScoreContext());
        PlanLekcjiCommand = new BasicCommand(PlanLekcjiView);
        PrzedmiotyCommand = new BasicCommand(PrzedmiotyView);
        OcenyCommand = new BasicCommand(OcenyView);
        UpdatePartsTable();
    }

    public BasicCommand PlanLekcjiCommand { get; set; }
    public BasicCommand PrzedmiotyCommand { get; set; }
    public BasicCommand OcenyCommand { get; set; }

    public ObservableCollection<Grade> NajnowszeOceny
    {
        get => _displayGrades;
        set
        {
            _displayGrades = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OcenyView()
    {
        var window = new Oceny();
        Application.Current.MainWindow = window;
        window.Show();
    }

    private void PlanLekcjiView()
    {
        var window = new PlanLekcji();
        Application.Current.MainWindow = window;
        window.Show();
    }

    private void PrzedmiotyView()
    {
        var window = new Przedmioty();
        Application.Current.MainWindow = window;
        window.Show();
    }

    public void UpdatePartsTable()
    {
        NajnowszeOceny = new ObservableCollection<Grade>(_showData.GetData<Grade>());
    }
}
}
