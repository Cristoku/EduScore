using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EduScoreDatabase;
using EduScoreDatabase.CommandsQueries;

namespace EduScore.ViewModels;

/// <summary>
/// Represents a view model for managing grades in the EduScore application.
/// </summary>
public class OcenyVM : INotifyPropertyChanged
{
    private readonly EduScoreContext _context;
    private readonly RemovingCommands _removingCommands;

    private string _id;
    private readonly ShowData _showData;

    private string _studentId;

    private string _subjectId;

    private ObservableCollection<Grade> _TableDisplay;

    private string _value;

    /// <summary>
    /// Initializes a new instance of the OcenyVM class with the specified EduScoreContext.
    /// </summary>
    /// <param name="context">The EduScoreContext database context.</param>
    public OcenyVM(EduScoreContext context)
    {
        _context = context;
        _showData = new ShowData(_context);
        _removingCommands = new RemovingCommands();
        Add = new BasicCommand(AddElementToDb);
        Remove = new BasicCommand(RemoveFromDb);
        UpdateTable();
    }

    /// <summary>
    /// Gets or sets the student ID property.
    /// </summary>
    public string StudentId
    {
        get => _studentId;
        set
        {
            if (_studentId != value)
            {
                _studentId = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the subject ID property.
    /// </summary>
    public string SubjectId
    {
        get => _subjectId;
        set
        {
            if (_subjectId != value)
            {
                _subjectId = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the value property (grade value).
    /// </summary>
    public string Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
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
    /// Gets or sets the observable collection of grades for display.
    /// </summary>
    public ObservableCollection<Grade> OcenyPodglad
    {
        get => _TableDisplay;
        set
        {
            _TableDisplay = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the command for adding a grade.
    /// </summary>
    public ICommand Add { get; set; }
    
    /// <summary>
    /// Gets the command for removing a grade.
    /// </summary>
    public ICommand Remove { get; set; }

    private void RemoveFromDb()
    {
        if (!int.TryParse(ID, out var partId))
        {
            MessageBox.Show("Niepoprawne ID. ", "Error");
            return;
        }

        if(_removingCommands.RemoveGradeById(Convert.ToInt32(ID)))
        {
            MessageBox.Show("Usunięto element z bazy danych");
        }
        else
        {
            MessageBox.Show("Nie znaleziono elementu o podanym ID");
            return;
        }

        UpdateTable();
    }

    private void AddElementToDb()
    {
        if (!int.TryParse(StudentId, out var studentId))
        {
            MessageBox.Show("Niepoprawny Student ID");
            return;
        }

        if (!int.TryParse(SubjectId, out var subjectId))
        {
            MessageBox.Show("Niepoprawny Subject ID");
            return;
        }

        if (!int.TryParse(Value, out var value))
        {
            MessageBox.Show("Niepoprawne Value");
            return;
        }

        var savingCommands = new SavingCommands();
        savingCommands.SaveData(new Grade
        {
            StudentId = Convert.ToInt32(StudentId),
            SubjectId = Convert.ToInt32(SubjectId),
            Value = Convert.ToInt32(Value)
        });
        UpdateTable();
    }

    public void UpdateTable()
    {
        var GradesRaw = _showData.GetData<Grade>();
        OcenyPodglad = new ObservableCollection<Grade>(GradesRaw);
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