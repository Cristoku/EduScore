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
    /// <summary>
    /// Represents a view model for managing subjects in the EduScore application.
    /// </summary>
public class PrzedmiotyVM : INotifyPropertyChanged
{
    private readonly EduScoreContext _context;
    private readonly RemovingCommands _removingCommands;

    private string _id;
    private readonly ShowData _showData;


    private string _subjectName;

    private ObservableCollection<Subject> _TableDisplay;

    private string _value;

    /// <summary>
    /// Initializes a new instance of the PrzedmiotyVM class with the specified EduScoreContext.
    /// </summary>
    /// <param name="context">The EduScoreContext database context.</param>
    public PrzedmiotyVM(EduScoreContext context)
    {
        _context = context;
        _showData = new ShowData(_context);
        _removingCommands = new RemovingCommands();
        Add = new BasicCommand(AddElementToDb);
        Remove = new BasicCommand(RemoveFromDb);
        UpdateTable();
    }

    /// <summary>
    /// Gets or sets the subject name property.
    /// </summary>
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
    
    /// <summary>
    /// Gets or sets the ID property.
    /// </summary>
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
    
    /// <summary>
    /// Gets or sets the observable collection of subjects for display.
    /// </summary>
    public ObservableCollection<Subject> OcenyPodglad
    {
        get => _TableDisplay;
        set
        {
            _TableDisplay = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the command for adding a subject.
    /// </summary>
    public ICommand Add { get; set; }
    
    /// <summary>
    /// Gets the command for removing a subject.
    /// </summary>
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
