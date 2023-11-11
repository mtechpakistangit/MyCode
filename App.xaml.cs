using Accounts.MVVM.View;
using System.Security.Cryptography;

//using Android.Service.Controls.Templates;

namespace Accounts;

public partial class App : Application
{
    public App()
    {


        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA1ODc0OUAzMjMwMmUzNDBQRm51MkMrSW00cUxTHJwZWNaS2VMM1pzWUtwd0dUWk0vT3dZL3E4cDZBPQ==");
        /*this. */
        InitializeComponent();
        


        //Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        //{
        //    var nativeWindow = handler.PlatformView;
        //    nativeWindow.Activate();
        //    IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
        //    WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
        //    AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

        //    var presenter = appWindow.Presenter as OverlappedPresenter;
        //    presenter.IsResizable = false;
        //    presenter.IsMaximizable = false;

        //});


        var pagenav = new NavigationPage(new LoginPage());
        MainPage = pagenav;
        pagenav.BarBackground = Colors.Blue;
        //pagenav.BarTextColor = Colors.White;
        // Set the preferred window size to prevent the maximize button from appearing
        //ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 200));
        //ApplicationView.GetForCurrentView().TryResizeView(new Size(200, 200));

      
    }
    
  


    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        const int newWidth = 515;
        const int Newheight = 535;

        window.X = 500;
        window.Y = 50;
        window.Width = newWidth;
        window.Height = Newheight;
      
        return window;

      
            // Navigate to the next page

        }
   

    //protected override void OnLaunched(LaunchActivatedEventArgs args)
    //{
    //    base.OnLaunched(args);

    //    var currentWindow = Application.Windows[0].Handler.PlatformView;
    //    IntPtr _windowHandle = WindowNative.GetWindowHandle(currentWindow);
    //    var windowId = Win32Interop.GetWindowIdFromWindow(_windowHandle);

    //    AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
    //    var presenter = appWindow.Presenter as OverlappedPresenter;
    //    presenter.IsResizable = false;
    //    presenter.IsMaximizable = false;
    //    presenter.IsMinimizable = false;
    //}
}


