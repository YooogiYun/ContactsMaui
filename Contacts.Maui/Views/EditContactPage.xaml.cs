using Contacts.Maui.Models;

namespace Contacts.Maui.Views;
[QueryProperty(nameof(ContactId) , "Id")]
public partial class EditContactPage : ContentPage
{
    private Models.Contact _contact;

    public EditContactPage( )
    {
        InitializeComponent();
    }

    //private void btnCancel_Clicked(object sender , EventArgs e)
    //{
    //    Shell.Current.GoToAsync("..");
    //}

    public string ContactId
    {
        set
        {
            _contact = ContactRepository.GetContactById(Convert.ToInt32(value));
            //lblName.Text = _contact.Name;
        }
    }
}