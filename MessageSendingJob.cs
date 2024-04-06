using System.Net.Mail;
using System.Reflection.Metadata;
using Quartz;

namespace ASP.NET_MVC_Core
{   // использование Quartz, чтобы запланировать отправку сообщений
    public class MessageSendingJob : IJob
    {
        private readonly MessageService _messageService;
        private readonly EmailMessage _emailMessage;

        public MessageSendingJob(MessageService messageService, EmailMessage emailMessage)
        {
            _messageService = messageService;
            _emailMessage = emailMessage;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _messageService.SendEmailAsync(_emailMessage);
        }
    }

    public class QuartzConfig
    {
        public static void ConfigureScheduler()
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler().Result;
            scheduler.Start();

            var job = JobBuilder.Create<MessageSendingJob>()
               .WithIdentity("messageSendingJob", "messageSendingGroup")
               .Build();

            var trigger = TriggerBuilder.Create()
               .WithIdentity("messageSendingTrigger", "messageSendingGroup")
               .StartNow()
               .WithSimpleSchedule(x => x
                   .WithIntervalInMinutes(10)
                   .RepeatForever())
               .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}
