﻿using System.Text.RegularExpressions;

namespace WhereIsMyGame.Core.DomainObjects
{
    public static class Validations
    {

        public static void IfEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void IfDifferent(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int maximum, string message) 
        {
            var length = value.Trim().Length;

            if (length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateExpression(string pattern, string value, string message )
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIsEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIsNull(object object1, string message)
        {
            if (object1 is null)
            {
                throw new DomainException(message);
            }
        }

        #region "Validate Minimun Maximum"
        public static void ValidateMinimunMaximum(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimunMaximum(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimunMaximum(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimunMaximum(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimunMaximum(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        } 
        #endregion

        #region "Validate Less Than"

        public static void ValidateLessThan(decimal value, decimal minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(double value, double minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(float value, float minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(int value, int minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateLessThan(long value, long minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        #endregion
        
        public static void CheckIsFalse(bool value, string message)
        {
            if (!value)
            {
                throw new DomainException(message);
            }
        }
        public static void CheckIsTrue(bool value, string message)
        {
            if (value)
            {
                throw new DomainException(message);
            }
        }

    }
}
