#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;



internal sealed partial class MatchingAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    private sealed class AccountsAttribute : Attribute
    {
        private Accounts m_accounts;

        public AccountsAttribute(Accounts accounts)
        {
            m_accounts = accounts;
        }

        public override Boolean Match(Object obj)
        {
            // If the base class implements Match and the base class
            // is not Attribute, then uncomment the line below.
            // if (!base.Match(obj)) return false;

            // Since ‘this’ isn’t null, if obj is null,
            // then the objects can’t match
            // NOTE: This line may be deleted if you trust
            // the base type implemented Match correctly.
            if (obj == null) return false;

            // If the objects are of different types, they can’t match
            // NOTE: This line may be deleted if you trust
            // the base type implemented Match correctly.
            if (this.GetType() != obj.GetType()) return false;

            // Cast obj to our type to access fields. NOTE: This cast
            // can't fail since we know objects are of the same type
            AccountsAttribute other = (AccountsAttribute)obj;

            // Compare the fields as you see fit
            // This example checks if 'this' accounts is a subset
            // of other's accounts
            if ((other.m_accounts & m_accounts) != m_accounts)
                return false;

            return true;   // Objects match
        }

        public override Boolean Equals(Object obj)
        {
            // If the base class implements Equals and the base class
            // is not Object, then uncomment the line below.
            // if (!base.Equals(obj)) return false;

            // Since ‘this’ isn’t null, if obj is null,
            // then the objects can’t be equal
            // NOTE: This line may be deleted if you trust
            // the base type implemented Equals correctly.
            if (obj == null) return false;

            // If the objects are of different types, they can’t be equal
            // NOTE: This line may be deleted if you trust
            // the base type implemented Equals correctly.
            if (this.GetType() != obj.GetType()) return false;

            // Cast obj to our type to access fields. NOTE: This cast
            // can't fail since we know objects are of the same type
            AccountsAttribute other = (AccountsAttribute)obj;

            // Compare the fields to see if they have the same value
            // This example checks if 'this' accounts is the same
            // as other's accounts
            if (other.m_accounts != m_accounts)
                return false;

            return true;   // Objects are equal
        }

        // Override GetHashCode since we override Equals
        public override Int32 GetHashCode()
        {
            return (Int32)m_accounts;
        }
    }
}