namespace MyLibrary.Wpf.Messaging.Token;

public class MessagingToken : IEquatable<MessagingToken>
{
    public MessagingToken()
    {
    }

    public override bool Equals(object? other) => Equals(other as MessagingToken);

    public bool Equals(MessagingToken? other)
    {
        return other is not null && ReferenceEquals(this, other) && GetType() == other.GetType();
    }

    public override int GetHashCode() => base.GetHashCode();

    public static bool operator ==(MessagingToken me, MessagingToken other)
    {
        if (me is null)
        {
            return other is null;
        }

        return me.Equals(other);
    }

    public static bool operator !=(MessagingToken me, MessagingToken other) => !(me == other);
}