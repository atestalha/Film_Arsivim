﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Film_Arsivim
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ATES\\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");
        public string film;
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
