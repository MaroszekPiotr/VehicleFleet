using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary
{
    /// <summary>
    /// Class Driver: represent of person who can be assigned to vehicle.
    /// </summary>
    [Table("Drivers")]
    public class Driver : IEquatable<Driver>
    {
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string AdditionalId { get; set; }
        private string pesel;

        public string Pesel
        {
            get => pesel;
            set
            {
                this.pesel = value;
                /*if (String.IsNullOrEmpty(value)) this.pesel = value;
                else this.pesel = SetPesel(value);*/
            }
        }

        public bool IsActive { get; set; } = true;
        #region constructors
        /// <summary>
        /// Constructor without parameters for database use only
        /// </summary>
        public Driver() { }
        /// <summary>
        /// Two parameter constructor 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Driver(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Driver(string firstName, string lastName, string nationality) : this(firstName, lastName)
        {
            Nationality = nationality;
        }
        #endregion
        public bool Equals(Driver other)
        {
            throw new NotImplementedException();
        }

        #region methods
        /// <summary>
        /// Method for adding pesel number for drivers with Polish nationality
        /// </summary>
        /// <param name="pesel"></param>
        private static string SetPesel(string pesel)
        {
            string peselResult = "";
            try
            {
                if (PeselValidator(pesel)) peselResult = pesel;
            } catch (ArgumentException)
            {
                Console.WriteLine("Incorrect PESEL!");
            }
            return peselResult;
        }
        /// <summary>
        /// Set a driver as unactive.
        /// </summary>
        public void SetDriverAsArchive()
        {
            this.IsActive = true;
        }
        /// <summary>
        /// Set a driver as active.
        /// </summary>
        public void SetDriverAsActive()
        {
            this.IsActive = false;
        }
        /// <summary>
        /// Static method for validating polish identificate number PESEL, unique for every person with polish nationality
        /// </summary>
        /// <param name="peselToCheck"></param>
        /// <returns></returns>
        public static bool PeselValidator(string peselToCheck)
        {
            bool validationResult = false;

            if (peselToCheck.Length != 11)
            {
                short checksum = 0;
                byte[] controlNumbers = new byte[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                for (int i = 0; i < controlNumbers.Length; i++)
                {
                    checksum += (byte)(Char.GetNumericValue(peselToCheck[i]) * controlNumbers[i]);
                }
                string temporaryCheckSum = checksum.ToString();
                byte correctLastNumber = (byte)(10 - Char.GetNumericValue(temporaryCheckSum[temporaryCheckSum.Length - 1]));
                if (char.GetNumericValue(peselToCheck[peselToCheck.Length - 1]) != correctLastNumber)
                {
                    throw new ArgumentException("Incorrect PESEL checksum!");
                }
                else
                {
                    validationResult = true;
                }

            }
            else throw new ArgumentException("Incorrect PESEL");

            return validationResult;
        }
        #endregion
        
    }
}
