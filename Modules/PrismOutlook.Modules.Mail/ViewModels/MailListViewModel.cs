﻿using Prism.Regions;
using PrismOutlook.Business;
using PrismOutlook.Core;
using PrismOutlook.Services.Interfaces;
using System.Collections.ObjectModel;

namespace PrismOutlook.Modules.Mail.ViewModels;

public class MailListViewModel : ViewModelBase
{
    private readonly IMailService _mailService;

    private ObservableCollection<MailMessage> _messages;

    public ObservableCollection<MailMessage> Messages
    {
        get { return _messages; }
        set { SetProperty(ref _messages, value); }
    }

    private MailMessage _selectedMessage;
    public MailMessage SelectedMessage
    {
        get { return _selectedMessage; }
        set { SetProperty(ref _selectedMessage, value); }
    }

    public MailListViewModel(IMailService mailService)
    {
        _mailService = mailService;
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        var folder = navigationContext.Parameters.GetValue<string>(FolderNames.FolderKey);

        switch (folder)
        {
            case FolderNames.Inbox:
                {
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetInboxItems());
                    break;
                }
            case FolderNames.Sent:
                {
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetSentItems());
                    break;

                }
            case FolderNames.Deleted:
                {
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetDeletedItems());
                    break;
                }
            default:
                break;
        }
    }
}
