using EduScoreDatabase.CommandsQueries;
using EduScoreDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace EduScore.ViewModels
{
public class PrzedmiotyVM : INotifyPropertyChanged
{
    private readonly EduScoreContext _context;
    private readonly RemovingCommands _removingCommands;

    private string _id;
    private readonly ShowData _showData;


    private string _subjectName;

    private ObservableCollection<Subject> _TableDisplay;

    private string _value;

    public PrzedmiotyVM(EduScoreContext context)
    {
        _context = context;
        _showData = new ShowData(_context);
        _removingCommands = new RemovingCommands();
        Add = new BasicCommand(AddElementToDb);
        Remove = new BasicCommand(RemoveFromDb);
        UpdateTable();
    }

    public string SubjectName
    {
        get => _subjectName;
        set
        {
            if (_subjectName != value)
            {
                _subjectName = value;
                OnPropertyChanged();
            }
        }
    }
    public string ID
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<Subject> OcenyPodglad
    {
        get => _TableDisplay;
        set
        {
            _TableDisplay = value;
            OnPropertyChanged();
        }
    }

    public ICommand Add { get; set; }
    public ICommand Remove { get; set; }

    private void RemoveFromDb()
    {
        if (!int.TryParse(ID, out var partId))
        {
            MessageBox.Show("Niepoprawne ID. ", "Error");
            return;
        }

        if(_removingCommands.RemoveSubjectById(Convert.ToInt32(ID)))
        {
            MessageBox.Show("Usunięto element z bazy danych");
        }
        else
        {
            MessageBox.Show("Nie znaleziono elementu o podanym ID");
            return;
        }
        ID = "";
        UpdateTable();
    }

    private void AddElementToDb()
    {
        if (string.IsNullOrWhiteSpace(SubjectName) || int.TryParse(SubjectName, out int subname))
        {
            MessageBox.Show("Niepoprawny SubjectName");
            return;
        }

        var savingCommands = new SavingCommands();
        savingCommands.SaveData(new Subject()
        {
            Name = SubjectName
        });

        UpdateTable();
    }

    public void UpdateTable()
    {
        var GradesRaw = _showData.GetData<Subject>();
        OcenyPodglad = new ObservableCollection<Subject>(GradesRaw);
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

}
