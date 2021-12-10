using System.Collections.Generic;
using System.Data;

namespace NganHangPhanTan.Util
{
    public class MyCache
    {
        private readonly string _KeyFieldName;
        Dictionary<object, object> valuesCache = new Dictionary<object, object>();

        public MyCache(string keyFieldName)
        {
            _KeyFieldName = keyFieldName;
        }

        private object GetKeyByRow(object row)
        {
            return (row as DataRowView)[_KeyFieldName];
        }


        public object GetValue(object row)
        {
            return GetValueByKey(GetKeyByRow(row));
        }

        private object GetValueByKey(object key)
        {
            object result = null;
            valuesCache.TryGetValue(key, out result);
            return result;
        }

        public void SetValue(object row, object value)
        {
            SetValueByKey(GetKeyByRow(row), value);
        }

        private void SetValueByKey(object key, object value)
        {
            valuesCache[key] = value;
        }

        public void RemoveKey(object key)
        {
            valuesCache.Remove(key);
        }

        public void Clear()
        {
            valuesCache.Clear();
        }
    }
}
