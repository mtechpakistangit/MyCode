//#if WINDOWS
//using Microsoft.UI;
//using Microsoft.UI.Windowing;
//using Windows.Graphics;
//#endif
using System;
using System.Windows;

namespace Accounts.MVVM.View;

public partial class Company : ContentPage
{
  //  const int WindowWidth = 600;
    //const int WindowHeight = 600;
    public Company()
	{
		InitializeComponent();
        
//        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
//        {
//#if WINDOWS
//                    var mauiWindow = handler.VirtualView;
//                    var nativeWindow = handler.PlatformView;
//                    nativeWindow.Activate();
//                    IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
//                    WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
//                    AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
//                    appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
//#endif
      // });

        // Get display size
        // Sizing and positioning code for a window

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MaximizedScreen();
    }
    public interface IWindowService
    {
        void CenterWindow();
    }
    //protected override Window(IActivationState activationState) =>
    //   new Window(new AppShell())
    //   {
    //       Width = 700,
    //       Height = 500,
    //       X = 100,
    //       Y = 100
    //   };


#if WINDOWS
    private Microsoft.UI.Windowing.AppWindow GetAppWindow(MauiWinUIWindow window)
    {
        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
        return appWindow;
    }
#endif


    private void MaximizedScreen()
    {
#if WINDOWS
		var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;
        
        var appWindow = GetAppWindow(window);

        switch (appWindow.Presenter)
        {
            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
                {
                    overlappedPresenter.SetBorderAndTitleBar(true, true);
                    overlappedPresenter.IsResizable = false;
                    overlappedPresenter.Maximize();
                    overlappedPresenter.IsModal = false;
                 overlappedPresenter.IsMaximizable=false;
                 // overlappedPresenter.Restore();
                }
                else
                {
                    overlappedPresenter.SetBorderAndTitleBar(true, true);
                 //  overlappedPresenter.Maximize();
                 //   overlappedPresenter.IsMaximizable = false;
                 //   overlappedPresenter.IsResizable = false;
                    //overlappedPresenter.Minimize();
                }

                break;
        }
#endif
    }


}