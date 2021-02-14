using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary
{
    [Table("Drivers")]
    public class Driver
    {
        [PrimaryKey,AutoIncrement]
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string AdditionalId { get; set; }
        public string Pesel { get; set; }
        public bool IsActive { get; set; } = true;
        public Driver()
        {
            //this.Name = name;
            //this.Surname = surname;
            //this.pesel = peselValidator(pesel);

            /*string peselValidator(string peselToCheck)
            {
                switch (nationalityCode.ToLower())
                {
                    case "pl":
                        if (peselToCheck.Length != 11) throw new ArgumentException("Incorrect PESEL or the driver is foreigner!");
                        short checksum = 0;
                        byte[] controlNumbers = new byte[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                        for (int i = 0; i < controlNumbers.Length; i++)
                        {
                            checksum += (byte)(Char.GetNumericValue(peselToCheck[i]) * controlNumbers[i]);
                        }
                        string temporaryCheckSum = checksum.ToString();
                        byte correctLastNumber = (byte)(10 - Char.GetNumericValue(temporaryCheckSum[temporaryCheckSum.Length - 1]));
                        if (char.GetNumericValue(peselToCheck[peselToCheck.Length - 1]) != correctLastNumber) throw new ArgumentException("Incorrect PESEL checksum!");
                        return peselToCheck;
                    default:
                        if (peselToCheck.Length != 0) throw new ArgumentException("foreigners do not have a PESEL number!");
                        return "";
                }
            }*/
        }
    }
}
