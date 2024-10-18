string CheckLeapYear(int year)
{
    bool i;
    if (year % 4 == 0 && year % 400 == 0 && year % 100 == 0) i = true;
    else if (year % 4 == 0 && year % 400 != 0 && year % 100 == 0) i = false;
    else if (year % 4 == 0) i = true;
    else if (year % 4 == 0 && year % 100 == 0 && year % 1000 == 0) i = true;
    else i = false;

    if (i == true) return "високосного";
    else return "не високосного";
}

string monthFormula(int day, int month, int year) 
{
    int t = 0;
    string montName = "";
    switch (month)
    {
        case 1:
            t = 0 + day;
            montName = "Января";
            break;
        case 2:
            t = 31 + day;
            montName = "Февраля";
            break;
        case 3:
            t = 59 + day;
            montName = "Марта";
            break;
        case 4:
            t = 90 + day;
            montName = "Апреля";
            break;
        case 5:
            t = 120 + day;
            montName = "Мая";
            break;
        case 6:
            t = 151 + day;
            montName = "Июня";
            break;
        case 7:
            t = 181 + day;
            montName = "Июля";
            break;
        case 8:
            t = 212 + day;
            montName = "Фвгуста";
            break;
        case 9:
            t = 243 + day;
            montName = "Сентября";
            break;
        case 10:
            t = 273 + day;
            montName = "Октября";
            break;
        case 11:
            t = 304 + day;
            montName = "Ноября";
            break;
        case 12:
            t = 334 + day;
            montName = "Декабря";
            break;
    }
    int formula = (year + (year - 1) / 4 + (t + 5)) % 7;
    string dayoftheweek = "";
    switch (formula)
    {
        case 1:
            dayoftheweek = "вооскресенье";
            break;
        case 2:
            dayoftheweek = "понедельник";
            break;
        case 3:
            dayoftheweek = "вторник";
            break;
        case 4:
            dayoftheweek = "среда";
            break;
        case 5:
            dayoftheweek = "четверг";
            break;
        case 6:
            dayoftheweek = "пятница";
            break;
        case 0:
            dayoftheweek = "суббота";
            break;
    }
    if (month != 0) return montName;
    else return dayoftheweek;
}

Console.Write("С начала 1990 года по некоторый день прощло n месяцев и 2 дня. \nВведите n>>>");

string n = Console.ReadLine();
string[] start = {"3","1","1990", ""}; // день0/месяц1/год2/доп.поле3 == 4 
string[] answer = new string[5]; // день.недели0/число1/месяц2/высокосный.или.нет3/год4 == 5

answer[1] = start[0];
answer[4] += Convert.ToInt32(start[2]) + Convert.ToInt32(n) / 12; // 1990+месяцы.поделенные.на.год(12месяцев)
start[3] += Convert.ToInt32(start[1]) + Convert.ToInt32(n) % 12;// январь+не.полный.год(несколько месяцев не хватает до целого года), возращает номер месяца, не название
answer[3] = CheckLeapYear(Convert.ToInt32(answer[4])); // принимает год выдает высокосный или нет
answer[0] = monthFormula(Convert.ToInt32(answer[1]), 0, Convert.ToInt32(answer[4]));// возвращает день недели
answer[3] = monthFormula(Convert.ToInt32(answer[1]), Convert.ToInt32(start[3]), Convert.ToInt32(answer[4]));//возвращает название месяца

Console.WriteLine($"Сегодня {answer[0]} {answer[1]}-го {answer[2]} {answer[3]} {answer[4]}-го года.");