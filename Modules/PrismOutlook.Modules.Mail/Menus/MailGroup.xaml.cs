using Infragistics.Windows.OutlookBar;
using PrismOutlook.Business;
using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.ViewModels;
using System.Linq;

namespace PrismOutlook.Modules.Mail.Menus
{
    /// <summary>
    /// MailGroup.xaml 的交互逻辑
    /// </summary>
    public partial class MailGroup : OutlookBarGroup, IOutlookBarGroup
    {
        public MailGroup()
        {
            InitializeComponent();
            dataTree.Loaded += DataTree_Loaded;
        }

        private void DataTree_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dataTree.Nodes[0].Nodes[0].IsSelected = true;
            dataTree.Loaded -= DataTree_Loaded;
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = dataTree.SelectedDataItems?.FirstOrDefault() as NavigationItem;
                if (item != null)
                    return item.NavigationPath;

                return $"MailList?{FolderNames.FolderKey}={FolderNames.Inbox}";
            }
        }
    }
}
