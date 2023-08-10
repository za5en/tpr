using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpr
{
    public partial class Form1 : Form
    {
        int difference = 0;
        int diff1 = -999, diff2 = -999, diff3 = -999;
        double firstP1 = 1, firstP2 = 1, secondP1 = 1, secondP2 = 1, elastic = 0, chpdval1 = 1, chpdval2 = 1;

        string[] valDiff = new string[3];

        public Form1()
        {
            InitializeComponent();
            compare1.Items.Add("++");
            compare1.Items.Add("+");
            compare1.Items.Add("0");
            compare1.Items.Add("-");
            compare1.Items.Add("--");

            compare2.Items.Add("++");
            compare2.Items.Add("+");
            compare2.Items.Add("0");
            compare2.Items.Add("-");
            compare2.Items.Add("--");

            compare3.Items.Add("++");
            compare3.Items.Add("+");
            compare3.Items.Add("0");
            compare3.Items.Add("-");
            compare3.Items.Add("--");

            for (int i = 0; i < valDiff.Length; i++)
            {
                valDiff[i] = "";
            }
        }
        private void compare1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compareValue = compare1.SelectedItem.ToString();
            if (compareValue == "++")
            {
                diff1 = 2;
                valDiff[0] = "по критерию " + compareName1.Text + " " + productName2.Text + " значительно лучше, чем " + productName1.Text;
            }
            else if (compareValue == "+")
            {
                diff1 = 1;
                valDiff[0] = "по критерию " + compareName1.Text + " " + productName2.Text + " немного лучше, чем " + productName1.Text;
            }
            else if (compareValue == "0")
            {
                diff1 = 0;
                valDiff[0] = "по критерию " + compareName1.Text + " " + productName1.Text + " и " + productName2.Text + " примерно равны";
            }
            else if (compareValue == "-")
            {
                diff1 = -1;
                valDiff[0] = "по критерию " + compareName1.Text + " " + productName2.Text + " немного хуже, чем " + productName1.Text;
            }
            else if (compareValue == "--")
            {
                diff1 = -2;
                valDiff[0] = "по критерию " + compareName1.Text + " " + productName2.Text + " значительно хуже, чем " + productName1.Text;
            }
        }

        private void compare2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compareValue = compare2.SelectedItem.ToString();
            if (compareValue == "++")
            {
                diff2 = 2;
                valDiff[1] = "по критерию " + compareName2.Text + " " + productName2.Text + " значительно лучше, чем " + productName1.Text;
            }
            else if (compareValue == "+")
            {
                diff2 = 1;
                valDiff[1] = "по критерию " + compareName2.Text + " " + productName2.Text + " немного лучше, чем " + productName1.Text;
            }
            else if (compareValue == "0")
            {
                diff2 = 0;
                valDiff[1] = "по критерию " + compareName2.Text + " " + productName1.Text + " и " + productName2.Text + " примерно равны";
            }
            else if (compareValue == "-")
            {
                diff2 = -1;
                valDiff[1] = "по критерию " + compareName2.Text + " " + productName2.Text + " немного хуже, чем " + productName1.Text;
            }
            else if (compareValue == "--")
            {
                diff2 = -2;
                valDiff[1] = "по критерию " + compareName2.Text + " " + productName2.Text + " значительно хуже, чем " + productName1.Text;
            }
        }

        private void compare3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compareValue = compare3.SelectedItem.ToString();
            if (compareValue == "++")
            {
                diff3 = 2;
                valDiff[2] = "по критерию " + compareName3.Text + " " + productName2.Text + " значительно лучше, чем " + productName1.Text;
            }
            else if (compareValue == "+")
            {
                diff3 = 1;
                valDiff[2] = "по критерию " + compareName3.Text + " " + productName2.Text + " немного лучше, чем " + productName1.Text;
            }
            else if (compareValue == "0")
            {
                diff3 = 0;
                valDiff[2] = "по критерию " + compareName3.Text + " " + productName1.Text + " и " + productName2.Text + " примерно равны";
            }
            else if (compareValue == "-")
            {
                diff3 = -1;
                valDiff[2] = "по критерию " + compareName3.Text + " " + productName2.Text + " немного хуже, чем " + productName1.Text;
            }
            else if (compareValue == "--")
            {
                diff3 = -2;
                valDiff[2] = "по критерию " + compareName3.Text + " " + productName2.Text + " значительно хуже, чем " + productName1.Text;
            }
        }

        private void productName2_TextChanged(object sender, EventArgs e)
        {
            product2.Text = String.Format(productName2.Text);
        }

        private void paramName1_TextChanged(object sender, EventArgs e)
        {
            paramPlace1.Text = String.Format(paramName1.Text);
        }

        private void paramName2_TextChanged(object sender, EventArgs e)
        {
            paramPlace2.Text = String.Format(paramName2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productName2.TextChanged += this.productName2_TextChanged;
            paramName1.TextChanged += this.paramName1_TextChanged;
            paramName2.TextChanged += this.paramName2_TextChanged;
        }

        private void resultCold_Click(object sender, EventArgs e)
        {
            string resultDiff = "";
            foreach (string i in valDiff)
            {
                resultDiff += "\n";
                resultDiff += i;
            }

            if (productName1.Text != "" && productName2.Text != "")
            {
                if (compareName1.Text != "")
                {
                    if (compareName2.Text == "" && compareName3.Text == "")
                    {
                        if (diff1 != -999)
                        {
                            difference = diff1;
                            if (difference > 0)
                            {
                                MessageBox.Show(productName2.Text + " лучше чем " + productName1.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else if (difference < 0)
                            {
                                MessageBox.Show(productName1.Text + " лучше чем " + productName2.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else
                            {
                                MessageBox.Show(productName1.Text + " и " + productName2.Text + " примерно равны" + ":\n" + resultDiff, "результат сравнения");
                            }
                        }
                        else
                        {
                            MessageBox.Show("укажите оценку параметров для всех введенных наименований");
                        }
                    }
                    else if (compareName2.Text != "" && compareName3.Text == "")
                    {
                        if (diff1 != -999 && diff2 != -999)
                        {
                            difference = diff1 + diff2;
                            if (difference > 0)
                            {
                                MessageBox.Show(productName2.Text + " лучше чем " + productName1.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else if (difference < 0)
                            {
                                MessageBox.Show(productName1.Text + " лучше чем " + productName2.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else
                            {
                                MessageBox.Show(productName1.Text + " и " + productName2.Text + " примерно равны" + ":\n" + resultDiff, "результат сравнения");
                            }
                        }
                        else
                        {
                            MessageBox.Show("укажите оценку параметров для всех введенных наименований");
                        }
                    }
                    else if (compareName2.Text == "" && compareName3.Text != "")
                    {
                        if (diff1 != -999 && diff3 != -999)
                        {
                            difference = diff1 + diff3;
                            if (difference > 0)
                            {
                                MessageBox.Show(productName2.Text + " лучше чем " + productName1.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else if (difference < 0)
                            {
                                MessageBox.Show(productName1.Text + " лучше чем " + productName2.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else
                            {
                                MessageBox.Show(productName1.Text + " и " + productName2.Text + " примерно равны" + ":\n" + resultDiff, "результат сравнения");
                            }
                        }
                        else
                        {
                            MessageBox.Show("укажите оценку параметров для всех введенных наименований");
                        }
                    }
                    else if (compareName2.Text != "" && compareName3.Text != "")
                    {
                        if (diff1 != -999 && diff2 != -999 && diff3 != -999)
                        {
                            difference = diff1 + diff3;
                            if (difference > 0)
                            {
                                MessageBox.Show(productName2.Text + " лучше чем " + productName1.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else if (difference < 0)
                            {
                                MessageBox.Show(productName1.Text + " лучше чем " + productName2.Text + ":\n" + resultDiff, "результат сравнения");
                            }
                            else
                            {
                                MessageBox.Show(productName1.Text + " и " + productName2.Text + " примерно равны" + ":\n" + resultDiff, "результат сравнения");
                            }
                        }
                        else
                        {
                            MessageBox.Show("укажите оценку параметров для всех введенных наименований");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("заполните хотя бы одно поле наименований параметров");
                }
            }
            else
            {
                MessageBox.Show("заполните поля наименований товаров");
            }
        }

        private void resetCold_Click(object sender, EventArgs e)
        {
            productName1.Text = "";
            productName2.Text = "";
            compareName1.Text = "";
            compareName2.Text = "";
            compareName3.Text = "";
            compare1.Text = "";
            compare2.Text = "";
            compare3.Text = "";
            diff1 = -999;
            diff2 = -999;
            diff3 = -999;
        }

        private void resultWilson_Click(object sender, EventArgs e)
        {
            if (paramName1.Text != "")
            {
                if (chpd1.Text != "" && chpd2.Text != "")
                {
                    chpdval1 = double.Parse(chpd1.Text);
                    chpdval2 = double.Parse(chpd2.Text);
                    if (paramName2.Text != "")
                    {
                        if (secondParam1.Text != "" && secondParam2.Text != "")
                        {
                            secondP1 = double.Parse(secondParam1.Text);
                            secondP2 = double.Parse(secondParam2.Text);
                            if (paramName2.Text == "переменные издержки" || paramName2.Text == "постоянные издержки")
                            {
                                elastic = ((secondP2 - secondP1) / secondP1) / ((chpdval2 - chpdval1) / chpdval1);
                            }
                            else
                            {
                                elastic = ((chpdval2 - chpdval1) / chpdval1) / ((secondP2 - secondP1) / secondP1);
                            }
                            elastic2.Text = String.Format($"{elastic}");
                            if (elastic < 1)
                            {
                                influence2.Text = "очень слабое";
                            }
                            else if (elastic < 2.25)
                            {
                                influence2.Text = "слабое";
                            }
                            else if (elastic < 3.5)
                            {
                                influence2.Text = "не сильное, но и не слабое";
                            }
                            else if (elastic < 7.5)
                            {
                                influence2.Text = "сильное";
                            }
                            else
                            {
                                influence2.Text = "очень сильное";
                            }
                        }
                        else
                        {
                            MessageBox.Show("заполните поля значений параметров");
                        }
                    }
                    if (firstParam1.Text != "" && firstParam2.Text != "")
                    {
                        firstP1 = double.Parse(firstParam1.Text);
                        firstP2 = double.Parse(firstParam2.Text);
                        if (paramName1.Text == "переменные издержки" || paramName1.Text == "постоянные издержки")
                        {
                            elastic = ((firstP2 - firstP1) / firstP1) / ((chpdval2 - chpdval1) / chpdval1);
                        }
                        else
                        {
                            elastic = ((chpdval2 - chpdval1) / chpdval1) / ((firstP2 - firstP1) / firstP1);
                        }
                        elastic1.Text = String.Format($"{elastic}");
                        if (elastic < 1)
                        {
                            influence1.Text = "очень слабое";
                        }
                        else if (elastic < 2.25)
                        {
                            influence1.Text = "слабое";
                        }
                        else if (elastic < 3.5)
                        {
                            influence1.Text = "не сильное, но и не слабое";
                        }
                        else if (elastic < 7.5)
                        {
                            influence1.Text = "сильное";
                        }
                        else
                        {
                            influence1.Text = "очень сильное";
                        }
                    }
                    else
                    {
                        MessageBox.Show("заполните поля значений параметров");
                    }
                }
                else
                {
                    MessageBox.Show("заполните поля значений ЧПД");
                }
            }
            else
            {
                MessageBox.Show("заполните поле наименования параметра");
            }
        }

        private void resetWilson_Click(object sender, EventArgs e)
        {
            paramName1.Text = "";
            paramName2.Text = "";
            firstParam1.Text = "";
            firstParam2.Text = "";
            secondParam1.Text = "";
            secondParam2.Text = "";
            elastic1.Text = "";
            elastic2.Text = "";
            influence1.Text = "";
            influence2.Text = "";
            chpd1.Text = "";
            chpd2.Text = "";
            elastic = 0;
            firstP1 = 1;
            firstP2 = 1;
            secondP1 = 1;
            secondP2 = 1;
            chpdval1 = 1;
            chpdval2 = 1;
        }
    }
}
