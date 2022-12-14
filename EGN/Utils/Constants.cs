using EGN.Models;

namespace EGN.Utils
{
    public static class Constants
    {
        public static string EmptyEgnExceptionMessage = "ЕГН не може да е празно!";
        public static string EmptyCityExceptionMessage = "Градът на раждане не може да е празен!";
        public static string EmptyGenderExceptionMessage = "Полът не може да е празен!";

        public static string InvalidEgn = "Невалидно ЕГН!";
        public static string InvalidBirthPosition = "Невалидна позиция на раждане!";

        public static string Male = "мъж";
        public static string Female = "жена";


        public static DateOnly MinBirthDate = new DateOnly(1800, 1, 1);
        public static DateOnly MaxBirthDate = new DateOnly(2099, 12, 31);

        public static int[] Weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public static IEnumerable<Region> Regions = new List<Region>()
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
    }
}
