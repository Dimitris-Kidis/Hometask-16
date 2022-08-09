using System;
using System.Globalization;
using System.Text;



// 1. Use encodings in writing to file stream ✅
// 2. Use string formatting, searching and comparing ✅
// 3. Use TimeSpan ✅
// 4. Use DateTime ✅
// 5. Use DateTimeOffset ✅
// 6. Use TimeZone ✅
// 7. Use CultureInfo when working with strings & numbers ✅
// 8. Implement IDisposable
// 9. Use finalizers





namespace App
{
    class Program
    {
        public static void Main(string[] args)
        {

            // Encodings
            string exampleString = "The Moon is bright";

            Encoding utf8Enconding = Encoding.GetEncoding("utf-8");
            Encoding utf16Enconding = Encoding.GetEncoding("utf-16");
            Encoding utf32Enconding = Encoding.GetEncoding("utf-32");
            Encoding asciiEnconding = Encoding.ASCII;

            byte[] utf8Bytes = utf8Enconding.GetBytes(exampleString);
            byte[] utf16Bytes = utf16Enconding.GetBytes(exampleString);
            byte[] utf32Bytes = utf32Enconding.GetBytes(exampleString);
            byte[] asciiBytes = asciiEnconding.GetBytes(exampleString);


            Console.WriteLine($"\"{exampleString}\" in bytes:");
            Console.WriteLine("UTF8: " + utf8Bytes.Length);
            Console.WriteLine("UTF16: " + utf16Bytes.Length);
            Console.WriteLine("UTF32: " + utf32Bytes.Length);
            Console.WriteLine("ASCII: " + asciiBytes.Length);

            string asciiString = asciiEnconding.GetString(asciiBytes);
            string utf8String = utf8Enconding.GetString(utf8Bytes);
            string utf16String = utf16Enconding.GetString(utf16Bytes);
            string utf32String = utf32Enconding.GetString(utf32Bytes);

            //Console.WriteLine(asciiString);
            //Console.WriteLine(utf8String);
            //Console.WriteLine(utf16String);
            //Console.WriteLine(utf32String);

            // String formatting, searching & comparing
            var peopleList = new List<Person>
            {
                new Person("John", 23, "st. Lupu 42", "069435344"),
                new Person("Sia", 31, "st. Armeneasca 11", "068311145"),
                new Person("Helga", 18, "st. Cel Mare 84", "069738423"),
                new Person("Michael", 29, "st. Creanga 3", "074484374"),
                new Person("Philipp", 30, "st. Bucuresti 72", "069942741")
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   Name   |  Age  |       Address       |   Number");
            foreach (var item in peopleList)
            {
                Console.WriteLine(String.Format("{0, -12} {1, -5}   {2, -21} {3, -10}", item.Name, item.Age, item.Address, item.PhoneNumber));
            }

            string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing " +
                            "elit, sed do eiusmod fire incididunt ut labore et" +
                            " dolore magna aliqua. Ut enim ad minim veniam, quis" +
                            " nostrud exercitation ullamco laboris nisi ut aliquip" +
                            " ex ea commodo truth";
            string loremUpperCase = lorem.ToUpper();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nDoes a text start with \"Lorem\"? Answer: " + lorem.StartsWith("Lorem"));
            Console.WriteLine("Does a text contain \"Fire\"? Answer: " + lorem.Contains("fire"));
            Console.WriteLine("Does a text end with \"truth\"? Answer: " + lorem.EndsWith("truth"));

            Console.WriteLine("\nDoes lorem equal to \"water\"? Answer: " + lorem.Equals("water"));
            Console.WriteLine("\"lorem\" equals \"loremUpperCase\"? Answer: " + lorem.Equals(loremUpperCase, StringComparison.CurrentCultureIgnoreCase));

            // TimeSpan & DateTime
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nTimeSpan from now to New Year 2023: "); 
            DateTime launchDate = new DateTime(2023, 1, 1, 0, 0, 0);
            DateTime now = DateTime.Now;
            TimeSpan ts = launchDate - now;
            Console.WriteLine("TimeSpan: {0}", ts.ToString());
            Console.WriteLine("Days: {0}, Hours: {1}, Minutes: {2}, Seconds: {3}, Milliseconds: {4}, Ticks: {5}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds, ts.Ticks);

            // DateTimeOffset
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DateTimeOffset offset = new DateTimeOffset(2000, 7, 5, 15, 00, 0, new TimeSpan(-2, 0, 0));
            TimeSpan elapsedTime = new TimeSpan(2, 0, 0);
            DateTimeOffset value = offset.Add(elapsedTime);
            Console.WriteLine("\nDateTimeOffset is {0}", value);


            // TimeZone
            TimeZone zone = TimeZone.CurrentTimeZone;
            DateTime dateOfBirth = new DateTime(2000, 7, 5, 15, 0, 0);
            Console.WriteLine(zone.GetUtcOffset(dateOfBirth));

            Console.WriteLine("Local time zone: {0}", TimeZoneInfo.Local.DisplayName);


            // CultureInfo
            DateTime dt = new DateTime(2000, 7, 5);
            CultureInfo infoMD = new CultureInfo("ro-MD");
            CultureInfo infoUS = new CultureInfo("en-US");
            Console.WriteLine(dt.ToString(infoMD));
            Console.WriteLine(dt.ToString(infoUS));


            // IDisposable
            TextReader tr = null;
            try
            {
                tr = new StreamReader(@"C:\Users\dmitrii.romanenco\Downloads\hometask16.txt");
                string s = tr.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nThe content of the file: \n" + s);
            }
            catch (Exception ex) { }
            finally
            {
                if (tr != null)
                {
                    tr.Dispose();
                }
            }

            // Finalizer

        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Person(string name, int age, string address, string phoneNumber)
        {
            Name = name;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }



    //public class Base : IDisposable
    //{
    //    private bool isDisposed = false;
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this); 
    //    }
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!isDisposed)
    //        {
    //            if (disposing)
    //            {
    //            }
    //        }
    //        isDisposed = true;
    //    }
    //    ~Base()
    //    {
    //        Dispose(false);
    //    }
    //}


}