using System.Reflection;

namespace MyLibrary.Extensions;

public static class TypeExtension
{
    ///<summary>
    ///<paramref name="source"/> のプロパティで <typeparamref name="CustomAttribute"/> が付いているプロパティを全て取得します。
    ///</summary>
    ///<typeparam name="CustomAttribute"> 取得するプロパティに付いている属性の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> のプロパティで <typeparamref name="CustomAttribute"/> が付いているプロパティ。
    ///</returns>
    public static IEnumerable<PropertyInfo> GetPropertiesOfAttribute<CustomAttribute>(this Type source) where CustomAttribute : Attribute
    {
        return source.GetProperties().Where(propertyInfo => propertyInfo.GetCustomAttribute<CustomAttribute>() is not null);
    }
}
