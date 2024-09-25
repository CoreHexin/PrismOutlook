using Infragistics.Windows.Ribbon;
using PrismOutlook.Core;

namespace PrismOutlook.Modules.Mail.Menus
{
    /// <summary>
    /// HomeTab.xaml 的交互逻辑
    /// </summary>
    public partial class HomeTab : RibbonTabItem, ISupportDataContext
    {
        public HomeTab()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RibbonTabItem));
        }
    }
}
