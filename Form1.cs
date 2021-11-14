using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace UKKCRUD
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Visual Studio\UKKCRUD\BetaMart.accdb");
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            string query = "delete from Table1 where ID=" + textBoxId.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxId.Text = "";
            MessageBox.Show("Barang berhasil dihapus");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table1 (ID,Nama,Stok,Harga,Kategori) values('" + textBoxId.Text + "','" + textBoxNama.Text + "','" + textBoxStok.Text + "','" + textBoxHarga.Text + "','" + textBoxKategori.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHarga.Text = "";
            textBoxKategori.Text = "";
            MessageBox.Show("Barang berhasil ditambah");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            string query = "update Table1 set Nama='" + textBoxNama.Text + "' ,Stok='" + textBoxStok.Text + "' ,Harga='" + textBoxHarga.Text + "' ,Kategori='" + textBoxKategori.Text + "' where ID=" + textBoxId.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxId.Text = "";
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHarga.Text = "";
            textBoxKategori.Text = "";
            MessageBox.Show("Barang berhasil diupdate");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table1 where Nama='" + textBoxCari.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            con.Close();


            if (count == 0)
            {
                MessageBox.Show("Barang tidak ditemukan");
            }
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxNama.Clear();
            textBoxStok.Clear();
            textBoxHarga.Clear();
            textBoxKategori.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxNama.Clear();
            textBoxHarga.Clear();
            textBoxKategori.Clear();
            textBoxStok.Clear();
        }
    }
}
