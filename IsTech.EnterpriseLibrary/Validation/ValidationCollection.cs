using System;
using System.Collections.Generic;
using System.Text;

namespace IsTech.EnterpriseLibrary.Validation
{
    public class ValidationCollection
    {
        private List<ValidInfo> _validInfos = new List<ValidInfo>();
        public ValidInfo this[int i]
        {
            get
            {
                return _validInfos[i];
            }
            set
            {
                _validInfos[i] = value;
            }
        }

        private Dictionary<string, ValidInfo> _validInfosForField = new Dictionary<string, ValidInfo>();
        public ValidInfo this[string fieldName]
        {
            get
            {
                return _validInfosForField[fieldName];
            }
            set
            {
                _validInfosForField[fieldName] = value;
            }
        }

        public int Count
        {
            get
            {
                return this._validInfos.Count;
            }
        }

        public void Add(ValidInfo validInfo)
        {
            _validInfos.Add(validInfo);
            if (validInfo.FieldName != string.Empty)
            {
                _validInfosForField.Add(validInfo.FieldName, validInfo);
            }
        }

        public void Remove(int index)
        {
            if (index > _validInfos.Count - 1 || index < 0)
            {
                throw new Exception("Index not valid!");
            }
            else
            {
                _validInfos.RemoveAt(index);
            }
        }

        public System.Collections.IEnumerable GetEnumerator()
        {
            for (int i = 0; i < _validInfos.Count; i++)
            {
                yield return _validInfos[i];
            }
        }
    }
}
