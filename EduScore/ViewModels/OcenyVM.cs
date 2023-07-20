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

    public OcenyVM(EduScoreContext context)
    {
        _context = context;
        _showData = new ShowData(_context);
        _removingCommands = new RemovingCommands();
        Add = new BasicCommand(AddElementToDb);
        Remove = new BasicCommand(RemoveFromDb);
        UpdateTable();
    }

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

    public ObservableCollection<Grade> OcenyPodglad
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

        if(_removingCommands.RemoveDataById(Convert.ToInt32(ID)))
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