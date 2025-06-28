using System;
using AlarmClock;

namespace AlarmClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть час будильника (hh:mm:ss): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan ts))
            {
                Console.WriteLine("Неправильний формат часу.");
                return;
            }

            var now = DateTime.Now;
            var alarmTime = new DateTime(
                now.Year, now.Month, now.Day,
                ts.Hours, ts.Minutes, ts.Seconds
            );

            if (alarmTime <= now)
                alarmTime = alarmTime.AddDays(1);

            Console.Write("Введіть повідомлення для будильника: ");
            var message = Console.ReadLine() ?? "";

            var loop = new EventLoop(alarmTime, message);
            loop.AlarmTriggered += (time, msg) =>
            {
                Console.WriteLine(
                    $"Будильник о {time:HH:mm:ss} спрацював, ваше повідомлення: {msg}"
                );
            };

            Console.WriteLine($"Будильник встановлено на {alarmTime:HH:mm:ss}. Очікуємо...");
            loop.Start();
        }
    }
}
