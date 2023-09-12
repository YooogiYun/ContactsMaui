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
        var new_contact = contacts.FirstOrDefault(c => c.Id == id);

        if( new_contact == null ) return null;

        return new Contact
        {
            Id = new_contact.Id ,
            Name = new_contact.Name ,
            Email = new_contact.Email ,
            Address = new_contact.Address ,
            Phone = new_contact.Phone ,
        };
    }
    public static void UpdateContact(int contactId , Contact contact)
    {
        if( contact.Id != contactId ) return;
        var contact2Update = contacts.FirstOrDefault(c => c.Id == contactId);
        if( contact2Update != null )
        {
            //AutoMapper
            contact2Update.Name = contact.Name;
            contact2Update.Email = contact.Email;
            contact2Update.Phone = contact.Phone;
            contact2Update.Address = contact.Address;
        }
    }

    public static void AddContact(Contact contact)
    {
        var maxId = contacts.Max(x => x.Id);
        contact.Id = maxId + 1;
        contacts.Add(contact);
    }

    public static void DeleteContact(int contactId)
    {
        var contact = contacts.FirstOrDefault(x => x.Id == contactId);
        if( contact != null )
        {
            contacts.Remove(contact);
        }
    }
    public static List<Contact> SearchContacts(string filterText)
    {
        var filted_contacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText , StringComparison.OrdinalIgnoreCase))?.ToList();

        if( filted_contacts.Count <= 0 || filted_contacts is null )
        {
            filted_contacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText , StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return filted_contacts;
        }

        if( filted_contacts.Count <= 0 || filted_contacts is null )
        {
            filted_contacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText , StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return filted_contacts;
        }

        if( filted_contacts.Count <= 0 || filted_contacts is null )
        {
            filted_contacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText , StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return filted_contacts;
        }

        return filted_contacts;
    }
}
