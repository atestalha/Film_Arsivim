using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ATES\\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");

        void listele()
        {
            
            SqlDataAdapter da= new SqlDataAdapter("select *from TBLFILMLER", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFIMLER (AD,KATEGORI,LINK) VALUES (@P1,@P2,@P3)", baglan);
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2",txtKategorı.Text);
            komut.Parameters.AddWithValue("@P3", txtLınk.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("film kaydetme işleminiz başarıyla tamamlanmıstır","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU PROJENIN YAZILIMINI VE TASARIMINI ABDULLAH TALHA ATEŞ 02.10.2024 SAAT 06.32'DE YAPMISTIR", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRenk_Click(object sender, EventArgs e)
        {
            Color[] renkler = { Color.LawnGreen, Color.LightBlue, Color.Orange, Color.Pink, Color.SandyBrown, Color.Yellow, Color.Purple, Color.Violet, Color.Gray, Color.Honeydew };

            Random rand = new Random();
            int sayi = rand.Next(0, 10);

            this.BackColor = renkler[sayi];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            groupBox2.Size = new Size(1920, 1000);
            groupBox2.Location = new Point(0, 0);
        }
    }
}
