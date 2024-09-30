using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class Form1 : Form
{
    private TextBox textBox1;
    private TextBox textBox2;

    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        //
        // textBox1
        //
        this.textBox1.AcceptsReturn = true;
        this.textBox1.AcceptsTab = true;
        this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBox1.Multiline = true;
        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBox1.KeyPress += textBox1_KeyPress;
        textBox1.KeyUp += textBox1_KeyUp;
        //
        // Form1
        //

        this.ClientSize = new System.Drawing.Size(284, 264);
        this.Controls.Add(this.textBox1);
        this.Text = "TextBox Example";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    int space = 0;
    int split = 0;

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Char.IsLetter(e.KeyChar) || (e.KeyChar == ' ') || (e.KeyChar == '-'))
        {
            if (textBox1.SelectionStart == 0)
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                }
                else
                {
                    e.Handled = true;
                }
                return;
            }
            ;
        }
        if (space == 0)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToLower(e.KeyChar);
                return;
            }
            else if (e.KeyChar == '-')
            {
                if (split == 0)
                {
                    split = 1;
                }
                else
                {
                    e.Handled = true;
                }
                return;
            }
            else if (e.KeyChar == ' ')
            {
                space++;
                return;
            }
            e.Handled = true;
            return;
        }
        if (space == 1 || space == 2)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
                space++;
            }
            else
            {
                e.Handled = true;
            }
            return;
        }
        e.Handled = true;
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (space == 2)
        {
            textBox1.AppendText(".");
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }
        if (space == 3)
        {
            textBox1.AppendText(".");
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
            space = 0;
            split = 0;
        }
        ;
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
