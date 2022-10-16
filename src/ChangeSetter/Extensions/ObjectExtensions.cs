using System.Reflection; 

namespace ChangeSetter.Extensions
{
    public static class ObjectExtensions
    {
        public static BindingFlags FieldBindings = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
  
        public static bool HasProperty(this object item, string propertyName) => item.GetType().GetProperty(propertyName, FieldBindings) != null;        
        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName, FieldBindings).GetValue(src, null);
        }
        public static void SetPropertyValue(this object obj, string propName, object value)
        {
            obj.GetType().GetProperty(propName, FieldBindings).SetValue(obj, value, null);
        }

        public static bool HasField(this object item, string fieldName) => item.GetType().GetField(fieldName, FieldBindings) != null;
        public static object GetFieldValue(this object src, string propName)
        {
            return src.GetType().GetField(propName, FieldBindings).GetValue(src);
        }
        public static void SetFieldValue(this object obj, string propName, object value)
        {
            obj.GetType().GetField(propName, FieldBindings).SetValue(obj, value);
        }
    }
}
