using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
//using Microsoft.UI.Windowing;

namespace Accounts
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            //#if WINDOWS
            //            builder.ConfigureLifecycleEvents(events =>
            //            {
            //                // Make sure to add "using Microsoft.Maui.LifecycleEvents;" in the top of the file 
            //                events.AddWindows(windowsLifecycleBuilder =>
            //                {
            //                    windowsLifecycleBuilder.OnWindowCreated(window =>
            //                    {
            //                        window.ExtendsContentIntoTitleBar = false;
            //                        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
            //                        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
            //                        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
            //                        switch (appWindow.Presenter)
            //                        {
            //                            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
            //                                  overlappedPresenter.SetBorderAndTitleBar(false, false);
            //                                overlappedPresenter.Maximize();
            //                                break;
            //                        }
            //                    });
            //                });
            //            });


            //#endif

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            // important code for disabling the maximizing button in window starts here
#if WINDOWS

            builder.ConfigureLifecycleEvents(events =>
            {
                // Make sure to add "using Microsoft.Maui.LifecycleEvents;" in the top of the file
                events.AddWindows(windowsLifecycleBuilder =>
                {
                    windowsLifecycleBuilder.OnWindowCreated(window =>
                    {
                        window.ExtendsContentIntoTitleBar = false;
                        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);

                        switch (appWindow.Presenter)
                        {
                            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                                //disable the max button
                                overlappedPresenter.IsMaximizable = false;
                               overlappedPresenter.IsModal = false;
                                overlappedPresenter.IsResizable= false;
                               
                              



                                break;
                        }

                        //When user execute the closing method, we can make the window do not close by   e.Cancel = true;.
                        appWindow.Closing += async (s, e) =>
                        {
                            //e.Cancel = false;
                         
                        };
                    });
                });
            });

#endif

            //And it is ends here 

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}