using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            CheckPassword();
            this.password.TextChanged += Password_TextChanged;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPassword();
        }

        [ArmDot.Client.VirtualizeCode]
        private void CheckPassword()
        {
            this.passwordStatus.Text = "Checking...";

            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(this.password.Text));
                bool correct = Convert.ToBase64String(hash).Equals("mZfua8BSQJP337Kuj4Cpl9dVBL/S6Cn1SioM0xcq2tg=");
                this.passwordStatus.Text = string.Format($"The password \"{this.password.Text}\" is {(correct ? "correct" : "incorrect")}");
            }
        }
    }
}
