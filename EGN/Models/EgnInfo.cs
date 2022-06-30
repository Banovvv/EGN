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

        public EgnInfo(string egn, int year, int month, int day, string region, string gender, int birthPosition)
        {
            Egn = egn;
            BirthDate = new DateOnly(year, month, day);
            Region = region;
            Gender = gender;
            BirthPosition = birthPosition;
        }

        public string Egn
        {
            get => egn;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ЕГН не може да е null");
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
                    throw new ArgumentException("Градът на раждане не може да е null");
                }

                region = value;
            }
        }
        public string Gender
        {
            get => gender;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Полът не може да е null");
                }

                gender = value;
            }
        }

        public int BirthPosition { get; private set; }

        public override string ToString() => $"{Egn} е ЕГН на {Gender}, {(Gender == "мъж" ? "роден" : "родена")} на {BirthDate.ToString("dd-MM-yyyy")} в регион {Region}. Преди {(Gender == "мъж" ? "него" : "нея")} в този ден и регион са се родили {BirthPosition} {(Gender == "мъж" ? "момчета" : "момичета")}";
    }
}
