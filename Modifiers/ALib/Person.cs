using System;

namespace ALib
{
    public class Person
    {
        private DateTimeOffset _dayOfBirthday;

        internal bool isMan;

        protected int Age
        {
            get
            {
                return DateTimeOffset.Now.Year - _dayOfBirthday.Year;
            }
        }

        protected void ProtectedMethod() { }

        private protected void PrivateProtectedMethod() { }

        public DateTimeOffset GetBirthday()
        {
            return _dayOfBirthday;
        }
    }

}
