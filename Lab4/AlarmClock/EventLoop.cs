using System;
using System.Threading;

namespace AlarmClock
{
    public delegate void AlarmTriggeredHandler(DateTime alarmTime, string message);

    public class EventLoop
    {
        private readonly DateTime _alarmTime;
        private readonly string _message;
        private readonly Func<DateTime> _timeProvider;
        private bool _triggered = false;

        public event AlarmTriggeredHandler? AlarmTriggered;

        public EventLoop(
            DateTime alarmTime,
            string message,
            Func<DateTime>? timeProvider = null
        )
        {
            _alarmTime = alarmTime;
            _message = message;
            _timeProvider = timeProvider ?? (() => DateTime.Now);
        }

        public void Start()
        {
            while (!_triggered)
            {
                var now = _timeProvider();
                if (now >= _alarmTime)
                {
                    _triggered = true;
                    AlarmTriggered?.Invoke(_alarmTime, _message);
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
        }

        public void RunOnce(DateTime currentTime)
        {
            if (!_triggered && currentTime >= _alarmTime)
            {
                _triggered = true;
                AlarmTriggered?.Invoke(_alarmTime, _message);
            }
        }
    }
}
