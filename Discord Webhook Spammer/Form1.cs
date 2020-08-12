using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace Discord_Webhook_Spammer
{
    public partial class Form1 : Form
    {
        string textColorStart;
        string textColorEnd = "```";
        string mentionEveryone;
        private Thread StartSpam = null;
        private Thread StartSpam2 = null;
        private Thread StartSpam3 = null;
        private Thread StartSpam4 = null;
        private Thread ShowHelpMessageThread = null;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public static void sendWebHook(string URL, string msg, string username)
        {
            Http.Post(URL, new NameValueCollection()
            {
                { "username", username },
                { "content", msg }
            });
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Make sure all fields are filled out!");
                }
                else
                {
                    checkEveryone();
                    checkTextColor();
                    StartSpam = new Thread(new ThreadStart(SendMessage));
                    StartSpam2 = new Thread(new ThreadStart(SendMessage));
                    StartSpam3 = new Thread(new ThreadStart(SendMessage));
                    StartSpam4 = new Thread(new ThreadStart(SendMessage));

                    StartSpam.Start();
                    StartSpam2.Start();
                    StartSpam3.Start();
                    StartSpam4.Start();
                }


            }
            else
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0)
                {
                    MessageBox.Show("Make sure all fields are filled out!");
                }
                else
                {
                    checkEveryone();
                    checkTextColor();
                    StartSpam = new Thread(new ThreadStart(SendMessage));
                    StartSpam.Start();
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowHelpMessageThread = new Thread(new ThreadStart(ShowHelpMessage));
            ShowHelpMessageThread.Start();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void SendMessage()
        {
            int i = 0;

                trytosend:
                int spamAmount = Convert.ToInt32(textBox5.Text);
                while (i < spamAmount)
                {

                    try
                    {
                        sendWebHook(textBox1.Text, string.Concat(new string[] { mentionEveryone + textColorStart + textBox3.Text + textColorEnd, }), textBox2.Text);
                        i++;
                    }
                    catch (Exception)
                    {
                        goto trytosend;
                    }

                }



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkTextColor()
        {
            if (comboBox1.SelectedIndex == 1)
            {
                textColorStart = "```CSS\n"; //green
                textColorEnd = "```";
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                textColorStart = "```yaml\n"; //cyan
                textColorEnd = "```";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textColorStart = "```ini\n[ "; //blue
                textColorEnd = "```";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textColorStart = "```fix\n% "; //yellow
                textColorEnd = "```";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                textColorStart = "```diff\n- "; //red
                textColorEnd = "```";
            }
            else
            {
                textColorStart = "";
                textColorEnd = "";
            }
        }

        private void checkEveryone()
        {
            if (checkBox1.Checked)
            {
                mentionEveryone = "@everyone ";
                return;
            }
        }

        private void goFaster()
        {

        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                goFaster();
            }
            else
            {
                return;
            }
        }

        private static void ShowHelpMessage()
        {
            MessageBox.Show("This uses multible threads to send messages a lot quicker and sends 4x the amount of messages you chose...\nRemember that discord only allows 30 messages per 60 seconds");
        }
    }
}
