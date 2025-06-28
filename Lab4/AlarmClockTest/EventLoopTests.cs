using System;
using Xunit;
using AlarmClock;

namespace AlarmClockTest
{
    public class EventLoopTests
    {
        [Fact]
        public void AlarmTriggersWhenTimeReached()
        {
            var alarmTime = new DateTime(2025, 6, 28, 12, 0, 0);
            var message = "hello world";

            DateTime? triggeredTime = null;
            string? triggeredMessage = null;

            var loop = new EventLoop(alarmTime, message);
            loop.AlarmTriggered += (time, msg) =>
            {
                triggeredTime = time;
                triggeredMessage = msg;
            };

            loop.RunOnce(alarmTime);

            Assert.Equal(alarmTime, triggeredTime);
            Assert.Equal(message, triggeredMessage);
        }

        [Fact]
        public void AlarmDoesNotTriggerBeforeTime()
        {
            var alarmTime = new DateTime(2025, 6, 28, 12, 0, 0);
            var message = "test";

            DateTime? triggeredTime = null;
            string? triggeredMessage = null;

            var loop = new EventLoop(alarmTime, message);
            loop.AlarmTriggered += (time, msg) =>
            {
                triggeredTime = time;
                triggeredMessage = msg;
            };

            loop.RunOnce(alarmTime.AddSeconds(-1));

            Assert.Null(triggeredTime);
            Assert.Null(triggeredMessage);
        }
    }
}
