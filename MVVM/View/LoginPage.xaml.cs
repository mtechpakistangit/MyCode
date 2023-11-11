using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

using static System.Net.Mime.MediaTypeNames;
//using Windows.UI.WebUI;

namespace Accounts.MVVM.View;

public partial class LoginPage : ContentPage
{


    Hashtable hashtable = new Hashtable(); //for branches hashtable use for two columns
    Hashtable yhashtable = new Hashtable(); //it is for fiscalyear
    public LoginPage()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        
        FillBranches(); //this is for braches its object is below it is in constructor it will be call first
      //  MaximizeScreen();               //FillFiscalYear();

    }
    protected override void OnAppearing()
    {
        //MaximizedScreen();
       // MaximizedPage();
        string Name = Preferences.Get("Name", "Unknown");
        string Branch = Preferences.Get("Branch", "Unknown");
        string FiscalYear = Preferences.Get("FiscalYear", "Unknown");

        if (Name != "Unknown")
        {
            txtUserName.Text = Name;
        }
        if (Branch != "Unknown")
        {
            pCompany.SelectedIndex = Convert.ToInt32(Branch);
        }
        if (FiscalYear != "Unknown")
        {
            pYear.SelectedIndex = Convert.ToInt32(FiscalYear);
        }

        

        

    }
    //protected override void    OnAppearing() { }
    private void KeepNames()
    {
        try
        {
            Preferences.Set("Name", txtUserName.Text);
          Preferences.Set("Branch", pCompany.SelectedIndex.ToString());
            Preferences.Set("FiscalYear", pYear.SelectedIndex.ToString());
        }
        catch( Exception e1) 
        {
            DisplayAlert("Error", e1.Message, "OK");
        }
    }
    //starts here

    //stop here




    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    MaximizedScreen();
    //}





    //#if WINDOWS
    //    private Microsoft.UI.Windowing.AppWindow GetAppWindow(MauiWinUIWindow window)
    //    {
    //        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
    //        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
    //        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
    //        return appWindow;
    //    }
    //#endif


    //    private void MaximizedPage()
    //    {
    //#if WINDOWS
    //		var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;

    //   var appWindow = GetAppWindow(window);

    //        switch (appWindow.Presenter)
    //        {
    //            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
    //                if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
    //                {
    //                    overlappedPresenter.SetBorderAndTitleBar(true, true);
    //                    overlappedPresenter.Restore();
    //                }
    //                else
    //                {
    //                    overlappedPresenter.SetBorderAndTitleBar(false, false);
    //                    overlappedPresenter.Maximize();
    //                    overlappedPresenter.IsMaximizable = false;
    //                    //overlappedPresenter.Minimize();

    //                }

    //                break;
    //        }
    //#endif
    //    }




    //protected override void OnAppearing()
    //{
    //    MaximizeScreen();
    //    // EnableMaximized();

    //}


    //#if WINDOWS
    //    private Microsoft.UI.Windowing.AppWindow GetAppWindow(MauiWinUIWindow window)
    //    {
    //        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
    //        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
    //        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
    //        return appWindow;
    //    }
    //#endif

    //    private void MaximizeScreen()
    //    {
    //#if WINDOWS
    //        var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;

    //        var appWindow = GetAppWindow(window);

    //        switch (appWindow.Presenter)
    //        {
    //            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
    //                //if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
    //                //{
    //                //    overlappedPresenter.SetBorderAndTitleBar(true, true);
    //                //    overlappedPresenter.Restore();
    //                //}
    //                //else
    //                //{
    //                overlappedPresenter.SetBorderAndTitleBar(false, false);
    //                overlappedPresenter.Maximize();
    //                overlappedPresenter.IsResizable = true;


    //                //}

    //                break;
    //        }
    //#endif
    //    }









    private void FillBranches()
    {
        string sSQL; // it is for query sql query will be put in this string
        string sConnString; // it is database connection db connection will be put in this string
        try
        {

            List<string> newItems = new List<string>   //it is a method which is the item source for to add item in Company then access that again to the pCompany
            {
            };

            pCompany.ItemsSource = null; //at the begening pCompany will be empty
            sConnString = Global.GetConnectString(Global.ServerName, Global.DatabaseName); //again here in constring we need two perameters which is serverName and DataBase Name we have to pass it here


            DataTable dtCompany = new DataTable(); //this is datatable of the company save in database so it will be manipulated

            sSQL = "select CompanyId, CompanyName from Company order by CompanyName"; //here is the query as i said at top here we putted query in sql
            dtCompany = Global.ExecuteQuery(sConnString, sSQL); //here is datatable accesses from DB by passing it connection with DB and query which data you need from the DB

            foreach (DataRow dr in dtCompany.Rows) // here you display your desire data like CompanyName by foreach
            {
                newItems.Add(dr["CompanyName"].ToString()); // here it takes data from the newItem
                hashtable.Add(dr["CompanyName"].ToString(),dr["CompanyId"].ToString()); //here is two columns made in DB.

            }
            pCompany.ItemsSource = newItems; //and here the data accessed from the newItem to the pCompany which will show in design
            if (pCompany.Items.Count > 0) //this if statment is used for if the placeholder is empty (dropdown or picker) then select the first item of list
            {
                pCompany.SelectedIndex = 0; //here is the item of the selected item
            }
    
        
        }
        // here if the above statment affected with any of error or missing property then it will throw this message
        catch (Exception ex) 
        {
            DisplayAlert("Connection Error", ex.Message, "OK");
            return;
        }
    }





    private void btnOk_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtUserName.Text))
        {
            DisplayAlert("Blank User", "The user name Cannot be blank", "OK");
            return;
        }
        if (string.IsNullOrEmpty(txtPwd.Text))
        {
            DisplayAlert("Blank Password", "The Password Cannot be blank", "OK");
            return;
        }

        if (pCompany.SelectedIndex < 0)
        {
            DisplayAlert("Branch is not selected", "Please select the Branch", "OK");
            return;
        }
        if(pYear.SelectedIndex < 0)  
        {
            DisplayAlert("Year is not Selected", "Please select the year", "OK");
            return;
        }
        DataTable dtemp = new DataTable();

        string sSQL;
        string sConnString;

        sSQL = "select pass from emp where CName ='" + txtUserName.Text + "'";


        sConnString = Global.GetConnectString(Global.ServerName, Global.DatabaseName);


        dtemp = Global.ExecuteQuery(sConnString, sSQL);
          if(dtemp.Rows.Count == 0) 
        {
            DisplayAlert("Invalide User Name", "User Name is incorrect", "OK");
            return;
        }
        if (dtemp.Rows[0]["pass"].ToString() != txtPwd.Text)
        {
            DisplayAlert("Invalide Pass", "The password is incorrect", "OK");
            return;
        }

        KeepNames(); 
        Navigation.PushAsync(new MtechAccTwo());

        

    }

    private void btnExit_Clicked(object sender, EventArgs e)

    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();

        //DisplayAlert("Is Exit button pressed?", "yes it is... ", "OK");
        // Close the application
        //Device.InvokeOnMainThreadAsync(() =>
        //{
        //    if (Device.RuntimePlatform == Device.WinUI)
        //    {
        //        // For macOS
        //        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        //    }
        //    //else
        //    //{
        //    //    // For other platforms
        //    //    System.Diagnostics.Process.GetCurrentProcess().Kill();
        //    //}
        //});
    }

    //selected item here
    private void pCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.iCompanyId = Convert.ToInt32(hashtable[pCompany.SelectedItem]); /*converting to code*/
        Global.sCompanyName = pCompany.SelectedItem.ToString(); /*SelectedItem company Name*/
    
        
            string selectedOption = pCompany.SelectedItem.ToString();




        FillFiscalYear(); //Fill fiscal year will call 
    }
     
    private void FillFiscalYear()
    {
        string sSQL;


        string sConnString;
        try
        {

            List<string> newItems = new List<string>
            {
            };


            sConnString = Global.GetConnectString(Global.ServerName, Global.DatabaseName);
            yhashtable.Clear(); //it is for to remove all the before data in order to put a new data inside
            pYear.ItemsSource = null;

            DataTable dtFiscalYear = new DataTable();

            sSQL = "select FiscalYearID, FiscalYearName from FiscalYear where CompanyID = " + Global.iCompanyId.ToString() + " order by FiscalYearName desc";
            dtFiscalYear = Global.ExecuteQuery(sConnString, sSQL);

            foreach (DataRow dr in dtFiscalYear.Rows)
            {
                newItems.Add(dr["FiscalYearName"].ToString());
                yhashtable.Add(dr["FiscalYearName"].ToString(), dr["FiscalYearId"].ToString());

            }
            pYear.ItemsSource = newItems;
            if (pYear.Items.Count > 0)
            {
                pYear.SelectedIndex = 0;
            }


        }
        catch (Exception ex)
        {
            DisplayAlert("Connection Error", ex.Message, "OK");
            return;
        }
    }

    private void pYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.iFiscalYear = Convert.ToInt32(pYear.SelectedItem); //it is for selected year to show in placeHolder.
    }

    private void pCompany_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}