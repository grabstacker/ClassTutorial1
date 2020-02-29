using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList lcArtistList = new clsArtistList();


        private void UpdateDisplay()
        {
            string[] lcDisplayList = new string[lcArtistList.Count];

            lstArtists.DataSource = null;
            lcArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(lcArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lcArtistList.NewArtist();
            UpdateDisplay();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lcArtistList.EditArtist(lcKey);
                UpdateDisplay();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            lcArtistList.Save();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                lcArtistList.Remove(lcKey);
                UpdateDisplay();
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            lcArtistList = clsArtistList.Retrieve();
            UpdateDisplay();
        }
    }
}