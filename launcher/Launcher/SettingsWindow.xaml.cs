using System.IO;
using System.Windows;
using System.Windows.Input;
using BSU.Utils.Data;
using WowSuite.Launcher.Config;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WowSuite.Launcher
{
    public partial class SettingsWindow : Window
    {
        string wow_dictory = "";
        public SettingsWindow()
        {
            InitializeComponent();

            //SetResultText(string.Empty);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void closeButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //private void SetResultText(string text)
        //{
        //    result.Text = text;
        //}

        private void BrowserPathButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wow_dictory = dialog.SelectedPath;
                wowPath.Text = wow_dictory;
                LocalConfiguration.Instance.wowGameDictory = wow_dictory;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            
            Microsoft.Win32.RegistryKey registryKey;
            // HKCU\Software\RegeditStorage
            registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\RegistryStorage"); 
            registryKey.SetValue("WOWDictory", LocalConfiguration.Instance.wowGameDictory.ToString());
            registryKey.Close();

            Close();
            //try
            //{
            //    var authData = new AuthData(textBoxLogin.Text, textBoxPassword.Text);
            //    DataSerializer<AuthData>.SaveObject(authData, LocalConfiguration.Instance.Files.AuthDataFile);

            //    SetResultText("Data saved successfully!");
            //}
            //catch
            //{
            //    MessageBox.Show(this, "Error saving data. Refer to the technical support of the project.",
            //        "AutoLogin");
            //}
        }

        private void TextBoxes_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //if (result.Text.Length > 0)
            //{
            //    result.Text = string.Empty;
            //}
        }

        private void LoadData()
        {
            wowPath.Text = LocalConfiguration.Instance.wowGameDictory;
            //if (File.Exists(LocalConfiguration.Instance.Files.AuthDataFile))
            //{
            //    var authData = DataSerializer<AuthData>.LoadObject(LocalConfiguration.Instance.Files.AuthDataFile);
            //    textBoxLogin.Text = authData.Login;
            //    textBoxPassword.Text = authData.Password;
            //}
        }
    }
}