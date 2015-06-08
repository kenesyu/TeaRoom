using System;
using System.Collections.Generic;
using System.Text;

namespace IsTech.EnterpriseLibrary.Validation
{
    public class ValidationHelper
    {

        public static bool ValidData(string value, ValidRuler ruler)
        {
            switch (ruler.ValidType)
            {
                case ValidationType.Required:
                    if (value == string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case ValidationType.RequiredDropDown:
                    if (value == "0")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case ValidationType.RequiredDropDownEmail:
                    if (value == "0")
                    {
                        return true;
                    }
                    else
                    {
                        return ValidationUtil.IsEmailAddress(value);
                    }
                case ValidationType.Number:
                    return ValidationUtil.IsNumber(value);
                case ValidationType.Plus:
                    return ValidationUtil.IsPlus(value);
                case ValidationType.PlusIntegerNotZero:
                    return ValidationUtil.IsPlusIntegerNotZero(value);
                case ValidationType.EmptyOrPlusIntegerNotZero:
                    if (value == string.Empty) return true;
                    return ValidationUtil.IsPlusIntegerNotZero(value);
                case ValidationType.DateTimeAfterNow:
                    if (value == string.Empty) return true;

                    DateTime dateTimeValueForAfter = Convert.ToDateTime(value);

                    if (dateTimeValueForAfter >= DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ValidationType.DateTimeBeforeNow:
                    if (value == string.Empty) return true;

                    DateTime dateTimeValueForBefore = Convert.ToDateTime(value);

                    if (dateTimeValueForBefore <= DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ValidationType.Email:
                    return ValidationUtil.IsEmailAddress(value);
                case ValidationType.MulitEmail:
                    {
                        string[] temp = value.Split(';');
                        foreach (string email in temp)
                        {
                            if (email != string.Empty)
                            {
                                if (!ValidationUtil.IsEmailAddress(email))
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                default:
                    return true;
            }
        }
    }
}
