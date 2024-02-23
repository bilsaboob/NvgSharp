using System;
using WinApi.User32;
using WinApi.Desktop;
using WinApi.Windows;
using WinApi.Windows.Helpers;

namespace NvgSharp.Samples.D3D11;

internal class Program
{
    [STAThread]
    static int Main(string[] args)
    {
        try
        {
            ApplicationHelpers.SetupDefaultExceptionHandlers();
            var factory = WindowFactory.Create(hBgBrush: IntPtr.Zero);
            
            using (
                var win = factory.CreateWindow(() => new MainWindow(), "NvgSharp.Samples.D3D11",
                    constructionParams: new FrameWindowConstructionParams(),
                    width: 1200,
                    height: 2000,
                    exStyles: WindowExStyles.WS_EX_APPWINDOW | WindowExStyles.WS_EX_NOREDIRECTIONBITMAP))
            {
                win.CenterToScreen();
                win.Show();
                return new RealtimeEventLoop().Run(win);
            }
        }
        catch (Exception ex)
        {
            MessageBoxHelpers.ShowError(ex);
            return 1;
        }
    }
}