#if WINDOWS
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using WinRT.Interop;

namespace appClassePessoaBD.Platform.Windows
{
    public static class WindowTitleHelper
    {
        public static void SetWindowTitle(object window, string title)
        {
            if (window is Microsoft.UI.Xaml.Window nativeWindow)
            {
                nativeWindow.Title = title;
            }
        }
    }
}
#endif
