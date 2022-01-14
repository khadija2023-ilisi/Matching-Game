using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        Random random = new Random();
        /// <space>
        /// 
        /// </space>
        Label firstClicked = null;
        Label secondClicked = null;
        /// <space>
        /// 
        /// </space>
        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>()
        {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
        };
        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {
            Label click = sender as Label;
            if (timer1.Enabled == true)
                return;
            if (click != null)
            {
                if (click.ForeColor == Color.Black)
                {
                    return;
                }
                if(firstClicked== null)
                {
                    firstClicked = click;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                //click.ForeColor = Color.Black;
                secondClicked = click;
                secondClicked.ForeColor = Color.Black;
                winner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
        timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }
        private void winner()
        {
            foreach(Control c in this.tableLayoutPanel1.Controls){
                Label l = c as Label;
                if (l != null)
                {
                    if (l.ForeColor == l.BackColor) return;
                }
            }
            MessageBox.Show("Brovo vous avez faire correspondre à toute image ;)");
            Close();
        }
    }
}
