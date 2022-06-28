using EGN.Exceptions;
using EGN.Interfaces;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace EGN.Models
{
    public class Egn : IValidator, IGenerator
    {
        private readonly int positionBorn = 2;
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

            egn.Append($"{birthDate.Day:d2}");

            Region currentCity = _regions.Where(x => x.Name == city).First();

            if (isMale)
            {
                if (positionBorn == 1)
                {
                    egn.Append($"{currentCity.StartValue:d3}");
                }
                else
                {
                    egn.Append($"{(currentCity.StartValue + ((positionBorn - 1) * 2)):d3}");
                }
            }
            else
            {
                if (positionBorn == 1)
                {
                    egn.Append($"{(currentCity.StartValue + 1):d3}");
                }
                else
                {
                    egn.Append($"{(currentCity.StartValue + ((positionBorn - 1) * 2) + 1):d3}");
                }
            }

            egn.Append(CalculateCheckSum(egn.ToString()));

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
            if (string.IsNullOrEmpty(egn) || string.IsNullOrWhiteSpace(egn))
            {
                return false;
            }

            if (egn.Length != 10)
            {
                return false;
            }

            if (!Regex.IsMatch(egn, "[0-9]{10}"))
            {
                return false;
            }

            var year = int.Parse(egn.Substring(0, 2));
            var month = int.Parse(egn.Substring(2, 2));
            var day = int.Parse(egn.Substring(4, 2));

            if (!ValidateBirthDate(year, month, day))
            {
                return false;
            }

            if (!ValidateCheckSum(egn))
            {
                return false;
            }

            return true;
        }

        private bool ValidateBirthDate(int year, int month, int day)
        {
            if (month <= 12)
            {
                if (!DateTime.TryParse($"19{year}-{month}-{day}", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dt))
                {
                    return false;
                }

                return true;
            }
            else if (month > 12 && month <= 32)
            {
                if (!DateTime.TryParse($"18{year}-{month - 20}-{day}", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dt))
                {
                    return false;
                }

                return true;
            }
            else if (month > 32 && month <= 52)
            {
                if (!DateTime.TryParse($"20{year}-{month - 40}-{day}", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dt))
                {
                    return false;
                }

                return true;
            }
            else
            {
                return true;
            }
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
        private string CalculateCheckSum(string currentEgn)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int currentDigit = int.Parse(currentEgn[i].ToString());
                sum += currentDigit * _weights[i];
            }

            int remainder = sum % 11;

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


        private bool ValidateCheckSum(string egn)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int currentDigit = int.Parse(egn[i].ToString());

                sum += currentDigit * _weights[i];
            }

            int remainder = sum % 11;

            if (remainder == 10)
            {
                remainder = 0;
            }

            int checkSum = int.Parse(egn[9].ToString());

            if (checkSum == remainder)
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
