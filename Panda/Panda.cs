namespace Panda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    public enum Gender
    {
        Male,
        Female
    }

    public class Panda : IPanda
    {
        private string name;

        private string email;

        private Gender gender;

        public Panda(string name, string email, Gender gender)
        {
            this.Name = name;
            this.Email = email;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                // TODO : add validation if requiered.
                if (String.IsNullOrEmpty(value))
                {
                   throw new ArgumentNullException("ERROR: Name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (this.IsValidEmail(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Invalid E-mail address.");
                }
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                // TODO : gender validation (null?)
                this.gender = value;
            }
        }

        public bool IsMale
        {
            get
            {
                return this.gender == Gender.Male;
            }
        }

        public bool IsFemale
        {
            get
            {
                return this.gender == Gender.Female;
            }
        }

        public List<Panda> Friends { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}", this.name);
        }

        public override int GetHashCode()
        {
            int result = 83 * this.name.GetHashCode();
            result = 43 * this.email.GetHashCode();
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            // TODO : check comparison
            if (this == obj)
            {
                return true;
            }

            if (this.Name == (obj as Panda).Name && this.Email == (obj as Panda).email && this.Gender == (obj as Panda).Gender)
            {
                return true;
            }

            return false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
