using Infragistics.Windows.OutlookBar;
using PrismOutlook.Business;
using PrismOutlook.Core;
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
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = dataTree.SelectedDataItems?.FirstOrDefault() as NavigationItem;
                if (item != null)
                    return item.NavigationPath;

                return "MailList?id=Default";
            }
        }
    }
}
