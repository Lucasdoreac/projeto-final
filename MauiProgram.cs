using Microsoft.Extensions.Logging;

namespace appClassePessoaBD
{
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

#if WINDOWS
            // Configurar título da janela no Windows
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                if (handler.PlatformView is Microsoft.UI.Xaml.Window window)
                {
                    window.Title = "Cadastro de Pessoas - PDM 2026";

                    // Forçar atualização da barra de título
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(window.AppWindow.Id);
                    if (appWindow != null)
                    {
                        appWindow.Title = "Cadastro de Pessoas - PDM 2026";
                    }
                }
            });
#endif

            return builder.Build();
        }
    }
}
