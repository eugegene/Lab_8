using System;
//pushed
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