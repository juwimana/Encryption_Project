using System;
using System.Text;
using System.Xml.Serialization;

namespace Encryption_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding ascii = Encoding.ASCII; ;
            Encoding unicode = Encoding.Unicode;

            byte[] unicode_bytes;
            byte[] ascii_bytes = Encoding.ASCII.GetBytes("Hello");

            Choice:
            Console.WriteLine("Enter 1 to Encrypt or 2 to Decode:");
            int selection = Convert.ToInt32(Console.ReadLine());

            if(selection == 1)
            {
                Console.WriteLine("Enter string to be encrypted:");
                string str = Console.ReadLine();

                //2 different encodings
                ascii = Encoding.ASCII;
                unicode = Encoding.Unicode;

                //Convert string into unicode
                unicode_bytes = Encoding.Unicode.GetBytes(str);

                //convert unicode to ascii
                ascii_bytes = Encoding.Convert(unicode, ascii, unicode_bytes);

                Console.Clear();
                Console.WriteLine("Your encryption code is given below:");

                //Encode Message
                for (int i = 0; i < ascii_bytes.Length; i++)
                {
                    ascii_bytes[i] -= 7;
                }

                //diplay bytes array
                // Merge all bytes into a string of bytes  
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < ascii_bytes.Length; i++)
                {
                    builder.Append(ascii_bytes[i].ToString());
                }
                Console.WriteLine(builder.ToString());
                Console.ReadKey();
            }
            else if(selection == 2)
            {
                Console.WriteLine("Enter string to be decoded:");
                string str = Console.ReadLine();

                //Decode Message
                for (int i = 0; i < ascii_bytes.Length; i++)
                {
                    ascii_bytes[i] += 7;
                }

                //convert new byte into char[] then into a string
                char[] ascii_char = new char[ascii.GetCharCount(ascii_bytes, 0, ascii_bytes.Length)];
                ascii.GetChars(ascii_bytes, 0, ascii_bytes.Length, ascii_char, 0);
                string ascii_string = new string(ascii_char);

                Console.Clear();
                Console.WriteLine("Your decoded message is given below:");

                Console.WriteLine(ascii_string);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Select either choice 1 (Encoder) or 2(Decode):");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Do you want to encrypt or decode any other message. Enter yes or no:");
            string decision = Console.ReadLine();

           while(decision == "yes")
            {
                goto Choice;
            }

            Console.Clear();
            Console.WriteLine("Thank you for using our service!");
            Console.ReadKey();
        }
    }
}
