МІНІСТЕРСТВО ОСВІТИ І НАУКИ УКРАЇНИ

Національний аерокосмічний університет ім. М. Є. Жуковського
«Харківський авіаційний інститут»

факультет програмної інженерії та бізнесу

кафедра інженерії програмного забезпечення

# Лабораторна робота № 2

з дисципліни «	Об’єктно орієнтоване програмування		»
назва дисципліни
на тему: « ІНКАПСУЛЯЦІЯ, ВЛАСТИВОСТІ »



Виконав: студент 2 курсу групи № 	622п	
освітньої програми
121 інженерія програмного забезпечення	
                             (шифр і назва ОП)
		Петренко Є.О.                                   	
 (прізвище й ініціали студента)
Прийняв:	доц. Вдовітченко О.В.		 
(посада, науковий ступінь, прізвище й ініціали)
Кількість балів: 					









Харків – 2023

## ПОСТАНОВКА ЗАДАЧІ

### Завдання

На основі отриманого на лекції 2 теоретичного матеріалу скорегувати програму для лабораторної роботи № 1 наступним чином: 
1.	Всі поля (характеристики) класу повинні бути інкапсульовані за допомогою модифікатора доступу private.
2.	Для кожного private-поля, яке необхідне для зовнішньої взаємодії, в класі мають бути додані відповідні public-властивості (publicproperties)*
*якщо предметна область вимагає, то секція set властивості обов’язково повинна мати відповідну перевірку.
3.	До класу додати хоча б одну автовластивість**.
**передбачте значення за замовчуванням
4.	До класу додати хоча б одну обчислювальну властивість, яка не буде пов’язана з будь-яким полем класу і буде використовувати інші властивості та/або методи.
5.	Хоча б одна властивість повинна мати різній рівень доступу для секцій get і set***.
***пам’ятаємо, що модифікатор доступу секції має бути більш обмежувальним, ніж модифікатор самої властивості.
6.	Встановлення та зчитування значень полів в основній програмі реалізувати через додані у клас властивості.
7.	Меню в програмі залишається з лабораторної роботи № 1: 
1 – додати об’єкт 
2 – вивести на екран об’єкти 
3 – знайти об’єкт 
4 – видалити об’єкт 
5 – демонстрація поведінки 
0 – вийти з програми
8.	Детально протестувати програму. Мають бути протестовані всі пункти меню. Проводимо тестування не тільки на коректних значеннях, а також не забуваємо перевірити і некоректні значення, які може ввести користувач.
9.	Оформити звіт:

–	Титульний аркуш
–	Завдання
–	Короткий опис класу (опис характеристик та поведінки з точки зору замовника, не забути додати нову інформацію щодо класу)
–	Програмна реалізація класу
–	Class diagram
–	Код програми
–	Результати детального тестування програми (навести скріншоти виконання тестування програми, або скопіювати і вставити у звіт вивід програми на екран)

## ХІД РОБОТИ

#Опис програми
Мова програмування: С#
ОС: Windows 10
Процесор: AMD Ryzen 5 4600H
Компілятор: MS Visual Studio 2022

Опис програми:
1.	Написана програма є електронним щоденником, який заповнює користувач. Програма містить в собі клас Lesson, з відповідними для занять характеристиками (дата, коли відбудеться пара, номер пари за розкладом, дисципліна, номер тижня, формат проведення заняття). Деякі з них загальнодоступні, а інші з обмеженим доступом.
private DateTime lessonDate – Інформація про дату занять.
private int lessonNumber – Інформація про номер занять.
private string subject – Назва занять.
public enum LessonType – Інформація про тип проведення занять.
private bool isNumerator – Інформація про номер тижня.
private bool isRemedial – Автовластивість (чи є предмет заліковим).
2.	Програмна реалізація класу:
public class Lesson
    {
        private DateTime lessonDate;
        private int lessonNumber;
        private string subject;
        private LessonType type;
        private bool isNumerator;
        private bool isRemedial;

        public Lesson(DateTime lessonDate, int lessonNumber, string subject, LessonType type, bool isNumerator, bool isRemedial)
        {
            this.lessonDate = lessonDate;
            this.lessonNumber = lessonNumber;
            this.subject = subject;
            this.type = type;
            this.isNumerator = isNumerator;
            this.isRemedial = isRemedial;
            TotalHours = lessonDuration(type);
        }

        public DateTime LessonDate
        {
            get { return lessonDate; }
            set { lessonDate = value; }
        }

        public int LessonNumber
        {
            get { return lessonNumber; }
            set { lessonNumber = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public LessonType Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool IsNumerator
        {
            get { return isNumerator; }
            set { isNumerator = value; }
        }

        public bool IsRemedial
        {
            get { return isRemedial; }
        }

        public double TotalHours { get; private set; }

        private double lessonDuration(LessonType type)
        {
            if (type == LessonType.Online)
            {
                return 1.5;
            }
            else
            {
                return 2;
            }
        }
    }

    public enum LessonType
    {
        Online,
        InPerson,
        Hybrid
    }

1.	Class Diagram
![image](https://github.com/eugegene/Lab_8/assets/148196803/93dc46d3-44c1-4852-b5d7-b91c4ddb49b5)
Рисунок 1 – Створена діаграма класу

2.	Тестування:
2.1	 Для початку перевіримо, які значення може прийняти обмежувач кількості пар (див. рисунки 2.1 – 2.7):
![image](https://github.com/eugegene/Lab_8/assets/148196803/c12e39c4-f63e-400d-b56a-3ecbb3e54671)
Рисунок 2.1 – Перевірка №1

![image](https://github.com/eugegene/Lab_8/assets/148196803/7b8464fe-93f6-48b8-b6e2-250927b5b7d2)
Рисунок 2.2 – Перевірка №2

![image](https://github.com/eugegene/Lab_8/assets/148196803/9bef99f2-e208-485f-896a-f241b162c0e1)
Рисунок 2.3 – Перевірка №3

![image](https://github.com/eugegene/Lab_8/assets/148196803/5756b6c2-6293-479e-b3f9-5dcb9b4d2def)
Рисунок 2.4 – Перевірка №4

![image](https://github.com/eugegene/Lab_8/assets/148196803/9c6af17f-4c25-41aa-b7f3-d22337b83f22)
Рисунок 2.5 – Перевірка №5

![image](https://github.com/eugegene/Lab_8/assets/148196803/517b8c81-b88e-4da3-8eea-79589412c5bf)
Рисунок 2.6 – Перевірка №6

![image](https://github.com/eugegene/Lab_8/assets/148196803/ab34cd61-8e2b-45aa-8ff9-5624d5e2c5a3)
Рисунок 2.7 – Перевірка №7
(було введено число 4)

2.2	  Далі перевіримо перший пункт Додавання занять:
![image](https://github.com/eugegene/Lab_8/assets/148196803/d7c7febd-9b23-430b-9efb-bddd78113202)
Рисунок 3.1 – Перевірка №8

![image](https://github.com/eugegene/Lab_8/assets/148196803/6b0490a4-af27-4f0d-8bcf-39cde1840b69)
Рисунок 3.2 – Перевірка №9

![image](https://github.com/eugegene/Lab_8/assets/148196803/c0636d92-10ff-4194-8e87-4177671fb387)
Рисунок 3.3 – Перевірка №10

![image](https://github.com/eugegene/Lab_8/assets/148196803/2778913f-fc86-4278-a171-3ed10bd38bdb)
Рисунок 3.4 – Перевірка №11

![image](https://github.com/eugegene/Lab_8/assets/148196803/3657f01b-30c1-41cb-b2c6-ffd40be2717e)
Рисунок 3.5 – Перевірка №12

2.3	 Додамо ще 3 заняття в розклад, та перевіримо їх наявність, викликавши Мої заняття (Також спробуємо додати ще одне, яке не може бути додано через заданий раніше ліміт):
![image](https://github.com/eugegene/Lab_8/assets/148196803/85ea377d-a1d2-4e04-92a8-cc3e8dbdeee0)
Рисунок 4.1 – Перевірка №13

![image](https://github.com/eugegene/Lab_8/assets/148196803/562b3d5e-b2ab-47c6-9acb-6a130e9616ce)
Рисунок 4.2 – Перевірка №14

2.4	 Далі спробуємо знайти заняття, які були додані (виконаємо пошук по всіх доступних опціях):

![image](https://github.com/eugegene/Lab_8/assets/148196803/9092682c-5bb8-4711-9edc-8f3e0583010d)
Рисунок 5.1 – Перевірка №15

![image](https://github.com/eugegene/Lab_8/assets/148196803/ec8d347c-a2ce-4d02-bd71-387b1935dcdd)
Рисунок 5.2 – Перевірка №16

![image](https://github.com/eugegene/Lab_8/assets/148196803/6c1a3927-3290-4582-a2bc-57461ca469e3)
Рисунок 5.3 – Перевірка №17

![image](https://github.com/eugegene/Lab_8/assets/148196803/5ca5694a-cdc2-402d-bdb3-e9b0fa0c9ffc)
Рисунок 5.4 – Перевірка №18

![image](https://github.com/eugegene/Lab_8/assets/148196803/c7794ea5-7d36-404a-a632-0904ad4f8acf)
Рисунок 5.5 – Перевірка №19

![image](https://github.com/eugegene/Lab_8/assets/148196803/cde8060d-cb37-48ad-bd0b-84618cccc5d7)
Рисунок 5.6 – Перевірка №20

![image](https://github.com/eugegene/Lab_8/assets/148196803/aaf8c0e7-3ad5-4485-a4ad-03de4ebd61b3)
Рисунок 5.7 – Перевірка №21

2.5	 Під час додавання занять було додано зайве завдання, яке ми спробуємо видалити:
![image](https://github.com/eugegene/Lab_8/assets/148196803/9e7367c9-aae8-4125-879e-a6e1c7fe27f9)
Рисунок 6.1 – Перевірка №22

![image](https://github.com/eugegene/Lab_8/assets/148196803/9077644a-55f9-4a43-a626-5763481e7689)
Рисунок 6.2 – Перевірка №23

![image](https://github.com/eugegene/Lab_8/assets/148196803/2368b5fd-ca51-45ab-a3ac-57559541dc78)
Рисунок 6.3 – Перевірка №24

Повторюємо процедуру, поки не видалимо заняття, які залишились. Також спробуємо видалити заняття, коли їх не існує:

![image](https://github.com/eugegene/Lab_8/assets/148196803/d40c5d28-3333-4e15-a8a7-8109311c94c8)
Рисунок 6.4 – Перевірка №25

![image](https://github.com/eugegene/Lab_8/assets/148196803/afb311fe-0880-4c98-98e8-501f183fa624)
Рисунок 6.5 – Перевірка №26

2.6	 Викличемо список виконаних дій, натиснувши “5” в головному меню:
![image](https://github.com/eugegene/Lab_8/assets/148196803/f95316b5-b6aa-4c6d-8c7c-85389ac9b3a0)
Рисунок 7 – Перевірка №27
 
## ВИСНОВОК
У ході виконання лабораторної роботи я:
–	Інкапсулював поля класу як приватні;
–	Додав до класу автовластивість та обчислювальну властивість;
–	Провів детальне тестування програми, додав скріншоти.
 
## ДОДАТОК А
Машинний лістинг програми
Program.cs: 
using System;

namespace Lab1_Petrenko_program
{
    internal class Program
    {
        static List<Lesson> lessons = new List<Lesson>(); // ініціалізація списку пар
        private static List<string> logs = new List<string>(); // ініціалізація списку логів

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Lab1_Petrenko_program!\nHere you can choose lessons\nPress any button to open the menu ↓↓↓"); // початковий екран
            Console.ReadKey(true);

            Console.Write("Enter the maximum number of lessons to store (N): "); // встановлення ліміту кількості пар
            if (int.TryParse(Console.ReadLine(), out int maxLessons) && maxLessons > 0)
            {
                while (true)
                {
                    Console.Clear(); // нижче головне меню
                    Console.WriteLine("1. Add lesson\n2. My lessons\n3. Find lesson\n4. Remove lesson\n5. Logs (for devs)\n0. Exit");
                    char choice = Console.ReadKey(true).KeyChar;
                    switch (choice)
                    {
                        case '1': // додати пару
                            Console.Clear();
                            AddLesson(maxLessons);
                            break;

                        case '2': // переглянути додані пари
                            Console.Clear();
                            ViewLessons(lessons);
                            break;

                        case '3': // пошук пари
                            Console.Clear();
                            SearchLessons(lessons);
                            Console.ReadLine();
                            break;

                        case '4': // видалити пару
                            Console.Clear();
                            RemoveLesson(lessons);
                            break;

                        case '5': // переглянути дії (для розробників)
                            Console.Clear();
                            UserLogs(logs);
                            break;

                        case '0': // вийти з програми
                            Environment.Exit(0);
                            break;

                        default: // введено некоректні дані
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ReadKey(true);
                            break;
                    }
                }
            }

            else
            { Console.WriteLine("Invalid input for N. Please enter a positive integer greater than 0."); }
        }

        private static void AddLesson(int maxLessons) // метод додання пари
        {
            if (lessons.Count >= maxLessons) // повідомлення про вичерпанню ліміту
            {
                Console.WriteLine("You have reached the maximum number of lessons that can be stored.");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey(true);
                return;
            }

            while (true) // цикл на випадок введення користувачем некоректних даних
            {
                Console.Write("Choose the date when the lesson should take place (yyyy-MM-dd): ");
                string dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out DateTime LessonDate)) // обмеження дати на навчальний рік 2023-2024
                {
                    DateTime startDate = new DateTime(2023, 9, 1);
                    DateTime endDate = new DateTime(2024, 6, 1);

                    if (LessonDate >= startDate && LessonDate <= endDate) 
                    {
                        while (true)
                        {
                            Console.Write("Choose a lesson number (1-5): ");
                            string numberInput = Console.ReadLine();
                            if (int.TryParse(numberInput, out int lessonNumber) && lessonNumber >= 1 && lessonNumber <= 5)  // обмеження введення номеру пари
                            {
                                while (true)
                                {
                                    Console.Write("Choose a subject (Available only: OOP, ASD, High Math, PE, WB, Java): "); // перелік доступних предметів
                                    string subject = Console.ReadLine();
                                    bool isRemedial = true;
                                    if (IsSubjectValid(subject))
                                    {
                                        while (true)
                                        {
                                            Console.Write("Press N if it's a numerator week, and D, if it's denominator week: "); // чисельник/знаменник
                                            ConsoleKeyInfo weekkey = Console.ReadKey(true);
                                            if (weekkey.Key == ConsoleKey.N || weekkey.Key == ConsoleKey.D)
                                            {
                                                bool isNumerator = weekkey.Key == ConsoleKey.N;

                                                while (true)
                                                {
                                                    Console.Write("\nChoose the format (O for Online, I for InPerson, H for Hybrid): \n"); // онлайн/офлайн/гібрид
                                                    ConsoleKeyInfo formatKey = Console.ReadKey(true);
                                                    if (formatKey.Key == ConsoleKey.O || formatKey.Key == ConsoleKey.I || formatKey.Key == ConsoleKey.H)
                                                    {
                                                        LessonType lessonType = LessonType.Online;
                                                        if (formatKey.Key == ConsoleKey.I)
                                                        {
                                                            lessonType = LessonType.InPerson;
                                                        }
                                                        else if (formatKey.Key == ConsoleKey.H)
                                                        {
                                                            lessonType = LessonType.Hybrid;
                                                        }
                                                        Lesson newLesson = new Lesson(LessonDate, lessonNumber, subject, lessonType, isNumerator, isRemedial);

                                                        lessons.Add(newLesson); // додання пари до списку
                                                        logs.Add($"Added a lesson - Date: {newLesson.LessonDate.ToShortDateString()}, Number: {newLesson.LessonNumber}, Subject: {newLesson.Subject}, Is remedial: {newLesson.IsRemedial}"); // записали в логи

                                                        Console.WriteLine("\nYou did it! This lesson was added to the list. You can check it later.");
                                                        Console.WriteLine("Press any button to go back");
                                                        Console.ReadKey(true);
                                                        return; // вихід з методу після успішного додавання
                                                    }
                                                    else
                                                    { Console.WriteLine("Invalid input. Please choose 'O' for Online, 'I' for InPerson, or 'H' for Hybrid."); }
                                                }
                                            }
                                            else
                                            { Console.WriteLine("\nInvalid input. Press 'N' for numerator or 'D' for denominator."); }
                                        }
                                    }
                                    else
                                    { Console.WriteLine("Invalid subject. Please choose from the available options."); }
                                }
                            }
                            else
                            { Console.WriteLine("Invalid lesson number. Please enter a number between 1 and 5."); }
                        }
                    }
                    else
                    { Console.WriteLine("Invalid date. The lesson date should be between September 1, 2023, and June 1, 2023."); }

                }
                else
                { Console.WriteLine("Invalid date format. Please use yyyy-MM-dd format."); }
            }
        }

        static bool IsSubjectValid(string subject) // перевірка обраної дисципліни серед можливих
        {
            string[] validSubjects = { "OOP", "ASD", "High Math", "PE", "WB", "Java" }; // перелік доступних пар (регістр не враховується)
            return Array.Exists(validSubjects, s => s.Equals(subject, StringComparison.OrdinalIgnoreCase));
        }

        private static void ViewLessons(List<Lesson> lessons) // переглянути додані заняття
        {
            Console.WriteLine($"Total Hours for all Lessons: {lessons.Sum(lesson => lesson.TotalHours)}\n");
            Console.WriteLine("List of Lessons:\n");
            foreach (var lesson in lessons)
            {
                Console.WriteLine($"Date: {lesson.LessonDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Lesson Number: {lesson.LessonNumber}");
                Console.WriteLine($"Subject: {lesson.Subject}");
                Console.WriteLine(lesson.IsNumerator ? "Numerator week" : "Denominator week");
                Console.WriteLine($"Lesson Type: {lesson.Type}");
                if (lesson.IsRemedial == true ) Console.WriteLine("Is remedial: Yes");
                Console.WriteLine();
            }

            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

        private static void SearchLessons(List<Lesson> lessons) // меню пошуку пари
        {
            Console.WriteLine("Search Lessons:");
            Console.WriteLine("1. Search by Date");
            Console.WriteLine("2. Search by Subject");
            Console.WriteLine("3. Search by Lesson Type");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select a search option: ");

            string searchOption = Console.ReadLine();

            switch (searchOption)
            {
                case "1":
                    SearchByDate(lessons);
                    break;

                case "2":
                    SearchBySubject(lessons);
                    break;

                case "3":
                    SearchByLessonType(lessons);
                    break;

                case "0":
                    break;

                default:
                    Console.WriteLine("Invalid search option. Please try again.");
                    break;
            }
        }

        private static void SearchByDate(List<Lesson> lessons)
        {
            Console.Write("Enter the date to search for (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();

            if (DateTime.TryParse(dateInput, out DateTime searchDate))
            {
                var matchingLessons = lessons.Where(lesson => lesson.LessonDate.Date == searchDate.Date).ToList();

                if (matchingLessons.Any()) // якщо існує хоч одна пара, яка підходить за критерієм пошуку - виводимо її
                {
                    Console.WriteLine($"\nFound {matchingLessons.Count} lessons on {searchDate.Date.ToString("yyyy-MM-dd")}:");
                    foreach (var lesson in matchingLessons)
                    {
                        lessonOutputInfo(lesson);
                    }
                    logs.Add($"Searched for lessons on {searchDate.Date.ToString("yyyy-MM-dd")}"); // записали в логи
                }
                else
                { Console.WriteLine("No lessons found for the specified date."); } // інакше виводимо, що такої пари не існує
            }
            else
            { Console.WriteLine("Invalid date format. Please use yyyy-MM-dd format."); }
        }

        private static void lessonOutputInfo(Lesson? lesson)
        {
            Console.WriteLine($"Lesson Number: {lesson.LessonNumber}");
            Console.WriteLine($"Subject: {lesson.Subject}");
            Console.WriteLine(lesson.IsNumerator ? "Numerator week" : "Denominator week");
            Console.WriteLine($"Lesson Type: {lesson.Type}");
            if (lesson.IsRemedial == true) Console.WriteLine("Is remedial: Yes");
            Console.WriteLine();
        }

        private static void SearchBySubject(List<Lesson> lessons)
        {
            Console.Write("Enter the subject to search for: ");
            string subjectInput = Console.ReadLine();

            var matchingLessons = lessons.Where(lesson => lesson.Subject.Equals(subjectInput, StringComparison.OrdinalIgnoreCase)).ToList();

            if (matchingLessons.Any()) // якщо існує хоч одна пара, яка підходить за критерієм пошуку - виводимо її
            {
                Console.WriteLine($"\nFound {matchingLessons.Count} lessons for subject: {subjectInput}:");
                foreach (var lesson in matchingLessons)
                {
                    lessonOutputInfo(lesson);
                }
                logs.Add($"Searched for lessons with subject: {subjectInput}. Found {matchingLessons.Count} lessons."); // записали в логи
            }
            else
            { Console.WriteLine($"No lessons found for subject: {subjectInput}."); } // інакше виводимо, що такої пари не існує
        }

        private static void SearchByLessonType(List<Lesson> lessons)
        {
            Console.Write("Enter the lesson type to search for (Online, InPerson, Hybrid): ");
            string typeInput = Console.ReadLine();

            if (Enum.TryParse(typeInput, true, out LessonType searchType))
            {
                var matchingLessons = lessons.Where(lesson => lesson.Type == searchType).ToList();

                if (matchingLessons.Any()) // якщо існує хоч одна пара, яка підходить за критерієм пошуку - виводимо її
                {
                    Console.WriteLine($"\nFound {matchingLessons.Count} lessons of type: {searchType}:");
                    foreach (var lesson in matchingLessons)
                    {
                        lessonOutputInfo(lesson);
                    }
                    logs.Add($"Searched for lessons with type: {searchType}. Found {matchingLessons.Count} lessons."); // записали в логи
                }
                else
                { Console.WriteLine($"No lessons found for type: {searchType}."); } // інакше виводимо, що такої пари не існує
            }
            else
            { Console.WriteLine("Invalid lesson type. Please enter Online, InPerson, or Hybrid."); }
        }

        private static void RemoveLesson(List<Lesson> lessons)
        {
            if (lessons.Count == 0)
            {
                Console.WriteLine("There are no lessons to remove.");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Remove Lesson:");
            Console.WriteLine("1. Choose lesson to remove");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select a removal option: ");

            string removalOption = Console.ReadLine();

            switch (removalOption)
            {
                case "1":
                    RemoveByNumber(lessons);
                    break;

                case "0":
                    break;

                default:
                    Console.WriteLine("Invalid removal option. Please try again.");
                    break;
            }
            Console.ReadLine();
        }

        private static void RemoveByNumber(List<Lesson> lessons)
        {
            Console.Write("Enter the date to remove lessons (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();

            if (DateTime.TryParse(dateInput, out DateTime removeDate))
            {
                var matchingLessons = lessons.Where(lesson => lesson.LessonDate.Date == removeDate.Date).ToList();

                if (matchingLessons.Any())
                {
                    Console.WriteLine($"Found {matchingLessons.Count} lessons on {removeDate.Date.ToString("yyyy-MM-dd")}:");
                    foreach (var lesson in matchingLessons)
                    {
                        lessonOutputInfo(lesson);
                    }

                    Console.Write("Enter the lesson number to remove in this date (1-5): ");
                    string numberInput = Console.ReadLine();

                    if (int.TryParse(numberInput, out int lessonNumber) && lessonNumber >= 1 && lessonNumber <= 5)
                    {
                        var lessonToRemove = matchingLessons.FirstOrDefault(lesson => lesson.LessonNumber == lessonNumber);

                        if (lessonToRemove != null)
                        {
                            Console.WriteLine("Do you want to remove this lesson? (Y/N): ");
                            var removeChoice = Console.ReadKey(true).Key;
                            if (removeChoice == ConsoleKey.Y)
                            {
                                lessons.Remove(lessonToRemove);
                                Console.WriteLine("Lesson removed.");
                                logs.Add($"Removed a lesson - Date: {lessonToRemove.LessonDate.ToShortDateString()}, Number: {lessonToRemove.LessonNumber}, Subject: {lessonToRemove.Subject}, Is remedial: {lessonToRemove.IsRemedial}"); // записали в логи
                            }
                            else
                            { Console.WriteLine("Lesson not removed."); }
                        }
                        else
                        { Console.WriteLine($"No lessons found with Lesson Number: {lessonNumber} on {removeDate.Date.ToString("yyyy-MM-dd")}."); }
                    }
                    else
                    { Console.WriteLine("Invalid lesson number. Please enter a number between 1 and 5."); }
                }
                else
                { Console.WriteLine("No lessons found for the specified date."); }
            }
            else
            { Console.WriteLine("Invalid date format. Please use yyyy-MM-dd format."); }
        }

        private static void UserLogs(List<string> actions) // метод для запису дій користувача
        {
            Console.WriteLine("User Actions History:");
            foreach (string action in actions)
                { Console.WriteLine(action); }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
} 

## ДОДАТОК Б
Машинний лістинг програми
Lesson.cs:
namespace Lab1_Petrenko_program
{
    public class Lesson
    {
        private DateTime lessonDate;
        private int lessonNumber;
        private string subject;
        private LessonType type;
        private bool isNumerator;
        private bool isRemedial;

        public Lesson(DateTime lessonDate, int lessonNumber, string subject, LessonType type, bool isNumerator, bool isRemedial)
        {
            this.lessonDate = lessonDate;
            this.lessonNumber = lessonNumber;
            this.subject = subject;
            this.type = type;
            this.isNumerator = isNumerator;
            this.isRemedial = isRemedial;
            TotalHours = lessonDuration(type);
        }

        public DateTime LessonDate
        {
            get { return lessonDate; }
            set { lessonDate = value; }
        }

        public int LessonNumber
        {
            get { return lessonNumber; }
            set { lessonNumber = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public LessonType Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool IsNumerator
        {
            get { return isNumerator; }
            set { isNumerator = value; }
        }

        public bool IsRemedial
        {
            get { return isRemedial; }
        }

        public double TotalHours { get; private set; }

        private double lessonDuration(LessonType type)
        {
            if (type == LessonType.Online)
            {
                return 1.5;
            }
            else
            {
                return 2;
            }
        }
    }

    public enum LessonType
    {
        Online,
        InPerson,
        Hybrid
    }
}


   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
