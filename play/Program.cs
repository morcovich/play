namespace play
{
    using System;

    class Program
    {
        static void Main()
        {
            string playerName;
            bool hasKey = false;
            bool hasArtifacts = false;
            bool hasLockpick = false;
            bool escaped = false;

            // Ввод имени игрока
            Console.Write("Введите имя персонажа: ");
            playerName = Console.ReadLine();

            
            while (!escaped)
            {
                // Описание текущего состояния комнаты
                Console.Clear();
                Console.WriteLine($"{playerName}, вы проснулись в комнате.");
                Console.WriteLine("Вы видите следующие предметы:");
                Console.WriteLine("1. Открыть дверь");
                Console.WriteLine("2. Заглянуть под кровать");
                Console.WriteLine("3. Открыть ящик в углу комнаты");
                Console.WriteLine("4. Открыть вентиляцию");
                Console.WriteLine("5. Взглянуть на тумбочку");
                Console.WriteLine("6. Взглянуть на статую рядом с дверью");
                Console.Write("Выберите действие (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (hasLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы использовали отмычку и открыли дверь.");
                            Console.WriteLine($"{playerName}, вы успешно сбежали!");
                            escaped = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, дверь заперта. Вам нужно найти отмычку.");
                        }
                        break;

                    case "2":
                        if (!hasArtifacts)
                        {
                            Console.WriteLine($"{playerName}, вы заглянули под кровать и нашли первый артефакт.");
                            hasArtifacts = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, под кроватью больше ничего нет.");
                        }
                        break;

                    case "3":
                        if (hasKey)
                        {
                            Console.WriteLine($"{playerName}, вы открыли ящик и нашли отмычку от двери.");
                            hasLockpick = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ящик заперт. Вам нужно получить ключ от ящика.");
                        }
                        break;

                    case "4":
                        Console.WriteLine($"{playerName}, вы пробуете открыть вентиляцию.");
                        for (int i = 1; i <= 3; i++)
                        {
                            Console.WriteLine($"Попытка {i}...");
                        }
                        Console.WriteLine($"{playerName}, вы нашли второй артефакт в вентиляции.");
                        hasArtifacts = true;
                        break;

                    case "5":
                        if (!hasArtifacts)
                        {
                            Console.WriteLine($"{playerName}, вы взглянули на тумбочку и нашли третий артефакт.");
                            hasArtifacts = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, на тумбочке больше ничего нет.");
                        }
                        break;

                    case "6":
                        if (!hasKey)
                        {
                            Console.WriteLine($"{playerName}, вы взглянули на статую и поняли, что она активируется артефактами.");
                            if (hasArtifacts)
                            {
                                Console.WriteLine($"{playerName}, вы активировали статую тремя артефактами.");
                                hasKey = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, статуя уже активирована, у вас есть ключ от ящика.");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите вариант от 1 до 6.");
                        break;
                }

                
                if (!escaped)
                {
                    Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                }
            }
        }
    }

}
