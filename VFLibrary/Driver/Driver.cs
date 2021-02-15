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
        /// <summary>
        /// Identifier for sql use only.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        /// <summary>
        /// First name of driver.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of driver.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Nationality of driver. In some cases it's necessary information because of the law statement.
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// Important information for drivers who hasn't pesel numbers.
        /// </summary>
        public string AdditionalId { get; set; }
        /// <summary>
        /// Identifier for Polish Drivers.
        /// </summary>
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
        /// <summary>
        /// Set driver as active or unactive. Default velue in case of create a new driver is active. You can change it every time.
        /// </summary>
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
        #region toString
        public override string ToString() => $"Driver: {FirstName} {LastName},\nNationality: {Nationality},\nPESEL: {Pesel}\nAdditional ID: {AdditionalId}\nActive driver: {IsActive};";
        #endregion
        #region equals
        public bool Equals(Driver other)
        {
            if (other == null) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return (this.FirstName == other.FirstName && this.LastName == other.LastName && this.Nationality == other.Nationality && this.AdditionalId == other.AdditionalId && this.pesel == other.pesel);
        }

        public override bool Equals(object obj)
        {
            if (obj is Driver) return Equals((Driver)obj);
            else return false;
        }
        public static bool Equals (Driver d1, Driver d2)
        {
            if ((d1 is null) && (d2 is null)) return true;
            if (d1 is null) return false;
            return d1.Equals(d2);
        }
        public override int GetHashCode() => (FirstName, LastName, Nationality, AdditionalId, Pesel).GetHashCode();
        #endregion
        #region operators
        public static bool operator ==(Driver d1, Driver d2) => Equals(d1, d2);
        public static bool operator !=(Driver d1, Driver d2) => !(Equals(d1, d2));
        #endregion
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
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect PESEL!");
            }
            return peselResult;
        }
        /// <summary>
        /// Static method for validating Polish identificate number PESEL, unique for every person with Polish nationality
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
        /// <summary>
        /// Parser of string data
        /// </summary>
        /// <param name="firstNameLastNameSeparatedByComma">String attribute of frist name and last name separated by comma or space sign</param>
        /// <returns>Return Driver class</returns>
        public static Driver Parse(string firstNameLastNameSeparatedByComma)
        {
            firstNameLastNameSeparatedByComma = firstNameLastNameSeparatedByComma.Replace(" ", ";").Replace(",", ";");
            string[] inputData = firstNameLastNameSeparatedByComma.Split(";");
            if (inputData.Length < 2) return null;
            return new Driver(inputData[0],inputData[1]);
        }
        #endregion

    }
}
