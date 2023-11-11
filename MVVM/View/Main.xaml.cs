//using Android.Views;

namespace Accounts.MVVM.View;

public partial class MtechAccTwo : ContentPage
{
    int initialHeight = 550;
    int initialWidth = 600;
    // public void Close();
    public MtechAccTwo()
    {

        InitializeComponent();
        // NavigationPage.SetBackButtonTitle(this, "" );
        //  NavigationPage.SetBackButtonTitle(this, ""); // Set it twice to handle Android and iOS
        NavigationPage.SetHasBackButton(this, false);



    }

    //protected override bool OnBackButtonPressed()
    //{
    //    // To disable the back button behavior, return true
    //    return true;
    //}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        MaximizedScreen();
    
        //  MaximizeClicked();
        // mnuCompany_Clicked();
    }

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
                    overlappedPresenter.IsResizable = true;
                    overlappedPresenter.Maximize();
                    overlappedPresenter.IsModal = false;
                    overlappedPresenter.IsMaximizable=true;
                 // overlappedPresenter.Restore();
                }
                else
                {
                    overlappedPresenter.SetBorderAndTitleBar(true, true);
                   overlappedPresenter.Maximize();
                    overlappedPresenter.IsMaximizable = true;
                    overlappedPresenter.IsResizable = true;
                    //overlappedPresenter.Minimize();
                }

                break;
        }
#endif
    }

    private void MaximizeClicked()
    {
#if WINDOWS
        var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;

        var appWindow = GetAppWindow(window);
        

        switch (appWindow.Presenter)
        {
        
            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
            overlappedPresenter.IsMaximizable = !overlappedPresenter.IsMaximizable;

                break;
        }
#endif
    }





    private void btnAccountStatement_Clicked(object sender, EventArgs e)
    {

    }

    private void btnPrintOtherReports_Clicked(object sender, EventArgs e)
    {

    }

    private void btnAccountsMaster_Clicked(object sender, EventArgs e)
    {

    }

    private void btnJV_Clicked(object sender, EventArgs e)
    {

    }

    private void btnPaymentVoch_Clicked(object sender, EventArgs e)
    {

    }

    private void btnReciept_Clicked(object sender, EventArgs e)
    {

    }

    private void btnExpenses_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuCompany_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Company());
        this.Window.Height = initialHeight;
        this.Window.Width = initialWidth;
        this.Window.X = 300;
        this.Window.Y = 50;
       
      






    }
    public interface IWindowService
    {
        void CenterWindow();
    }

    private void mnuBranch_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuFiscalYear_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuUser_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuAccountType_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuTransactionType_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuAccountMaster_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuCostCentre_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuDepreciationMethod_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuFixedAssets_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuLinkAccounts_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuAccountSetup_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuAccountPosting_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuAccountGenerator_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuJV_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuPaymentVoch_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuReciept_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuExpenses_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuPostDepreciation_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuAccountsStatements_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuChartOfAccount_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuPrintOtherReports_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuCostCentreLedger_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuTransactionReports_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuTransactionHistory_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuCloseFiscalYear_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuDiscardCurrentYear_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuCopyAccountMaster_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuBackupData_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuCreatOpeningBalance_Clicked(object sender, EventArgs e)
    {

    }

    private void mnuLogOff_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void mnuExit_Clicked(object sender, EventArgs e)
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();

    }
    //public void Hide();{}
    private void mnuCloseThePage_Clicked(object sender, EventArgs e)
    {
        // System.Diagnostics.Process.GetCurrentProcess().Close();     
        //Window.Show();
        // this.closed();
         
    }
}