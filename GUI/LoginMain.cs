using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCD_LAB_PROJ
{
    public partial class LoginMain : Form
    {
        private const string PlaceholderText = "Enter username";
        private const string PlaceholderText2 = "Password";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalColor = Color.Black;

        public LoginMain()
        {
            InitializeComponent();
            SetPlaceholders();

            // Attach event handlers for both textboxes
            textBox1.GotFocus += TextBox1_GotFocus;
            textBox1.LostFocus += TextBox1_LostFocus;
            textBox2.GotFocus += TextBox2_GotFocus;
            textBox2.LostFocus += TextBox2_LostFocus;
            textBox2.TextChanged += TextBox2_TextChanged;

            // Attach event handler for checkbox
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }

        private void SetPlaceholders()
        {
            // Username placeholder
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = PlaceholderText;
                textBox1.ForeColor = PlaceholderColor;
            }

            // Password placeholder
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false; // Show placeholder text
                textBox2.Text = PlaceholderText2;
                textBox2.ForeColor = PlaceholderColor;
            }
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == PlaceholderText)
            {
                textBox1.Text = "";
                textBox1.ForeColor = NormalColor;
            }
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = PlaceholderText;
                textBox1.ForeColor = PlaceholderColor;
            }
        }

        private void TextBox2_GotFocus(object sender, EventArgs e)
        {
            if (textBox2.Text == PlaceholderText2)
            {
                textBox2.Text = "";
                textBox2.ForeColor = NormalColor;
                textBox2.UseSystemPasswordChar = !checkBox1.Checked; // Mask if not showing password
            }
        }

        private void TextBox2_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false; // Show placeholder
                textBox2.Text = PlaceholderText2;
                textBox2.ForeColor = PlaceholderColor;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            // If not showing placeholder, ensure color is black
            if (textBox2.Text != PlaceholderText2)
            {
                textBox2.ForeColor = NormalColor;
                // Ensure password masking is correct when typing
                textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Only change masking if not showing placeholder
            if (textBox2.Text != PlaceholderText2)
            {
                textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "admin")
            {
                Form adminMainForm = new AdminMain(); // Correctly instantiate the AdminMain form  
                adminMainForm.Show(); // Display the AdminMain form  
            }
            else
            {
                MessageBox.Show($"Username is: {textBox1.Text}\nPassword is: " + textBox2.Text, "Password Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
