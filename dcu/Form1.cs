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

namespace dcu
{
    public partial class Form1 : Form
    {
        public string cadena = "Data Source=LAPTOP-IGD74G69;Initial Catalog=dcu;Integrated Security=True";
        string nombre;
        string correo;
        string telefono;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cadena);
            if (nombre != "" & correo != "" & telefono != "" & Class1.path != "")
            {
                con.Open();
                correo = textBox2.Text;
                nombre = textBox3.Text;
                telefono = textBox4.Text;
                
                if(con.State==System.Data.ConnectionState.Open)
                {
                    string s = "insert into personas values ('" + nombre + "', '" + correo + "', '" + telefono + "', '" + Class1.path + "')";
                    SqlCommand cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Peticion realizada");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    Class1.path = "";
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdig = new OpenFileDialog();
            fdig.Title = "Busca la Imagen";
            fdig.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            fdig.FilterIndex = 2;
            fdig.RestoreDirectory=true;

            if(fdig.ShowDialog() == DialogResult.OK)
            {
                Class1.path = fdig.FileName;
            }

            Image img = Image.FromFile(Class1.path);
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            SqlConnection con = new SqlConnection(cadena);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string s = "select * from personas where ID="+id;
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.Read())
                {
                    textBox2.Text = registro["Nombre"].ToString();
                    textBox3.Text = registro["Correo"].ToString();
                    textBox4.Text = registro["Telefono"].ToString();
                    Class1.path = registro["Imagen"].ToString();
                    Image img = Image.FromFile(Class1.path);
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("el registro no se ha encontrado");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
