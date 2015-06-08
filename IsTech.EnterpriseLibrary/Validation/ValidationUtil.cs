using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IsTech.EnterpriseLibrary.Validation
{
    public static class ValidationUtil
    {
        public static bool IsNumber(string number)
        {
            if (Regex.IsMatch(number, @"^[-+]?\d*\.?\d*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPlus(string number)
        {
            if (Regex.IsMatch(number, @"^\d+(\.\d+)?$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPlusIntegerNotZero(string number)
        {
            if (Regex.IsMatch(number, @"^\+?[1-9][0-9]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPlusIntegerIncludeZero(string number)
        {
            return Regex.IsMatch(number, @"^[1-9]\d*$|0$");
        }

        public static bool IsEmailAddress(string emailAddress)
        {
            if (Regex.IsMatch(emailAddress, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUsPhone(string phone)
        {
            return Regex.IsMatch(phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}");
        }

        public static bool IsPhone(string phone)
        {
            return Regex.IsMatch(phone, @"(^(\d{2,4}[-_£­¡ª]?)?\d{3,8}([-_£­¡ª]?\d{3,8})?([-_£­¡ª]?\d{1,7})?$)|(^0?1[35]\d{9}$)");

        }

        public static bool IsLengthMatch(string validString,int limitLength)
        {
            if (System.Text.UnicodeEncoding.Unicode.GetByteCount(validString) <= limitLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
