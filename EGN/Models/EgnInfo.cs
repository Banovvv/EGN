namespace EGN.Models
{
    public class EgnInfo
    {
        private string egn;
        private string region;
        private string gender;
        private string birthDate;

        public EgnInfo(string egn, string region, string gender, int birthPosition)
        {
            Egn = egn;
            Region = region;
            BirthDate = egn;
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
        public string BirthDate
        {
            get => birthDate;
            private set
            {
                var year = int.Parse($"19{value.Substring(0, 2)}");
                var month = int.Parse(value.Substring(2, 2));

                if (month >= 21 && month <= 32)
                {
                    month -= 20;
                    year -= 100;
                }
                else if (month >= 41 && month <= 52)
                {
                    month -= 40;
                    year += 100;
                }
                var day = int.Parse(value.Substring(4, 2));

                birthDate = new DateOnly(year, month, day).ToString("dddd, dd MMMM yyyy");
            }
        }
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

        public override string ToString() => $"{Egn} е ЕГН на {Gender}, {(Gender == "мъж" ? "роден" : "родена")} в {BirthDate}г. в регион {Region}. Преди {(Gender == "мъж" ? "него" : "нея")} в този ден и регион са се родили {BirthPosition} {(Gender == "мъж" ? "момче/та" : "момиче/та")}";
    }
}
