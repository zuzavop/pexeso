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

    public partial class Start : Form
    {
        private GameForm gameForm;
        public Start()
        {
            InitializeComponent();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            gameForm = new GameForm(this);
            gameForm.Show();
            Hide();
        }

        private void Start_Resize(object sender, EventArgs e)
        {
            int size = tableLayoutPanel1.Size.Width / 11;
            title.Font = new Font("Harlow Solid Italic", size, FontStyle.Italic);
        }
    }


}
