using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for Message_input.xaml
    /// </summary>
    public partial class Message_input : Window
    {

        public Message_input()
        {
            InitializeComponent();
        }

        Sender s = new Sender();

        bool emailCheck(string emailtest)
        {
            if (txtSender.Text.Length > 0)
            {
                try
                {

                    MailAddress testEmail = new MailAddress(emailtest);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
                    
        }

        private void txtSender_TextChanged(object sender, TextChangedEventArgs e)
        {

            s.Tweet = false;
            s.Sms = false;
            s.Email = false;

              if (txtSender.Text.Length > 0 && txtSender.Text[0] == '@')
            {
                s.Tweet = true;
                MessageBox.Show("This is a tweet");
            }

            if (emailCheck(txtSender.Text))
            {
                s.Email = true;
                MessageBox.Show("This is an email");
            }


            Regex phoneCheck = new Regex(@"\+\d{11,15}");
            if (phoneCheck.IsMatch(txtSender.Text))
            {              
                s.Sms = true;
                MessageBox.Show("This is a sms");
            }
        }
    }
}
