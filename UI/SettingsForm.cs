/**
 * Copyright 2006-2018 Gustavo Augusto Hennig
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **/
using SimpleDatabaseReplicator.Properties;
using SimpleDatabaseReplicator.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.AddRange(new string[] { "en", "pt" });
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the current culture based on the selected language
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();
            Settings.Default.Culture = selectedLanguage;
            Settings.Save();

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(selectedLanguage);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            // Update the UI with the new culture
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SettingsForm));
            resources.ApplyResources(this, "$this");
            ApplyResourceToControls(resources, this.Controls);

        }

        private void ApplyResourceToControls(ComponentResourceManager resources, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                resources.ApplyResources(control, control.Name);
                if (control.Controls.Count > 0)
                {
                    ApplyResourceToControls(resources, control.Controls);
                }
            }
        }
    }
}
