using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using EduScore.Views;
using EduScoreDatabase;
using EduScoreDatabase.CommandsQueries;

namespace EduScore.ViewModels;

/// <summary>
/// Represents a view model for handling the logged-in user's data display in the EduScore application.
/// </summary>
public class LoggedVM : INotifyPropertyChanged
{
    private readonly ShowData _showData;

    private ObservableCollection<GradeConverted> _displayGrades;

    /// <summary>
    /// Initializes a new instance of the LoggedVM class with the specified student name.
    /// </summary>
    /// <param name="StudentName">The name of the logged-in student.</param>
    public LoggedVM(string StudentName)
    {
        _showData = new ShowData(new EduScoreContext());
        PlanLekcjiCommand = new BasicCommand(PlanLekcjiView);
        PrzedmiotyCommand = new BasicCommand(PrzedmiotyView);
        OcenyCommand = new BasicCommand(OcenyView);
        OstatnieOceny();
    }

    /// <summary>
    /// Gets the command for navigating to the PlanLekcji view.
    /// </summary>
    public BasicCommand PlanLekcjiCommand { get; set; }
    
    /// <summary>
    /// Gets the command for navigating to the Przedmioty view.
    /// </summary>
    public BasicCommand PrzedmiotyCommand { get; set; }
    
    /// <summary>
    /// Gets the command for navigating to the Oceny view.
    /// </summary>
    public BasicCommand OcenyCommand { get; set; }

    /// <summary>
    /// Gets or sets the observable collection to display the latest converted grades.
    /// </summary>
    public ObservableCollection<GradeConverted> NajnowszeOceny
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
        var window = new Oceny(new EduScoreContext());
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

    public void OstatnieOceny()
    {
        var GradesRaw = _showData.GetData<Grade>();

        var gradesTypeTransfer = new GradesTypeTransfer(GradesRaw);

        gradesTypeTransfer.ConvertGrades();

        NajnowszeOceny = new ObservableCollection<GradeConverted>(gradesTypeTransfer.ConvertGrades());
    }
}