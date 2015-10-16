using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NuGet.VisualStudio;

namespace NuGet.PackageManagement.UI
{
    /// <summary>
    /// Interaction logic for PackageManagerProvidersLabel.xaml. Its DataContext is 
    /// PackageItemListViewModel.
    /// </summary>
    public partial class PackageManagerProvidersLabel : UserControl
    {
        public PackageManagerProvidersLabel()
        {
            InitializeComponent();

            this.DataContextChanged += PackageManagerProvidersLabel_DataContextChanged;
        }

        private void PackageManagerProvidersLabel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // !!! Generate 
            _textBlock.Inlines.Clear();

            var providers = DataContext as OtherPackageManagerProviders;
            if (providers == null || providers.PackageManagerProviders.IsEmpty())
            {
                return;
            }

            _textBlock.Inlines.Add(new Run("["));
            _textBlock.Inlines.Add(new Run(NuGet.PackageManagement.UI.Resources.Label_ConsiderUsing));

            bool firstElement = true;

            foreach (var provider in providers.PackageManagerProviders)
            {
                if (firstElement)
                {
                    firstElement = false;
                }
                else
                {
                    _textBlock.Inlines.Add(new Run(", "));
                }

                var hyperLink = new Hyperlink(new Run(provider.PackageManagerName));
                hyperLink.ToolTip = provider.Description;
                hyperLink.Click += (_, __) =>
                {
                    provider.GoToPackage(providers.PackageId, providers.ProjectName);
                };
                _textBlock.Inlines.Add(hyperLink);       
            }

            _textBlock.Inlines.Add(new Run("]"));
        }
    }
}
