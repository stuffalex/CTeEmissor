namespace CTeEmissor.Base
{
    public abstract class EntidadeBase<T> where T : EntidadeBase<T>
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            if (obj is not T other)
                return false;

            return GetType() == other.GetType() && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }

        public static bool operator ==(EntidadeBase<T>? a, EntidadeBase<T>? b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntidadeBase<T>? a, EntidadeBase<T>? b)
        {
            return !(a == b);
        }
    }
}
