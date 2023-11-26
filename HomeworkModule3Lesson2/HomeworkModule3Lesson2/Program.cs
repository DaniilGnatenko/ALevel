
internal sealed class Contact
{
    internal string Name { get; set; }
    internal string Number { get; set; }

}

internal sealed class NumberStorage
{
    private Dictionary<string, List<Contact>> _storage = new();
    private List<Contact> _englishContacts = new();
    private List<Contact> _ukrainianContacts = new();
    private List<Contact> _unknownContacts = new();
    private List<Contact> _numbers = new();

    public void AddNumberToList(string name, string number)
    {
        Contact contact = new Contact() { Name = name, Number = number };
        if (number.Contains("+1"))
        {
            _englishContacts.Add(contact);
        }
        else if (number.Contains("+380"))
        {
            _ukrainianContacts.Add(contact);
        }
        else if (number.Contains("+") && string.IsNullOrEmpty(name))
        {
            _unknownContacts.Add(contact);
        }
        else
        {
            _numbers.Add(contact);
        }

    }

    public void AddContactsToStorage()
    {
        _storage.Add("English", _englishContacts);
        _storage.Add("Ukrainian", _ukrainianContacts);
        _storage.Add("#", _unknownContacts);
        _storage.Add("Number", _numbers);
    }

    public void ShowContacts()
    {
        foreach (KeyValuePair<string, List<Contact>> kvp in _storage)
        {
            List<Contact> sortedContacts = kvp.Value.OrderByDescending(y => y.Number).ToList();
            foreach (Contact contact in sortedContacts)
            {
                if (string.IsNullOrEmpty(contact.Name))
                {
                    Console.WriteLine($"Key: {kvp.Key}. Number: {contact.Number}");
                }
                else 
                {
                    Console.WriteLine($"Key: {kvp.Key}. Name: {contact.Name} Number: {contact.Number}");
                }
                
            }
            
        }
    }

}

internal class Program
{
    public static void Main(string[] args)
    {
        NumberStorage phoneBook = new NumberStorage();
        phoneBook.AddNumberToList("Carl", "+14845211106");
        phoneBook.AddNumberToList("", "0455245306");
        phoneBook.AddNumberToList("", "7985621375");
        phoneBook.AddNumberToList("", "3782456751");
        phoneBook.AddNumberToList("", "5730097975");
        phoneBook.AddNumberToList("", "0523428733");
        phoneBook.AddNumberToList("Гриша", "+380630206144");
        phoneBook.AddNumberToList("Андрюха", "+380931775306");
        phoneBook.AddNumberToList("Вика", "+380504234312");
        phoneBook.AddNumberToList("Ден", "+380634789542");
        phoneBook.AddNumberToList("Артур", "+380951052345");
        phoneBook.AddNumberToList("Liam", "+14845691375");
        phoneBook.AddNumberToList("James", "+16102458141");
        phoneBook.AddNumberToList("William", "+15853042197");
        phoneBook.AddNumberToList("Olivia", "+14842989313");
        phoneBook.AddNumberToList("", "+56345211106");
        phoneBook.AddNumberToList("", "+23455691375");
        phoneBook.AddNumberToList("", "+76582458141");
        phoneBook.AddNumberToList("", "+64563042197");
        phoneBook.AddNumberToList("", "+54642989313");

        phoneBook.AddContactsToStorage();
        phoneBook.ShowContacts();

        Console.ReadLine();
    }

}



