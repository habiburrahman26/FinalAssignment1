﻿using FinalTermAssignment.Diary_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTermAssignment
{
    public partial class DeleteEvent : Form
    {
        
        HomeScreen homeScreen;
        AddEvent addEvent;
        ModifyEvent modifyEvent;
        string name;
        public DeleteEvent(AddEvent addEvent,string name)
        {
            InitializeComponent();
            this.addEvent = addEvent;
            this.name = name;
        }
        public DeleteEvent(ModifyEvent modifyEvent, string name)
        {
            InitializeComponent();
            this.modifyEvent = modifyEvent;
            this.name = name;
        }
        public DeleteEvent(DetailsFrom df,string name)
        {
            InitializeComponent();
            this.name = name;
            delete_Button.Click += this.Refreash;
            delete_Button.Click += this.Clear;
        }

        private void DeleteEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // eventId = (int)deleteDataGridView.Rows[e.RowIndex].Cells[0].Value;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DeleteService deleteService = new DeleteService();
            int result = deleteService.DeleteNotes(Convert.ToInt32( eventIdtextBox.Text));
            if(result>0)
            {
                MessageBox.Show("Delete Successfully");
            }
            else
            {
                MessageBox.Show("Error Occur!");
            }
        }

        private void DeleteEvent_Load(object sender, EventArgs e)
        {
            AddService addService = new AddService();
            deleteDataGridView.DataSource = addService.GetAllEvent(name);
        }
        void Refreash(object sender, EventArgs e)
        {
            AddService addService = new AddService();
            deleteDataGridView.DataSource = addService.GetAllEvent(name);
        }
        void Clear(object sender, EventArgs e)
        {
            eventIdtextBox.Text = string.Empty;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginFrom lf = new LoginFrom();
            lf.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoginFrom loginFrom = new LoginFrom();
            loginFrom.Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            homeScreen = new HomeScreen(this, name);
            homeScreen.Show();
            this.Hide();
        }
    }
}
