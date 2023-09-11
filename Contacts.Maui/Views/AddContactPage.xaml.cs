namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage( )
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender , EventArgs e)
    {
        //Shell.Current.GoToAsync("..");    //.. 
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}"); // Must use abs path to identity the Mainpage by slash slash
    }
}