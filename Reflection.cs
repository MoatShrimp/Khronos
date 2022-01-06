using System.Reflection;
public static class Reflection
{
    public static void SetPrivateField(object obj, string fieldName, object value)
    {
        obj.GetType()
           .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
           .SetValue(obj, value);
    }

    public static T GetPrivateField<T> (object obj, string fieldName)
    {
        return (T)(obj.GetType()
                      .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                      .GetValue(obj));
    }
}
