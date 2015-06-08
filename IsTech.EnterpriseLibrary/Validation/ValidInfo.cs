using System;
using System.Collections.Generic;
using System.Text;

namespace IsTech.EnterpriseLibrary.Validation
{
    public class ValidInfo
    {
        public ValidInfo(string controlToValidate,string fieldName)
        {
            this.ControlToValidate = controlToValidate;
            this.FieldName = fieldName;
        }

        public ValidInfo(string controlToValidate, string fieldName, ValidRuler ruler)
        {
            this.ControlToValidate = controlToValidate;
            this.FieldName = fieldName;
            this.Rulers.Add(ruler);
        }

        public string ControlToValidate { get; set; }

        public string FieldName { get; set; }

        private List<ValidRuler> _rulers = new List<ValidRuler>();
        public List<ValidRuler> Rulers
        {
            get
            {
                return _rulers;
            }
            set
            {
                _rulers = value;
            }
        }
    }
}
