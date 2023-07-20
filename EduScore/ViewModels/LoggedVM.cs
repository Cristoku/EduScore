using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using EduScore.Views;
using EduScoreDatabase;
using EduScoreDatabase.CommandsQueries;

namespace EduScore.ViewModels;

public class LoggedVM : INotifyPropertyChanged
{
    private readonly ShowData _showData;

    private ObservableCollection<GradeConverted> _displayGrades;

    public LoggedVM(string StudentName)
    {
        _showData = new ShowData(new EduScoreContext());
        PlanLekcjiCommand = new BasicCommand(PlanLekcjiView);
        PrzedmiotyCommand = new BasicCommand(PrzedmiotyView);
        OcenyCommand = new BasicCommand(OcenyView);
        OstatnieOceny();
    }

    public BasicCommand PlanLekcjiCommand { get; set; }
    public BasicCommand PrzedmiotyCommand { get; set; }
    public BasicCommand OcenyCommand { get; set; }

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

    public void OstatnieOceny()
    {
        var GradesRaw = _showData.GetData<Grade>();

        var gradesTypeTransfer = new GradesTypeTransfer(GradesRaw);

        gradesTypeTransfer.ConvertGrades();

        NajnowszeOceny = new ObservableCollection<GradeConverted>(gradesTypeTransfer.ConvertGrades());
    }
}