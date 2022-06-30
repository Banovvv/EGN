using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGN.Models
{
    public class EgnInfo
    {
        private string egn;
        private string region;
        private string gender;

        public EgnInfo(string egn, int year, int month, int day, string region, string gender)
        {
            Egn = egn;
            BirthDate = new DateOnly(year, month, day);
            Region = region;
            Gender = gender;
        }

        public string Egn
        {
            get => egn;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                egn = value;
            }
        }
        public DateOnly BirthDate { get; private set; }
        public string Region
        {
            get => region;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                egn = value;
            }
        }
        public string Gender
        {
            get => gender;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                egn = value;
            }
        }

        private int BirthPosition => GetBirthPosition();

        private int GetBirthPosition()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{Egn} е ЕГН на {Gender}, {(Gender == "мъж" ? "роден" : "родена")} на 1 януари 1992 г. в регион {Region} като преди нея в този ден и регион са се родили {BirthPosition} {(Gender == "мъж" ? "момчета" : "момичета")}";
    }
}
