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
    private void btnUpdate_Clicked(object sender , EventArgs e)
    {
        //if( nameValidator.IsNotValid )
        //{
        //    DisplayAlert("error" , "name is required." , "ok");
        //    return;
        //}

        //if( emailVaildator.IsNotValid )
        //{
        //    foreach( var error in emailVaildator.Errors )
        //    {
        //        DisplayAlert("Error" , error.ToString() , "OK");
        //    }
        //    return;
        //}

        _contact.Name = contactCtrl.Name;
        _contact.Address = contactCtrl.Address;
        _contact.Email = contactCtrl.Email;
        _contact.Phone = contactCtrl.Phone;

        ContactRepository.UpdateContact(_contact.Id , _contact);
        Shell.Current.GoToAsync("..");
    }

    private void btnCancel_Clicked(object sender , EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            _contact = ContactRepository.GetContactById(Convert.ToInt32(value));
            //lblName.Text = _contact.Name;
            contactCtrl.Name = _contact?.Name;
            contactCtrl.Address = _contact?.Address;
            contactCtrl.Email = _contact?.Email;
            contactCtrl.Phone = _contact?.Phone;
        }
    }

    private void contactCtrl_OnError(object sender , string e)
    {
        DisplayAlert("Error" , e , "OK");
    }
}