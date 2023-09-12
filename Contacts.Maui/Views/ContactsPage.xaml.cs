using Contacts.Maui.Models;
using System.Collections.ObjectModel;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage( )
    {
        InitializeComponent();

    }

    protected override void OnAppearing( )
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        LoadContacts();
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

    private void btnAdd_Clicked(object sender , EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender , EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;
        if( contact != null )
        {
            ContactRepository.DeleteContact(contact.Id);
        }

        LoadContacts();
    }

    private void LoadContacts( )
    {
        ObservableCollection<Models.Contact> contacts = new ObservableCollection<Models.Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender , TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Models.Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

}