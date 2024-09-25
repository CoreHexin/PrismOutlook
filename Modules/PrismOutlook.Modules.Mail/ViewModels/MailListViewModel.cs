﻿using Prism.Commands;
using Prism.Regions;
using PrismOutlook.Core;
using System.Windows;

namespace PrismOutlook.Modules.Mail.ViewModels;

public class MailListViewModel : ViewModelBase
{
    private string _title = "Mail List View";
    public string Title
    {
        get { return _title; }
        set { SetProperty(ref _title, value); }
    }

    public MailListViewModel()
    {

    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        Title = navigationContext.Parameters.GetValue<string>("id");
    }
}
