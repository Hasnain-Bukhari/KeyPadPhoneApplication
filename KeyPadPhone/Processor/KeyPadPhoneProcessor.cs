using System;
using System.Collections.Generic;

namespace KeyPadPhone.Processor {
    /// <summary>
    /// This class processes the input from a phone keypad and converts it to a string.
    /// It handles the mapping of keys to letters, as well as the special cases for space and backspace.
    /// </summary>
    public class KeyPadPhoneProcessor
    {
        // Keypad mapping with reference to phone keypad
        private readonly Dictionary<char, string> _keypad = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " },
            { '*', "" },
            { '#', "" }
        };
        /// <summary>
        /// Processes the input string from the keypad and converts it to a string.
        /// </summary>
        /// <param name="input">The input string from the keypad.</param>
        /// <returns>The converted string.</returns>
        /// <exception cref="ArgumentException">Thrown when the input is invalid. Empty string or no ending sign</exception>
        public string ProcessInput(string input)
        {
            // Check if the input is null or empty and if it ends with '#'
            if (string.IsNullOrEmpty(input) || input[^1] != '#')
            {
                throw new ArgumentException("Invalid input. Must finish with #");
            }

            List<char> result = new List<char>();
            char? currentBtn = null;
            var pressCount = 0;
            // Iterate through each character in the input string
            // and process it according to the keypad mapping
            // and the rules for space and backspace
            // The '#' character is used to indicate the end of the input
            // The '*' character is used to indicate a backspace
            // The ' ' character is used to indicate a space
            foreach (char c in input)
            {
                if (c == '#') {
                    break;
                }
                else if (c == '*') {
                    currentBtn = null;
                    pressCount = 0;
                }
                else if (c == ' ') {
                    string letters = _keypad[(char)currentBtn];
                    result.Add(letters[(pressCount - 1) % letters.Length]);
                    currentBtn = null;
                    pressCount = 0;
                }
                else if (_keypad.ContainsKey(c))   {
                    if (currentBtn == c) {
                        pressCount++;
                    }
                    else   {
                        if (currentBtn != null) {
                            string letters = _keypad[(char)currentBtn];
                            result.Add(letters[(pressCount - 1) % letters.Length]);
                        }
                        currentBtn = c;
                        pressCount = 1;
                    }
                }
            }
 
            if (currentBtn != null)
            {
                string letters = _keypad[(char)currentBtn];
                result.Add(letters[(pressCount - 1) % letters.Length]);
            }

            return new string(result.ToArray());
        }
    }
}