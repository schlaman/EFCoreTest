using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EFCoreTestDeploy.Data.DbContext;

namespace EFCoreTestDeploy;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private string _status;
    [ObservableProperty] private bool _isVisible = false;
    private bool _isDatabaseInitialized = false;

    private readonly ApplicationDbContext _applicationDbContext;

    public MainPageViewModel()
    {

    }

    public MainPageViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [RelayCommand]
    public async Task ConfigureDatabase()
    {
        if (_isDatabaseInitialized)
        {
            Status = "Already Initialized, nothing to do";
            await Task.Delay(1200);
            Status = string.Empty;
            return;
        }

        IsVisible = true;
        Status = "Checking Database...";
        bool failed = false;

        try
        {
            //            var script = _applicationDbContext.Database.GenerateCreateScript();
            Console.WriteLine($"ConfigureDatabase() - About to call _applicationDbContext.Database.EnsureCreatedAsync()");

            _isDatabaseInitialized = await _applicationDbContext.Database.EnsureCreatedAsync();
            Console.WriteLine($"ConfigureDatabase() - Is Initialized: '{_isDatabaseInitialized}'");

            Status = _isDatabaseInitialized ? "Database created..." : "Database initialized...";
            Console.WriteLine($"ConfigureDatabase() - '{Status}'");
            await Task.Delay(1200);
            Status = string.Empty;
        }
        catch (Exception e)
        {
            Status = e.Message;
            Console.WriteLine($"ConfigureDatabase() - Exception: '{e}'");
            await Task.Delay(5000);
            Status = string.Empty;
            failed = true;
        }

        if (!failed)
        {
            IsVisible = false;
        }
    }
}