namespace Mmu.Khb.Domain.Infrastructure.ModelAbstractions
{
    // http://enterprisecraftsmanship.com/2014/11/08/domain-object-base-class/
    public abstract class Entity
    {
        public virtual string Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(compareTo, null))
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            return !IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id;
        }

        public override int GetHashCode()
        {
            return (GetType() + Id).GetHashCode();
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        private bool IsTransient()
        {
            return string.IsNullOrEmpty(Id);
        }
    }
}