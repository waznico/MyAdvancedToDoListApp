namespace MyAdvancedToDoListApp;

public partial class MainPage : ContentPage
{

    private readonly string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "notes.txt");

    public string FileName => _fileName;

    public MainPage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
        {
            NoteInput.Text = File.ReadAllText(_fileName);
        }
    }

    private void OnSaveClicked(object sender, EventArgs args)
    {
        File.WriteAllText(_fileName, NoteInput.Text);
    }

    private void OnDeleteClicked(object sender, EventArgs args)
    {
        NoteInput.Text = string.Empty;
        File.Delete(_fileName);
    }
}

public class GlobalFontSizeExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return 28.0;
    }
}