using CoreFramework.Mailing;
using MailKit;
using Ordering.Application.Services.OrderLogService;
using System.Net.WebSockets;

namespace Ordering.Hangfire.Services;

public class DailyLogService:IDailyLogService
{
    private readonly IOrderLogService _orderLogService;
    private readonly CoreFramework.Mailing.IMailService _mailService;

    public DailyLogService(IOrderLogService orderLogService, CoreFramework.Mailing.IMailService mailService)
    {
        _orderLogService = orderLogService;
        _mailService = mailService;
    }

    public async Task SendLogs()
    {
        //await Console.Out.WriteLineAsync("Hangfire is worked");
        var mail = new Mail()
        {
            TextBody = await _orderLogService.GetOrderLogs(),
            Subject = "Daily Order Logs",
            ToEmail = "xxxx",
            ToFullName = "xxxxx",
        };
        _mailService.SendMail(mail);
    }
}
