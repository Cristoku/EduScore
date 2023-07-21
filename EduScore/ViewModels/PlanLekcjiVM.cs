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
    /// Represents a view model for managing lesson plans in the EduScore application.
    /// </summary>
public class PlanLekcjiVM : INotifyPropertyChanged
{
    private readonly EduScoreContext _context;
    private readonly RemovingCommands _removingCommands;

    private string _id;
    private readonly ShowData _showData;

    private string _content;
    private string _teacherName;

    private string _subjectId;

    private ObservableCollection<LessonPlan> _TableDisplay;

    private string _value;

    /// <summary>
    /// Initializes a new instance of the PlanLekcjiVM class with the specified EduScoreContext.
    /// </summary>
    /// <param name="context">The EduScoreContext database context.</param>
    public PlanLekcjiVM(EduScoreContext context)
    {
        _context = context;
        _showData = new ShowData(_context);
        _removingCommands = new RemovingCommands();
        Add = new BasicCommand(AddElementToDb);
        Remove = new BasicCommand(RemoveFromDb);
        UpdateTable();
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
    /// Gets or sets the teacher name property.
    /// </summary>
    public string TeacherName
    {
        get => _teacherName;
        set
        {
            if (_teacherName != value)
            {
                _teacherName = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the content property.
    /// </summary>
    public string Content
    {
        get => _content;
        set
        {
            if (_content != value)
            {
                _content = value;
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
    /// Gets or sets the observable collection of lesson plans for display.
    /// </summary>
    public ObservableCollection<LessonPlan> OcenyPodglad
    {
        get => _TableDisplay;
        set
        {
            _TableDisplay = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the command for adding a lesson plan.
    /// </summary>
    public ICommand Add { get; set; }
    
    /// <summary>
    /// Gets the command for removing a lesson plan.
    /// </summary>
    public ICommand Remove { get; set; }

    private void RemoveFromDb()
    {
        if (!int.TryParse(ID, out var partId))
        {
            MessageBox.Show("Niepoprawne ID. ", "Error");
            return;
        }

        if(_removingCommands.RemoveLessonById(Convert.ToInt32(ID)))
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
        if (!int.TryParse(SubjectId, out var studentId))
        {
            MessageBox.Show("Niepoprawny SubjectId");
            return;
        }

        if (String.IsNullOrWhiteSpace(TeacherName))
        {
            MessageBox.Show("Niepoprawne TeacherName");
            return;
        }

        if (String.IsNullOrWhiteSpace(Content))
        {
            MessageBox.Show("Niepoprawne Content");
            return;
        }

        var savingCommands = new SavingCommands();
        savingCommands.SaveData(new LessonPlan()
        {
            SubjectId = Convert.ToInt32(SubjectId),
            TeacherName = TeacherName,
            Content = Content
        });
        SubjectId = "";
        TeacherName = "";
        Content = "";
        UpdateTable();
    }

    public void UpdateTable()
    {
        var GradesRaw = _showData.GetData<LessonPlan>();
        OcenyPodglad = new ObservableCollection<LessonPlan>(GradesRaw);
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
