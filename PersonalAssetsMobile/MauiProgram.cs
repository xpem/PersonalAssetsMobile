using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PersonalAssetsMobile.ViewModels;
using PersonalAssetsMobile.ViewModels.Category;
using PersonalAssetsMobile.ViewModels.Item;
using PersonalAssetsMobile.Views;
using PersonalAssetsMobile.Views.Category;
using PersonalAssetsMobile.Views.Item;
using Services.Category;

namespace PersonalAssetsMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FA6Free-Solid-900.otf", "Icons");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        #region Dependency injections

        #region front

        builder.Services.AddTransient<SignIn>();
        builder.Services.AddTransient<SignInVM>();

        builder.Services.AddTransient<SignUp>();
        builder.Services.AddTransient<SignUpVM>();

        builder.Services.AddTransient<UpdatePassword>();
        builder.Services.AddTransient<UpdatePasswordVM>();

        builder.Services.AddTransient<Main>();
        builder.Services.AddTransient<MainVM>();

        builder.Services.AddTransient<CategoryList>();
        builder.Services.AddTransient<CategoryListVM>();

        builder.Services.AddTransient<CategoryEdit>();
        builder.Services.AddTransient<CategoryEditVM>();

        builder.Services.AddTransient<CategoryDisplay>();
        builder.Services.AddTransient<CategoryDisplayVM>();

        builder.Services.AddTransient<ItemEdit>();
        builder.Services.AddTransient<ItemEditVM>();

        #endregion

        #region services

        builder.Services.AddScoped<ICategoryServices, CategoryServices>();

        #endregion

        #endregion


        return builder.Build();
    }
}
