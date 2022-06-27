using EGN.Exceptions;
using EGN.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace EGN.Models
{
    public class Egn : IValidator, IGenerator
    {
        private readonly int positionBorn = 1;
        private readonly DateTime minBirthDate = new DateTime(1800, 1, 1);
        private readonly DateTime maxBirthDate = new DateTime(2099, 12, 31);
        private readonly int[] _weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        private readonly IEnumerable<Region> _regions = new List<Region>()
        {
            new Region("Благоевград", 0, 43),
            new Region("Бургас", 44, 93),
            new Region("Варна", 94, 139),
            new Region("Велико Търново", 140, 169),
            new Region("Видин", 170, 183),
            new Region("Враца", 184, 217),
            new Region("Габрово", 218, 233),
            new Region("Кърджали", 234, 281),
            new Region("Кюстендил", 282, 301),
            new Region("Ловеч", 302, 319),
            new Region("Монтана", 320, 341),
            new Region("Пазарджик", 342, 377),
            new Region("Перник", 378, 395),
            new Region("Плевен", 396, 435),
            new Region("Пловдив", 436, 501),
            new Region("Разград", 502, 527),
            new Region("Русе", 528, 555),
            new Region("Силистра", 556, 575),
            new Region("Сливен", 576, 601),
            new Region("Смолян", 602, 623),
            new Region("София - град", 624, 721),
            new Region("София - окръг", 722, 751),
            new Region("Стара Загора", 752, 789),
            new Region("Добрич", 790, 821),
            new Region("Търговище", 822, 843),
            new Region("Хасково", 844, 871),
            new Region("Шумен", 872, 903),
            new Region("Ямбол", 904, 925),
            new Region("Друг", 926, 999)
        };

        public string Generate(DateTime birthDate, string city, bool isMale)
        {
            if (birthDate < minBirthDate || birthDate > maxBirthDate)
            {
                throw new InvalidYearException();
            }

            if (_regions.Where(x => x.Name == city).FirstOrDefault() == null)
            {
                throw new InvalidCityException(city);
            }

            StringBuilder egn = new StringBuilder();

            egn.Append(birthDate.Year.ToString().Substring(2, 2));

            egn.Append(CalculateMonthDigits(birthDate));

            if (birthDate.Day < 10)
            {
                egn.Append($"0{birthDate.Day}");
            }
            else
            {
                egn.Append(birthDate.Day);
            }

            Region currentCity = _regions.Where(x => x.Name == city).First();

            if (isMale)
            {
                if (positionBorn == 1)
                {
                    egn.Append(currentCity.StartValue);
                }
                else
                {
                    egn.Append(currentCity.StartValue + ((positionBorn - 1) * 2));
                }
            }

            egn.Append(CalculateLastDigit(egn.ToString()));

            return egn.ToString();
        }

        public string Generate(int year, int month, int day, string city, bool isMale)
        {
            CheckBirthDate(year, month, day);

            DateTime birthDate = new DateTime(year, month, day);

            return Generate(birthDate, city, isMale);
        }

        public bool Validate(string egn)
        {
            if (egn == null || egn.Length != 10)
            {
                return false;
            }

            if (!Regex.IsMatch(egn, "[0-9]{10}"))
            {
                return false;
            }

            //if (!CheckLastDigit(egn))
            //{
            //    return false;
            //}

            return true;
        }

        private string CalculateMonthDigits(DateTime birthDate)
        {
            StringBuilder egnMonthDigits = new StringBuilder();

            if (birthDate.Year < 1900)
            {
                egnMonthDigits.Append(birthDate.Month + 20);
            }
            else if (birthDate.Year > 1999)
            {
                egnMonthDigits.Append(birthDate.Month + 40);
            }
            else
            {
                if (birthDate.Month < 10)
                {
                    egnMonthDigits.Append($"0{birthDate.Month}");
                }
                else
                {
                    egnMonthDigits.Append(birthDate.Month);
                }
            }

            return egnMonthDigits.ToString().Trim();
        }
        private string CalculateLastDigit(string currentEgn)
        {
            int egnSum = 0;

            for (int i = 0; i < 9; i++)
            {
                egnSum += currentEgn[i] * _weights[i];
            }

            int remainder = egnSum % 11;

            if (remainder == 10)
            {
                remainder = 0;
            }

            return remainder.ToString();
        }

        private static void CheckBirthDate(int year, int month, int day)
        {
            if (year < 1800 || year > 2099)
            {
                throw new InvalidYearException();
            }

            if (month < 1 || month > 12)
            {
                throw new InvalidMonthException();
            }

            if (day < 1 || day > 31)
            {
                throw new InvalidDayException();
            }
        }


        private bool CheckLastDigit(string egn)
        {
            int sum = 0;

            for (int i = 0; i < egn.Length - 2; i++)
            {
                int currentDigit = int.Parse(egn[i].ToString());

                sum += currentDigit * _weights[i];
            }

            int remainder = sum % 11;

            if (remainder == 10)
            {
                remainder = 0;
            }

            if (egn[9] == remainder)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
