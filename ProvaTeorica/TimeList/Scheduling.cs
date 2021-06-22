using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTeorica.TimeList
{
    public class Scheduling
    {        

        public List<Schedule> ValidateSchedulingTime(List<Schedule> schedules, DateTime startTimeService, DateTime endTimeService)
        {
            schedules = schedules.OrderBy(x => x.StartTime).ToList();
            List<Schedule> scheduled = new();
            schedules.ForEach(schedule =>
            {
                if (schedule.StartTime >= startTimeService && schedule.EndTime <= endTimeService)
                {
                    startTimeService = schedule.EndTime;
                    Console.WriteLine(schedule.Name + " pode ser agendado!");
                    scheduled.Add(schedule);

                }
            });

            return scheduled;
        }

        public double ScheduleOccupancyRate(List<Schedule> schedules, DateTime startTimeService, DateTime endTimeService)
        {
            TimeSpan totalhours = new TimeSpan();
            schedules.ForEach(schedule =>
            {
                totalhours += new TimeSpan(schedule.EndTime.Ticks - schedule.StartTime.Ticks);
            });

            TimeSpan scheduleHours = new TimeSpan(endTimeService.Ticks - startTimeService.Ticks);

            return totalhours/scheduleHours * 100;            
        }
    }
}
