namespace Panda
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// List of gender types.
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// Panda class.
    /// </summary>
    public class Panda : IPanda
    {
        /// <summary>
        /// Name field.
        /// </summary>
        private string name;

        /// <summary>
        /// Email field.
        /// </summary>
        private string email;

        /// <summary>
        /// Gender field.
        /// </summary>
        private Gender gender;

        // TODO : list of pandas needed?
        /// <summary>
        /// Gets the friends of a panda property.
        /// </summary>
        //public List<Panda> Friends { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Panda"/> class.
        /// </summary>
        /// <param name="name">Sets the Name property.</param>
        /// <param name="email">Sets the Email property.</param>
        /// <param name="gender">Sets the gender property.</param>
        public Panda(string name, string email, Gender gender)
        {
            this.Name = name;
            this.Email = email;
            this.Gender = gender;
        }

        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the Email property.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the gender property.
        /// </summary>
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

        /// <summary>
        /// Gets the isMale property.
        /// </summary>
        public bool IsMale
        {
            get
            {
                return this.gender == Gender.Male;
            }
        }

        /// <summary>
        /// Gets the IsFemale property.
        /// </summary>
        public bool IsFemale
        {
            get
            {
                return this.gender == Gender.Female;
            }
        }

        /// <summary>
        /// Overrides ToString() method for Panda class.
        /// </summary>
        /// <returns>Panda class ot string.</returns>
        public override string ToString()
        {
            return string.Format("{0}", this.name);
        }

        /// <summary>
        /// Gets hashcode for a panda.
        /// </summary>
        /// <returns>Hash code of a panda.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 83 * this.name.GetHashCode();
                result = result * 43 * this.email.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// Overrides the Equals() method for a panda.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>True if <![CDATA[obj]]> Equals the panda object.</returns>
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

        /// <summary>
        /// Checks if email is valid.
        /// </summary>
        /// <param name="emailToCheck">Email to check.</param>
        /// <returns>True if email is valid.</returns>
        private bool IsValidEmail(string emailToCheck)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailToCheck);
                return addr.Address == emailToCheck;
            }
            catch
            {
                return false;
            }
        }
    }
}
