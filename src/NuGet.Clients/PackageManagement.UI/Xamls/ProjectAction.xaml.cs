﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace NuGet.PackageManagement.UI
{
    /// <summary>
    /// Interaction logic for ProjectAction.xaml
    /// </summary>
    public partial class ProjectAction : UserControl
    {
        public ProjectAction()
        {
            InitializeComponent();

            // Change ItemContainerStyle of the _versions combobox so that
            // for a null value, a separator is generated.
            var dataTrigger = new DataTrigger();
            dataTrigger.Binding = new Binding();
            dataTrigger.Value = null;
            dataTrigger.Setters.Add(new Setter(TemplateProperty, FindResource("SeparatorControlTemplate")));

            // make sure the separator can't be selected thru keyboard navigation.
            dataTrigger.Setters.Add(new Setter(IsEnabledProperty, false));

            var style = new Style(typeof(ComboBoxItem), _versions.ItemContainerStyle);
            style.Triggers.Add(dataTrigger);
            _versions.ItemContainerStyle = style;
        }

        private void UninstallButton_Clicked(object sender, RoutedEventArgs e)
        {
        }

        private void UpgradeButton_Clicked(object sender, RoutedEventArgs e)
        {
        }
    }
}