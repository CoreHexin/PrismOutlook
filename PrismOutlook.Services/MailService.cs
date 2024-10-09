using PrismOutlook.Business;
using PrismOutlook.Services.Interfaces;
using System.Collections.ObjectModel;

namespace PrismOutlook.Services;

public class MailService : IMailService
{
    private static List<MailMessage> InboxItems = new List<MailMessage>()
    {
        new MailMessage()
        {
            Id = 1,
            From = "123@qq.com",
            To = new ObservableCollection<string>(){ "ab@qq.com", "cd@qq.com" },
            Subject = "测试邮件1",
            Body = "测试邮件内容1",
            DateSent = DateTime.Now,
        },
        new MailMessage()
        {
            Id = 2,
            From = "1232@qq.com",
            To = new ObservableCollection<string>(){ "ab2@qq.com", "cd2@qq.com" },
            Subject = "测试邮件2",
            Body = "测试邮件内容2",
            DateSent = DateTime.Now.AddDays(-1),
        },
        new MailMessage()
        {
            Id = 3,
            From = "1233@qq.com",
            To = new ObservableCollection<string>(){ "ab3@qq.com", "cd3@qq.com" },
            Subject = "测试邮件3",
            Body = "测试邮件内容3",
            DateSent = DateTime.Now.AddDays(-3),
        },

    };

    private static List<MailMessage> SendItems = new List<MailMessage>();

    private static List<MailMessage> DeletedItems = new List<MailMessage>();

    public IList<MailMessage> GetDeletedItems()
    {
        return DeletedItems;
    }

    public IList<MailMessage> GetInboxItems()
    {
        return InboxItems;
    }

    public IList<MailMessage> GetSentItems()
    {
        return SendItems;
    }
}
