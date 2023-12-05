
public delegate int CalculateDelegate(int x, int y);

public sealed class Program
{
    public static event CalculateDelegate CalculateEvent;

    internal static void Main()
    {
        CalculateEvent += Calculate;
        CalculateEvent += Calculate;

        Console.WriteLine($"result = {WrapperMethod(CalculateEvent)}");
        Console.ReadLine();

        AddNumberToList("Carl", "+14845211106");
        AddNumberToList("", "0455245306");
        AddNumberToList("", "7985621375");
        AddNumberToList("", "3782456751");
        AddNumberToList("", "5730097975");
        AddNumberToList("", "0523428733");
        AddNumberToList("Гриша", "+380630206144");
        AddNumberToList("Андрюха", "+380931775306");
        AddNumberToList("Вика", "+380504234312");
        AddNumberToList("Ден", "+380634789542");
        AddNumberToList("Артур", "+380951052345");
        AddNumberToList("Liam", "+14845691375");
        AddNumberToList("James", "+16102458141");
        AddNumberToList("William", "+15853042197");
        AddNumberToList("Olivia", "+14842989313");
        AddNumberToList("", "+56345211106");
        AddNumberToList("", "+23455691375");
        AddNumberToList("", "+76582458141");
        AddNumberToList("", "+64563042197");
        AddNumberToList("", "+54642989313");

        var contact = contactList.FirstOrDefault(x => x.Name.EndsWith('р'));
        Console.WriteLine($"Contact with 'p' in the end: Name: {contact.Name} Number: {contact.Number}");

        var ukrainianNumbers = contactList.Where(x => x.Number.StartsWith("+380"));
        Console.WriteLine("\nUkrainian numbers:");
        foreach (var numbers  in ukrainianNumbers)
        {
            Console.WriteLine($"Name: {numbers.Name} Number: {numbers.Number}");
        }

        var updatedContacts = contactList
            .Where(x => x.Number.StartsWith('0'))
            .Select(x => "+38" + x.Number);
        Console.WriteLine("\nUpdated numbers:");
        foreach (var numbers in updatedContacts)
        {
            Console.WriteLine($"Number: {numbers}");
        }

        var orderByContacts = contactList.OrderBy(x => x.Name);
        Console.WriteLine("\nOrdered By Name numbers:");
        foreach (var numbers in orderByContacts)
        {
            Console.WriteLine($"Name: {numbers.Name} Number: {numbers.Number}");
        }


        Console.WriteLine("\nDo all numbers have a telephone country code?");
        var countryCode = contactList.All(x => x.Number.StartsWith('+'));
        Console.WriteLine(countryCode);


        Console.WriteLine("\nLast 5 numbers int contact list:");
        var lastContacts = contactList.TakeLast(5);
        foreach (var numbers in lastContacts)
        {
            Console.WriteLine($"Name: {numbers.Name} Number: {numbers.Number}");
        }
        Console.ReadLine();
    }

    public static int WrapperMethod(CalculateDelegate calc)
    {
        return TryCatchMethod(calc);
    }

    public static int TryCatchMethod(CalculateDelegate calc)
    {
        try
        {
            return calc(new Random().Next(50), new Random().Next(100)) + calc(new Random().Next(50), new Random().Next(100));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return 0;
        }
    }

    public static int Calculate(int x, int y) => x + y;

    public static void AddNumberToList(string name, string number)
    {
        Contact contact = new Contact() { Name = name, Number = number };
        contactList.Add(contact);
    }

    public static List<Contact> contactList = new List<Contact>();
}

public sealed class Contact
{
    public string Name { get; set; }
    public string Number { get; set; }
}






