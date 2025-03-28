// Trey Walker
// Date: March 28, 2025
// Lab Name: Vigenere Cipher

using System;
using System.Diagnostics;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("This program encrypts the characters of a message using the Vigenere method.");

        Console.WriteLine("Please enter the message:");
        string message = Console.ReadLine();

        Console.WriteLine("Please enter an encryption key:");
        string key = Console.ReadLine();

        if (!IsValidInput(message))
        {
            Console.WriteLine("Sorry, we only support lower-case letters for the message.");
        }
        else if (!IsValidInput(key))
        {
            Console.WriteLine("Sorry, we only support lower-case letters for the encryption key.");
        }
        else
        {
            string encryptedMessage = ShiftMessage(message, key);
            Console.WriteLine("Here is the encrypted message:");
            Console.WriteLine(encryptedMessage);
        }

       
    }

    
    public static bool IsLowercaseLetter(char c)
    {
        return c >= 'a' && c <= 'z';
    }

    public static void TestIsLowercaseLetter()
    {
        Debug.Assert(IsLowercaseLetter('a'));
        Debug.Assert(IsLowercaseLetter('b'));
        Debug.Assert(IsLowercaseLetter('z'));
        Debug.Assert(!IsLowercaseLetter('A'));
        Debug.Assert(!IsLowercaseLetter('`'));
        Debug.Assert(!IsLowercaseLetter('{'));
    }

    
    public static bool IsValidInput(string input)
    {
        if (input == null)
        {
            return false;
        }
        foreach (char c in input)
        {
            if (!IsLowercaseLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    public static void TestIsValidInput()
    {
        Debug.Assert(IsValidInput("lowercase"));
        Debug.Assert(IsValidInput(""));
        Debug.Assert(!IsValidInput("with space"));
        Debug.Assert(!IsValidInput("UpperCase"));
        Debug.Assert(!IsValidInput("has1digit"));
        Debug.Assert(!IsValidInput(null));
    }

       public static char ShiftLetter(char messageChar, char keyChar)
    {
        int messagePos = messageChar - 'a';
        int keyPos = keyChar - 'a';
        int shiftedPos = (messagePos + keyPos) % 26;
        return (char)('a' + shiftedPos);
    }

    public static void TestShiftLetter()
    {
        Debug.Assert(ShiftLetter('e', 'b') == 'f');
        Debug.Assert(ShiftLetter('n', 'c') == 'p');
        Debug.Assert(ShiftLetter('d', 'b') == 'e');
        Debug.Assert(ShiftLetter('z', 'b') == 'a');
        Debug.Assert(ShiftLetter('z', 'z') == 'y');
        Debug.Assert(ShiftLetter('a', 'a') == 'a');
    }

    
    public static string ShiftMessage(string message, string key)
    {
        StringBuilder encryptedMessage = new StringBuilder();
        int keyIndex = 0;

        for (int i = 0; i < message.Length; i++)
        {
            char messageChar = message[i];
            char keyChar = key[keyIndex % key.Length];
            encryptedMessage.Append(ShiftLetter(messageChar, keyChar));
            keyIndex++;
        }

        return encryptedMessage.ToString();
    }

    public static void TestShiftMessage()
    {
        Debug.Assert(ShiftMessage("endzz", "b") == "foeaa");
        Debug.Assert(ShiftMessage("endzz", "bc") == "fpeba");
        Debug.Assert(ShiftMessage("aaa", "abc") == "abc");
        Debug.Assert(ShiftMessage("zzz", "a") == "zzz");
        Debug.Assert(ShiftMessage("hello", "world") == "dzeqm");
    }
}