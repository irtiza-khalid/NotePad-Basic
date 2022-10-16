using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NotePad_Basic
{
    public partial class Form1 : Form
    {
        bool click = false;
        OpenFileDialog open = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();
        public string contents = string.Empty;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Untitled";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
                }
        

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState=FormWindowState.Minimized;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (richTextBox1.Text != contents)
            {
                DialogResult dr = MessageBox.Show("Do You want to save the changes made to " + this.Text, "Save", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    sfd.Title = "Save";
                    if (SaveFile() == 0)
                        return;
                    else
                    {
                        richTextBox1.Text = "";
                        this.Text = "Untitled";
                    }
                    contents = "";
                }
                else if (dr == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    this.Text = "Untitled";
                    contents = "";
                }
                else
                {
                    richTextBox1.Focus();
                }
            }
            else
            {
                this.Text = "Untitled";
                richTextBox1.Text = "";
                contents = "";
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text=File.ReadAllText(open.FileName);  
            }
            
        }
        private int SaveFile()
        {
            sfd.Filter = "Text Documents|*.txt";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                richTextBox1.Focus();
                return 0;
            }
            else
            {
                contents = richTextBox1.Text;
                if (this.Text == "Untitled")
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                else
                {
                    sfd.FileName = this.Text;
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                }
                this.Text = sfd.FileName;
                return 1;
            }
        }


            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {




            sfd.Filter = "Text Documents|*.txt";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                richTextBox1.Focus();
            }
            else
            {
                contents = richTextBox1.Text;
                richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);

                this.Text = sfd.FileName;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color =new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            { 
                richTextBox1.ForeColor=color.Color;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad Basic by irtiza khalid ", "Notepad Basic", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click = true;
            change();
        }
        private void change()
        {
            if (click == true)
            {
                FontDialog fd = new FontDialog();

                fd.ShowColor = true;//Show color option in font dialog
                if (fd.ShowDialog() == DialogResult.OK)
                {

                    //----------------------> How to affect only selected contents
                   richTextBox1.ForeColor = fd.Color;
                    richTextBox1.Font = fd.Font;

                }//end if
            }
        }

        private void richTextBox1_MouseHover(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "Please Enter Some Text";
            toolStripStatusLabel2.Text = "";


        }

       private void richTextBox1_MouseLeave(object sender, EventArgs e)
       {
            toolStripStatusLabel1.Text = "Bring the cursor on the notepad";
            toolStripStatusLabel2.Text = "";
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Bring the cursor on the notepad";
            toolStripStatusLabel2.Text = "";
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "MENU BAR";
            toolStripStatusLabel2.Text = "";
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void richTextBox1_SizeChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "your layout size changed";
            toolStripStatusLabel2.Text = "";
        }

        private void fileToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = "FILE";
        }

        private void editToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void editToolStripMenuItem_MouseMove_1(object sender, MouseEventArgs e)
        {
            
                toolStripStatusLabel2.Text = "EDITS";
            
        }

        private void toolsToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = "TOOLS";
        }

        private void helpToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = "HELPS";
        }

        private void datetimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           richTextBox1.Text = DateTime.Now.ToString();
        }

        private void countWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           string i= richTextBox1.Text.Length.ToString();
            MessageBox.Show("TOTAL WORDS IN NOTES "+i, "Notepad Basic", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
