using System;
using System.Collections.Generic;
using System.Text;

namespace IsTech.EnterpriseLibrary.Validation
{
    public enum ValidationType
    {
        Required,
        Number,
        Plus,
        PlusIntegerNotZero,
        DateTimeAfterNow,
        DateTimeBeforeNow,
        EmptyOrPlusIntegerNotZero,
        Email,
        MulitEmail,
        RequiredDropDown,
        RequiredDropDownEmail
    }
}
