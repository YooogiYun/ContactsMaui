namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContactControl( )
    {
        InitializeComponent();
    }

    public string Name
    {
        get => entryName.Text;
        set => entryName.Text = value;
    }
    public string Email
    {
        get => entryEmail.Text;
        set => entryEmail.Text = value;
    }

    public string Phone
    {
        get => entryPhone.Text;
        set => entryPhone.Text = value;
    }

    public string Address
    {
        get => entryAddress.Text;
        set => entryAddress.Text = value;
    }

    private void btnSave_Clicked(object sender , EventArgs e)
    {
        if( nameValidator.IsNotValid )
        {
            //Alert only for page, not for view
            //DisplayAlert("error" , "name is required." , "ok");
            OnError?.Invoke(sender , "name is required.");
            return;
        }

        if( emailVaildator.IsNotValid )
        {
            foreach( var error in emailVaildator.Errors )
            {
                //DisplayAlert("Error" , error.ToString() , "OK");
                OnError?.Invoke(sender , error.ToString());
            }
            return;
        }

        OnSave?.Invoke(sender , e);
    }

    private void btnCancel_Clicked(object sender , EventArgs e)
    {
        OnCancel?.Invoke(sender , e);
    }
}
