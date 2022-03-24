using System.Reflection;

namespace MyLibrary.Extensions;

public static class PropertyInfoExtension
{
    ///<summary>
    ///<paramref name="source"/> の <see cref="Attribute"/> から <typeparamref name="CustomAttribute"/> を返し､
    ///<typeparamref name="CustomAttribute"/> の要素が 1 つだけでない場合は､例外をスローします。
    ///</summary>
    ///<typeparam name="CustomAttribute"> 取得する <see cref="Attribute"/>。</typeparam>
    ///<returns>
    ///1 つの <typeparamref name="CustomAttribute"/>
    ///</returns>
    public static CustomAttribute GetCustomAttribute<CustomAttribute>(this PropertyInfo source) where CustomAttribute : Attribute
    {
        return source.GetCustomAttributes(typeof(CustomAttribute), false).OfType<CustomAttribute>().Single();
    }

    ///<summary>
    ///<paramref name="source"/> の <see cref="Attribute"/> から <typeparamref name="CustomAttribute"/> を返します｡
    ///<typeparamref name="CustomAttribute"/> が見つからなかった場合､ 既定値を返します｡
    ///<typeparamref name="CustomAttribute"/> の要素が複数ある場合､ このメソッドは例外をスローします。
    ///</summary>
    ///<typeparam name="CustomAttribute"> 取得する <see cref="Attribute"/>。</typeparam>
    ///<returns>
    ///1 つの <typeparamref name="CustomAttribute"/>
    ///<typeparamref name="CustomAttribute"/> が見つからなかった場合は <see langword="default"/> (<typeparamref name="CustomAttribute"/>)
    ///</returns>
    public static CustomAttribute? GetCustomAttributeOrDefault<CustomAttribute>(this PropertyInfo source) where CustomAttribute : Attribute
    {
        return source.GetCustomAttributes(typeof(CustomAttribute), false).OfType<CustomAttribute>().SingleOrDefault();
    }
}
