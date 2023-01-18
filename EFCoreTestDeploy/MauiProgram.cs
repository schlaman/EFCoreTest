using EFCoreTestDeploy.Data.DbContext;
using EFCoreTestDeploy.Data.Helper;

namespace EFCoreTestDeploy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        Console.WriteLine("Before AddDbContext()");
        Console.WriteLine($"DB Path: '{SqlHelper.GetDbPathEf()}'");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseSqlite($"Data Source={SqlHelper.GetDbPathEf()}");
            options.LogTo(Console.WriteLine);
        });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        Console.WriteLine("After AddDbContext()");

        return builder.Build();
	}
}