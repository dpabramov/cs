﻿using System;
using System.Collections.Generic;

namespace _083_DictionaryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>
            {
                { 1, "ОАЭ" },
                { 2, "Нигерия" },
                { 3, "Эфиопия" },
                { 4, "Гана" },
                { 5, "Алжир" },
                { 6, "Иордания" },
                { 7, "Нидерланды" },
                { 8, "Андорра" },
                { 9, "Турция" },
                { 10, "Мадагаскар" },
                { 11, "Самоа" },
                { 12, "Эритрея" },
                { 13, "Парагвай" },
                { 14, "Греция" },
                { 15, "Туркмения" },
                { 16, "Ирак" },
                { 17, "Азербайджан" },
                { 18, "Мали" },
                { 19, "Центральноафриканская Республика" },
                { 20, "Таиланд" },
                { 21, "Бруней" },
                { 22, "Гамбия" },
                { 23, "Сент-Кристофер и Невис" },
                { 24, "Ливан" },
                { 25, "Сербия" },
                { 26, "Белиз" },
                { 27, "Германия" },
                { 28, "Швейцария" },
                { 29, "Гвинея-Бисау" },
                { 30, "Киргизия" },
                { 31, "Колумбия" },
                { 32, "Конго" },
                { 33, "Бразилия" },
                { 34, "Словакия" },
                { 35, "Барбадос" },
                { 36, "Бельгия" },
                { 37, "Венгрия" },
                { 38, "Бурунди" },
                { 39, "Румыния" },
                { 40, "Аргентина" },
                { 41, "Лихтенштейн" },
                { 42, "Мальта" },
                { 43, "Польша" },
                { 44, "Ватикан" },
                { 45, "США" },
                { 46, "Новая Зеландия" },
                { 47, "Австрия" },
                { 48, "Сейшельские острова" },
                { 49, "Вануату" },
                { 50, "Литва" },
                { 51, "Намибия" },
                { 52, "Лаос" },
                { 53, "Ботсвана" },
                { 54, "Куба" },
                { 55, "Гватемала" },
                { 56, "Сенегал" },
                { 57, "Бангладеш" },
                { 58, "Сирия" },
                { 59, "Индия" },
                { 60, "Индонезия" },
                { 61, "Джибути" },
                { 62, "Гайана" },
                { 63, "Южный Судан" },
                { 64, "Восточный Тимор" },
                { 65, "Танзания" },
                { 66, "Катар" },
                { 67, "Ирландия" },
                { 68, "Таджикистан" },
                { 69, "Армения" },
                { 70, "Хорватия" },
                { 71, "Израиль" },
                { 72, "Пакистан" },
                { 73, "Афганистан" },
                { 74, "Египет" },
                { 75, "Уганда" },
                { 76, "Австралия" },
                { 77, "Венесуэла" },
                { 78, "Сент-Люсия" },
                { 79, "Непал" },
                { 80, "Руанда" },
                { 81, "Украина" },
                { 82, "Сент-Винсент и Гренадины" },
                { 83, "Ямайка" },
                { 84, "Конго (Дем. Република)" },
                { 85, "Эквадор" },
                { 86, "Молдавия" },
                { 87, "Шри-Ланка" },
                { 88, "Гвинея" },
                { 89, "Дания" },
                { 90, "Палау" },
                { 91, "Малайзия" },
                { 92, "Боливия" },
                { 93, "Габон" },
                { 94, "Малави" },
                { 95, "Перу" },
                { 96, "Португалия" },
                { 97, "Того" },
                { 98, "Великобритания" },
                { 99, "Ангола" },
                { 100, "Замбия" },
                { 101, "Словения" },
                { 102, "Люксембург" },
                { 103, "Маршалловы острова" },
                { 104, "Испания" },
                { 105, "Экваториальная Гвинея" },
                { 106, "Мальдивы" },
                { 107, "Никарагуа" },
                { 108, "Бахрейн" },
                { 109, "Филиппины" },
                { 110, "Мозамбик" },
                { 111, "Лесото" },
                { 112, "Оман" },
                { 113, "Эсватини" },
                { 114, "Мексика" },
                { 115, "Белоруссия" },
                { 116, "Сомали" },
                { 117, "Монако" },
                { 118, "Либерия" },
                { 119, "Уругвай" },
                { 120, "Коморские острова" },
                { 121, "Российская Федерация" },
                { 122, "Кения" },
                { 123, "Багамские острова" },
                { 124, "Чад" },
                { 125, "Мьянма" },
                { 126, "Нигер" },
                { 127, "Кипр" },
                { 128, "Мавритания" },
                { 129, "Тонга" },
                { 130, "Казахстан" },
                { 131, "Норвегия" },
                { 132, "Канада" },
                { 133, "Суринам" },
                { 134, "Микронезия" },
                { 135, "Панама" },
                { 136, "Франция" },
                { 137, "Китай" },
                { 138, "Камбоджа" },
                { 139, "Черногория" },
                { 140, "Маврикий" },
                { 141, "Папуа - Новая Гвинея" },
                { 142, "Гаити" },
                { 143, "Тринидад и Тобаго" },
                { 144, "Бенин" },
                { 145, "Чехия" },
                { 146, "Кабо-Верде" },
                { 147, "ЮАР" },
                { 148, "Корея Северная" },
                { 149, "Марокко" },
                { 150, "Палестина" },
                { 151, "Исландия" },
                { 152, "Латвия" },
                { 153, "Италия" },
                { 154, "Доминика" },
                { 155, "Сан-Марино" },
                { 156, "Сальвадор" },
                { 157, "Сан-Томе и Принсипи" },
                { 158, "Коста-Рика" },
                { 159, "Йемен" },
                { 160, "Доминиканская Республика" },
                { 161, "Чили" },
                { 162, "Босния и Герцеговина" },
                { 163, "Антигуа и Барбуда" },
                { 164, "Гренада" },
                { 165, "Корея Южная" },
                { 166, "Сингапур" },
                { 167, "Северная Македония" },
                { 168, "Болгария" },
                { 169, "Швеция" },
                { 170, "Фиджи" },
                { 171, "Тайвань" },
                { 172, "Эстония" },
                { 173, "Кирибати" },
                { 174, "Узбекистан" },
                { 175, "Грузия" },
                { 176, "Иран" },
                { 177, "Гондурас" },
                { 178, "Албания" },
                { 179, "Япония" },
                { 180, "Ливия" },
                { 181, "Тунис" },
                { 182, "Бутан" },
                { 183, "Буркина-Фасо" },
                { 184, "Монголия" },
                { 185, "Сьерра-Леоне" },
                { 186, "Тувалу" },
                { 187, "Судан" },
                { 188, "Вьетнам" },
                { 189, "Зимбабве" },
                { 190, "Финляндия" },
                { 191, "Соломоновы острова" },
                { 192, "Кувейт" },
                { 193, "Саудовская Аравия" },
                { 194, "Кот-д'Ивуар" },
                { 195, "Науру" },
                { 196, "Камерун" }
            };
            Dictionary<int, string> capitals = new Dictionary<int, string>
            {
                { 1, "Абу-Даби" },
                { 2, "Абуджа" },
                { 3, "Аддис-Абеба" },
                { 4, "Аккра" },
                { 5, "Алжир" },
                { 6, "Амман" },
                { 7, "Амстердам" },
                { 8, "Андорра-ла-Велья" },
                { 9, "Анкаpа" },
                { 10, "Антананариву" },
                { 11, "Апиа" },
                { 12, "Асмэра" },
                { 13, "Асунсьон" },
                { 14, "Афины" },
                { 15, "Ашхабад" },
                { 16, "Багдад" },
                { 17, "Баку" },
                { 18, "Бамако" },
                { 19, "Банги" },
                { 20, "Бангкок" },
                { 21, "Бандар-Сери-Бегаван" },
                { 22, "Банжул" },
                { 23, "Бастер" },
                { 24, "Бейрут" },
                { 25, "Белград" },
                { 26, "Бельмопан" },
                { 27, "Берлин" },
                { 28, "Берн" },
                { 29, "Бисау" },
                { 30, "Бишкек" },
                { 31, "Богота" },
                { 32, "Браззавиль" },
                { 33, "Бразилиа" },
                { 34, "Братислава" },
                { 35, "Бриджтаун" },
                { 36, "Брюссель" },
                { 37, "Будапешт" },
                { 38, "Бужумбура" },
                { 39, "Бухарест" },
                { 40, "Буэнос-Айрес" },
                { 41, "Вадуц" },
                { 42, "Валетта" },
                { 43, "Варшава" },
                { 44, "Ватикан" },
                { 45, "Вашингтон" },
                { 46, "Веллингтон" },
                { 47, "Вена" },
                { 48, "Виктория" },
                { 49, "Вила" },
                { 50, "Вильнюс" },
                { 51, "Виндхук" },
                { 52, "Вьентьян" },
                { 53, "Габороне" },
                { 54, "Гавана" },
                { 55, "Гватемала" },
                { 56, "Дакар" },
                { 57, "Дакка" },
                { 58, "Дамаск" },
                { 59, "Дели" },
                { 60, "Джакарта" },
                { 61, "Джибути" },
                { 62, "Джорджтаун" },
                { 63, "Джуба" },
                { 64, "Дили" },
                { 65, "Додома" },
                { 66, "Доха" },
                { 67, "Дублин" },
                { 68, "Душанбе" },
                { 69, "Ереван" },
                { 70, "Загреб" },
                { 71, "Иерусалим" },
                { 72, "Исламабад" },
                { 73, "Кабул" },
                { 74, "Каир" },
                { 75, "Кампала" },
                { 76, "Канберра" },
                { 77, "Каракас" },
                { 78, "Кастри" },
                { 79, "Катманду" },
                { 80, "Кигали" },
                { 81, "Киев" },
                { 82, "Кингстаун" },
                { 83, "Кингстон" },
                { 84, "Киншаса" },
                { 85, "Кито" },
                { 86, "Кишинев" },
                { 87, "Коломбо" },
                { 88, "Конакри" },
                { 89, "Копенгаген" },
                { 90, "Корор" },
                { 91, "Куала-Лумпур" },
                { 92, "Ла-Пас" },
                { 93, "Либревиль" },
                { 94, "Лилонгве" },
                { 95, "Лима" },
                { 96, "Лиссабон" },
                { 97, "Ломе" },
                { 98, "Лондон" },
                { 99, "Луанда" },
                { 100, "Лусака" },
                { 101, "Любляна" },
                { 102, "Люксембург" },
                { 103, "Маджуро" },
                { 104, "Мадрид" },
                { 105, "Малабо" },
                { 106, "Мале" },
                { 107, "Манагуа" },
                { 108, "Манама" },
                { 109, "Манила" },
                { 110, "Мапуту" },
                { 111, "Масеру" },
                { 112, "Маскат" },
                { 113, "Мбабане" },
                { 114, "Мехико" },
                { 115, "Минск" },
                { 116, "Могадишо" },
                { 117, "Монако" },
                { 118, "Монровия" },
                { 119, "Монтевидео" },
                { 120, "Морони" },
                { 121, "Москва" },
                { 122, "Найроби" },
                { 123, "Нассау" },
                { 124, "Нджамена" },
                { 125, "Нейпьидо" },
                { 126, "Ниамей" },
                { 127, "Никосия" },
                { 128, "Нуакшот" },
                { 129, "Нукуалофа" },
                { 130, "Нур-Султан (Астана)" },
                { 131, "Осло" },
                { 132, "Оттава" },
                { 133, "Паpамаpибо" },
                { 134, "Паликир" },
                { 135, "Панама" },
                { 136, "Париж" },
                { 137, "Пекин" },
                { 138, "Пномпень" },
                { 139, "Подгорица" },
                { 140, "Порт-Луи" },
                { 141, "Порт-Морсби" },
                { 142, "Порт-о-Пренс" },
                { 143, "Порт-оф-Спейн" },
                { 144, "Порто-Ново" },
                { 145, "Прага" },
                { 146, "Прая" },
                { 147, "Претория" },
                { 148, "Пхеньян" },
                { 149, "Рабат" },
                { 150, "Рамалла" },
                { 151, "Рейкьявик" },
                { 152, "Рига" },
                { 153, "Рим" },
                { 154, "Розо" },
                { 155, "Сан-Марино" },
                { 156, "Сан-Сальвадор" },
                { 157, "Сан-Томе" },
                { 158, "Сан-Хосе" },
                { 159, "Сана" },
                { 160, "Санто-Доминго" },
                { 161, "Сантьяго" },
                { 162, "Сараево" },
                { 163, "Сент-Джонс" },
                { 164, "Сент-Джорджес" },
                { 165, "Сеул" },
                { 166, "Сингапур" },
                { 167, "Скопье" },
                { 168, "София" },
                { 169, "Стокгольм" },
                { 170, "Сува" },
                { 171, "Тайпей" },
                { 172, "Таллинн" },
                { 173, "Тарава" },
                { 174, "Ташкент" },
                { 175, "Тбилиси" },
                { 176, "Тегеран" },
                { 177, "Тегусигальпа" },
                { 178, "Тирана" },
                { 179, "Токио" },
                { 180, "Триполи" },
                { 181, "Тунис" },
                { 182, "Тхимпху" },
                { 183, "Уагадугу" },
                { 184, "Улан-Батор" },
                { 185, "Фpитаун" },
                { 186, "Фунафути" },
                { 187, "Хаpтум" },
                { 188, "Ханой" },
                { 189, "Хараре" },
                { 190, "Хельсинки" },
                { 191, "Хониаpа" },
                { 192, "Эль-Кувейт" },
                { 193, "Эр-Рияд" },
                { 194, "Ямусукро" },
                { 195, "Ярен" },
                { 196, "Яунде" }
            };
            Dictionary<string, string> result = new Dictionary<string, string>();

            Random random = new Random();
            int key;
            int truthAnswer = 0;
            int totalQuestions = 10;

            for (int i = 0; i < totalQuestions; i++)
            {
                key = random.Next(countries.Count);
                Console.Write($"Какая столица в {countries[key]}?   ");
                string answer = Console.ReadLine();
                result.Add(countries[key], capitals[key]);

                if (capitals[key].Equals(answer, StringComparison.CurrentCultureIgnoreCase))
                    truthAnswer += 1;
            }

            Console.WriteLine($"Количество правильных ответов {truthAnswer} из {totalQuestions}.");

            foreach (var i in result)
                Console.WriteLine($"{i.Key}\t - {i.Value}");

            Console.ReadKey();
        }
    }
}
