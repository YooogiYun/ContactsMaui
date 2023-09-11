using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage( )
    {
        InitializeComponent();

        List<Models.Contact> contacts = ContactRepository.GetContacts();
        listContacts.ItemsSource = contacts;
    }



    private async void listContacts_ItemSelected(object sender , SelectedItemChangedEventArgs e)
    {
        if( listContacts.SelectedItem != null )
        {
            Models.Contact contact = (sender as ListView)?.SelectedItem as Models.Contact;
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.Id}");
        }
        //Contact contact = (sender as ListView)?.SelectedItem as Contact;
        //DisplayAlert(contact?.Name , contact?.Email , "OK");
    }

    private void listContacts_ItemTapped(object sender , ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}