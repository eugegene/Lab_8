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
