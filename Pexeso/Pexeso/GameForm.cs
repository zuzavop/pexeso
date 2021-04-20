using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class GameForm : Form
    {

        public enum State { None, One, Two, End };
        private Start parent;

        public GameForm(Start parent)
        {
            InitializeComponent();

            InitButtons();
            InitValues();

            this.parent = parent;
        }

        private State state = State.None;
        List<Button> buttons = new List<Button>();
        List<int> values = new List<int>();
        int[] index_predchozi = new int[2];
        List<string> ikonky = new List<string>() { "coffee.png", "balonek.png", "kaktus.png", "kytka.png", "mrak.png", "raketka.png", "slunicko.png", "srdce.png" };
        int pocitadlo = 0;

        private void InitValues()
        {
            List<int> pomocna = new List<int>();
            for (int i = 0; i < buttons.Count; i++)
            {
                pomocna.Add(i / 2);
            }
            Random rnd = new Random();
            for (int x=pomocna.Count; x>0; x--)
            {
                int random_number = rnd.Next(pomocna.Count);
                values.Add(pomocna[random_number]);
                pomocna.RemoveAt(random_number);
            }
        }

        private void InitButtons()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            pocitadlo = buttons.Count / 2;
        }

        private void BackToParent()
        {
            parent.Show();
            Close();
        }

        private void ImageShow(int buttonIndex)
        {
            Image image = Image.FromFile("../../res/" + ikonky[values[buttonIndex]]);
            buttons[buttonIndex].BackgroundImage = image;
            buttons[buttonIndex].BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ButtonClick(int buttonIndex)
        {
            switch (state)
            {
                case State.None:
                    ImageShow(buttonIndex);
                    index_predchozi[0] = buttonIndex;
                    state = State.One;
                    break;
                case State.One:
                    if (index_predchozi[0] != buttonIndex)
                    {
                        ImageShow(buttonIndex);
                        index_predchozi[1] = buttonIndex;
                        state = State.Two;
                    }
                    break;
                case State.Two:
                    if (values[index_predchozi[0]] == values[index_predchozi[1]])
                    {
                        RemoveButton(index_predchozi[0]);
                        RemoveButton(index_predchozi[1]);
                        if (--pocitadlo == 0)
                        {
                            konec_label.Text = "Konec hry";
                        }
                    }
                    else
                    {
                        buttons[index_predchozi[0]].BackgroundImage = null;
                        buttons[index_predchozi[1]].BackgroundImage = null;
                    }
                    state = State.None;
                    break;
                case State.End:
                    konec_label.Text = "";
                    BackToParent();
                    break;
                default:
                    break;
            }
        }

        private void RemoveButton(int index)
        {
            buttons[index].Enabled = false;
            buttons[index].Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClick(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClick(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClick(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonClick(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonClick(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonClick(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonClick(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonClick(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonClick(9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ButtonClick(10);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ButtonClick(11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ButtonClick(12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ButtonClick(13);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ButtonClick(14);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ButtonClick(15);
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            if (state == State.Two)
            {
                ButtonClick(0);
            } else if (konec_label.Text != "")
            {
                state = State.End;
                ButtonClick(0);
            }
        }

        private void konec_label_Click(object sender, EventArgs e)
        {
            if (konec_label.Text != "")
            {
                state = State.End;
                ButtonClick(0);
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }
    }
}
