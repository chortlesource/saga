using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Saga.Util
{
    public static class ReflectionUtil
    {
        #region Fields

        public static FieldInfo GetFieldInfo(object targetObject, string fieldName) => GetFieldInfo(targetObject.GetType(), fieldName);

        public static FieldInfo GetFieldInfo(Type type, string fieldName)
        {
            while (type != null)
            {
                var fieldInfo = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (fieldInfo != null)
                    return fieldInfo;

                type = type.BaseType;
            }

            return null;
        }

        public static IEnumerable<FieldInfo> GetFields(Type type) => type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        public static object GetFieldValue(object targetObject, string fieldName) => GetFieldInfo(targetObject, fieldName).GetValue(targetObject);

        #endregion
    }
}
