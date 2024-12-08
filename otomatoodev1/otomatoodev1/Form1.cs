using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomatoodev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool harfleruygunmu = true;
            string[] harfler = textBox1.Text.Split(',');
            string islem = textBox2.Text;
            int uretilecekSayi = Convert.ToInt32(textBox3.Text);
            Random random = new Random();

            for (int i = 0; i < islem.Length; i++)
            {
                if (islem[i] != '+' && islem[i] != '*' && islem[i] != '(' && islem[i] != ')')
                {
                    if (!Array.Exists(harfler, harf => harf == islem[i].ToString()))
                    {
                        harfleruygunmu = false;
                    }

                }
            }

            if (harfleruygunmu)
            {

                listBox1.Items.Clear();
                for (int i = 0; i < uretilecekSayi; i++)
                {
                    listBox1.Items.Add(Kelimeuret(islem, harfler, random));
                }
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Harfler ve işlem uyuşmuyor");
            }
        }
        public static string Kelimeuret(string islem, string[] harfler, Random random)
        {

            string uretlien = "";
            bool parantezici = false;
            string parantezislem = "";

            for (int i = 0; i < islem.Length; i++)
            {
                Console.WriteLine(islem[i]);
                if (islem[i] == '*')
                {
                    continue;
                }
                else if (islem[i] == '(')
                {
                    parantezici = true;
                    continue;
                }
                else if (parantezici)
                {

                    if (islem[i] == ')')
                    {
                        parantezici = false;
                        if (parantezislem.Contains("+"))
                        {
                            string[] parantezislemler = parantezislem.Split('+');

                            if (islem[i + 1] == '*')
                            {
                                int rnd = random.Next(1, 6);
                                for (int j = 0; j < rnd; j++)
                                {
                                    int a = random.Next(1, 3);
                                    if (a == 1)
                                    {
                                        uretlien += parantezislemler[0];
                                    }
                                    else if (a == 2)
                                    {
                                        uretlien += parantezislemler[1];
                                    }
                                }
                            }
                            else
                            {
                                int a = random.Next(1, 3);
                                if (a == 1)
                                {
                                    uretlien += parantezislemler[0];
                                }
                                else if (a == 2)
                                {
                                    uretlien += parantezislemler[1];
                                }
                            }

                        }
                        else
                        {
                            if (islem[i + 1] == '*')
                            {
                                int rand = random.Next(1, 6);
                                for (int j = 0; j < rand; j++)
                                {
                                    uretlien += parantezislem;
                                }
                            }
                            else
                            {
                                uretlien += parantezislem;
                            }
                        }
                    }
                    parantezislem += islem[i];
                }
                else if (Array.Exists(harfler, item => item == islem[i].ToString()) & !parantezici)
                {
                    if (islem.Length - 1 != i)
                    {
                        if (islem[i + 1] == '*')
                        {
                            int rand = random.Next(1, 6);

                            for (int j = 0; j < rand; j++)
                            {
                                uretlien += islem[i].ToString();
                            }
                        }
                        else
                        {
                            uretlien += islem[i];
                        }
                    }
                    else
                    {
                        uretlien += islem[i];
                    }

                }
            }

            return uretlien;
        }
    }
}
