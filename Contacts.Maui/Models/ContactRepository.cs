namespace Contacts.Maui.Models;

internal class ContactRepository
{
    public static List<Contact> contacts = new List<Contact>(){
            new Contact{Name="1",Email="1@Email.com",Id=1},
            new Contact{Name="2",Email="2@Email.com",Id=2},
            new Contact{Name="3",Email="4@Email.com",Id=3},
            new Contact{Name="4",Email="4@Email.com",Id=4},
        };

    public static List<Contact> GetContacts( ) => contacts;
    public static Contact GetContactById(int id)
    {
        return contacts.FirstOrDefault(c => c.Id == id);
    }
}
