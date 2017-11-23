using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;


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
            if (string.IsNullOrEmpty(txtSender.Text) || (string.IsNullOrEmpty(txtMessage.Text)))
            {
                MessageBox.Show("Sender and message box cannot be empty");
            }

            else
            {
                Random generate_ID = new Random();
                if (lblMessageType.Content == "Tweet")
                {
                    int Rand_ID = generate_ID.Next(000000000, 999999999);
                    lblMessageID.Content = "T" + Rand_ID;
                }

                else if (lblMessageType.Content == "SMS")
                {
                    int Rand_ID = generate_ID.Next(000000000, 999999999);
                    lblMessageID.Content = "S" + Rand_ID;
                }

                else if (lblMessageType.Content == "Email")
                {
                    int Rand_ID = generate_ID.Next(000000000, 999999999);
                    lblMessageID.Content = "E" + Rand_ID;
                }

                Sender json = new Sender()
                {
                    Message_type = Convert.ToString(lblMessageType.Content),
                    Message_ID = Convert.ToString(lblMessageID.Content),
                    Sender = txtSender.Text,
                    Subject = txtSubject.Text,
                    Message = txtMessage.Text
                };

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + json.Message_ID + ".txt", JsonConvert.SerializeObject(json));

                using (StreamWriter file = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + @"\" + json.Message_ID + ".txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, json);
                }

                List<string> mentions = new List<string>();

                if (lblMessageType.Content == "Tweet")
                {
                    string[] stringArray = txtMessage.Text.Split(' ');
                    foreach (string s in stringArray)
                    {
                        if (s[0] == '@')
                        {
                            mentions.Add(s);
                        }
                    }
                }

                List<string> hashtag = new List<string>();

                if (lblMessageType.Content == "Tweet")
                {
                    string[] stringArray1 = txtMessage.Text.Split(' ');
                    foreach (string s1 in stringArray1)
                    {
                        if (s1[0] == '#')
                        {
                            hashtag.Add(s1);
                        }
                    }
                }

                MainWindow main_window = new MainWindow();
                string MentionsArray = string.Join(",", mentions.ToArray());
                string HashtagArray = string.Join(",", hashtag.ToArray());
                main_window.lstMessages.Items.Add("Message ID: " + Convert.ToString(lblMessageID.Content) + "\n" + "Sender: " + txtSender.Text + "\n" + "Subject: " + txtSubject.Text + "\n" + "Message: " + txtMessage.Text + "\n" + "Mention: " + MentionsArray + "\n" + "Hashtag: " + HashtagArray);
                main_window.Show();


            }

            
            

        }

        private void txtSender_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblMessageType.Content == "Tweet")
            {
                txtMessage.MaxLength = 140;
            }

            s.Tweet = false;
            s.Sms = false;
            s.Email = false;

            if (txtSender.Text.Length > 0 && txtSender.Text[0] == '@')
            {
                s.Tweet = true;
                lblMessageType.Content = "Tweet";
            }

            if (emailCheck(txtSender.Text))
            {
                s.Email = true;
                lblMessageType.Content = "Email";
            }


            Regex phoneCheck = new Regex(@"\+\d{11,15}");
            if (phoneCheck.IsMatch(txtSender.Text))
            {
                s.Sms = true;
                lblMessageType.Content = "SMS";
            }

            if (lblMessageType.Content == "Email")
            {
                txtSubject.IsEnabled = true;
            }

            if (lblMessageType.Content == "Tweet")
            {
                txtSubject.IsEnabled = false;
            }

            if (lblMessageType.Content == "SMS")
            {
                txtSubject.IsEnabled = false;
            }

            
        }

        private void txtSubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtSubject.MaxLength = 20;
        }

        private void txtMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblMessageType.Content == "Tweet")
            {
                txtMessage.MaxLength = 140;
            }

            if (lblMessageType.Content == "Email")
            {
                txtMessage.MaxLength = 1028;
            }

            if (lblMessageType.Content == "SMS")
            {
                txtMessage.MaxLength = 140;
            }
        }

    }
}


