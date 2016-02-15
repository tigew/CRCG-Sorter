using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CRCGSorter
{
    public partial class Form1 : Form
    {

        List<string> namesMaster = new List<string>(); 


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// opens a saved list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                DefaultExt = ".txt"
            };


            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                var openname = openFileDialog.FileName;
                textBox.Text = File.OpenText(openname).ReadToEnd();
            }
            catch (Exception)
            {
                Console.WriteLine(@"Error");
            }
        }

        /// <summary>
        /// Save Function for main textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBox.Contains(null))
            {
            }

            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                DefaultExt = ".txt"
            };


            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                var fileName = saveFileDialog1.FileName;
                button1_Click(sender, e);
                File.WriteAllText(fileName, textBox.Text);
            }
            catch (Exception)
            {
                Console.WriteLine(@"Error");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"This was made with half assed love enjoy.");
        }

        /// <summary>
        /// Handle quiting of the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure you want to quit?", @"Do you want to quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox.Text == null) return;
            try
            {
                var textboxContent = textBox.Text.Split('\n');
                foreach (var names in textboxContent)
                {
                    namesMaster.Add(names);
                }
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.StackTrace);
            }
            namesMaster.Sort();
            textBox.Clear();

            foreach (var name in namesMaster)
            {
                textBox.Text += name + '\n';
            }

            namesMaster.Clear();
        }
    }
}
