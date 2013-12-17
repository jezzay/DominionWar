#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

namespace Dominion_War.util
{
    /// <summary>
    /// An assortment of validation and parsing methods
    /// </summary>
    public static class ValidationUtil
    {
        /// <summary>
        /// Parses a string representation of an number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns int value for number</returns>
        public static int ParseStringToNumber(string number)
        {
            int convertedNumber = -1;
            int.TryParse(number, out convertedNumber);
            return convertedNumber;
        }

        /// <summary>
        /// Returns true if given int is valid, ie >= 1 and less than
        /// the Max value for an int
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True if number is valid</returns>
        public static bool ValidNumber(int number)
        {
            return number >= 1 && number < int.MaxValue;
        }

    }
}