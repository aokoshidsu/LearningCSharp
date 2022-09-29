using System;

namespace TicTacToe
{
    class Program
    {
        static void drawField(int[] field)
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("| ");
                    if (field[3*i+j] == -999)
                        Console.Write(3*i + j + 1);
                    else if (field[3*i+j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                        Console.Write("O");
                        Console.ResetColor(); // сбрасываем в стандартный
                    }
                    else if (field[3*i+j] == 1) {
                        Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                        Console.Write("X");
                        Console.ResetColor(); // сбрасываем в стандартный
                    }
                    Console.Write(" ");   
                }
                Console.WriteLine("|");
                Console.WriteLine("-------------");
            }
        }
        static bool checkMove(int[] field, int move)
        {
            if (move < 1 || move > 9)
            {
                Console.WriteLine("Такой клетки даже не существует. Попробуйте другую.");
                return false;
            }

            if (field[move - 1] != -999)
            {
                Console.WriteLine("Эта клетка уже занята. Попробуйте другую.");
                return false;
            }
                return true;
        }
        static bool makeMove(ref int[] field, int move, int sign)
        {
            if (!checkMove(field, move))
                return false;
            field[move - 1] = sign;
            return true;
        }
        static bool endOfGame(int[] field)
        {
            int ct = 0;
            foreach (int i in field)
                if (i == -999)
                    ct++;

            if (ct == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Поздравляем, у вас ничья! Ваша дружба стоит выше любых побед.");
                return true;
            }

            ct = 0;
            for (int i = 0; i < 3; i++)
            { //проверка горизонтальных строк
                if (field[i * 3] != -999 && field[i*3] == field[i*3+1] && field[i*3] == field[i*3+2])
                {
                        Console.WriteLine();
                        if (field[i*3] == 0)
                            Console.WriteLine("Поздравляем, Нолик! Сегодня ты круглый победитель.");
                        else
                            Console.WriteLine("Поздравляем, Крестик! Крест сегодня мы поставим на твоём сопернике.");
                        return true;
                }

                //проверка вертикальных строк
                if (field[i] != -999 && field[i] == field[i+3] && field[i] == field[i+6])
                {
                        Console.WriteLine();
                        if (field[i] == 0)
                            Console.WriteLine("Поздравляем, Нолик! Сегодня ты круглый победитель.");
                        else
                            Console.WriteLine("Поздравляем, Крестик! Крест сегодня мы поставим на твоём сопернике.");
                        return true;
                }

                    //проверка диагональных строк
                if (field[i] != -999 && i == 0)
                {
                        if (field[0] == field[4] && field[0] == field[8])
                        {
                            Console.WriteLine();
                            if (field[0] == 0)
                                Console.WriteLine("Поздравляем, Нолик! Сегодня ты круглый победитель.");
                            else
                                Console.WriteLine("Поздравляем, Крест сегодня мы поставим на твоём сопернике.");
                            return true;
                        }
                }

                if (field[i] != -999 && i == 2)
                {
                        if (field[2] == field[4] && field[2] == field[6])
                        {
                            Console.WriteLine();
                            if (field[2] == 0)
                                Console.WriteLine("Поздравляем, Нолик! Сегодня победа за тобой.");
                            else
                                Console.WriteLine("Поздравляем, Крестик! Крест сегодня мы поставим на тебе.");
                            return true;
                        }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            int mode = 999;
            while (mode != 1) {
                Console.WriteLine("Хотите начать игру? [0 - выход/1 - начать]");
                mode = Convert.ToInt32(Console.ReadLine());
                if (mode == 0)
                    return;
                else if (mode != 1)
                {
                    Console.Clear();
                    Console.WriteLine("Неверный ввод. Попытайтесь снова. Здесь только два варианта: 0 и 1");
                }
            }
            // 0 - нолик
            // 1 - крестик
            // -999 - пустая клетка
            var field = new int[9];
            for (int i = 0; i < 9; i++)
                field[i] = -999;

            int sign = 0;
            int move = 0;

            while (!endOfGame(field))
            {
                Console.Clear();
                drawField(field);
                Console.WriteLine();
                //Ход нолика
                if (sign == 0)
                {
                    do {
                        Console.WriteLine("Нолик, ваш ход!");
                        Console.Write("Введите номер клетки, куда сделать ход: ");
                        move = Convert.ToInt32(Console.ReadLine());
                    } while (!makeMove(ref field, move, sign));
                    sign = 1;
                }
                //Ход крестика
                else if (sign == 1)
                {
                    do {
                        Console.WriteLine("Крестик, ваш ход!");
                        Console.Write("Введите номер клетки, куда сделать ход: ");
                        move = Convert.ToInt32(Console.ReadLine());
                    } while (!makeMove(ref field, move, sign)) ;
                    sign = 0;
                }
            }
        }
    }
}
