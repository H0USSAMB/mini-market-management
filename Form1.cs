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


namespace houssambenamara
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table,table1;
        SqlDataReader dataReader;
        int cpt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=DESKTOP-SMJQGPU\\SQLEXPRESS;Initial Catalog=vols;Integrated Security=True");
            command = new SqlCommand("", connection);
            connection.Open();


            if (textBox1.Text == "")
            {
                MessageBox.Show("remplir tout les champs");
            }

            else if (confirmmation() > 0)
            {
                MessageBox.Show("cette compagnie déja existe");
            }

            else
            {
                command.CommandText = "insert into compagnie values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "')";

                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("ajoute bient fait");

            }
            connection.Close();
            afficher();
        }
        public void afficher()
        {
            connection = new SqlConnection("Data Source = DESKTOP-SMJQGPU\\SQLEXPRESS; Initial Catalog = vols; Integrated Security = True");

            command = new SqlCommand("", connection);
            connection.Open();
            command.CommandText = "select*from comagnie";
            dataReader = command.ExecuteReader();
            table = new DataTable();
            table.Load(dataReader);
            dataGridView1.DataSource = table;
            listBox1.DataSource = table;
            command.CommandText = "select * from aeroport where villecom = '" + comboBox1.SelectedValue.ToString() + "'";
            table1 = new DataTable();

            dataReader = command.ExecuteReader();

            table.Load(dataReader);
            dataGridView1.DataSource = table1;
            cpt = 0;
            connection.Close();


        }
        public int confirmmation()
        {
            command = new SqlCommand("select count(*) from vols where numcpm=" + textBox1.Text + "", connection);

            return (int)command.ExecuteScalar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=DESKTOP-SMJQGPU\\SQLEXPRESS;Initial Catalog=vols;Integrated Security=True");
            command = new SqlCommand("", connection);
            connection.Open();


            if (textBox1.Text == "")
            {
                MessageBox.Show("remplir tout les champs");
            }

            else if (confirmmation() == 0)
            {
                MessageBox.Show("cette compagnie pas existe");
            }

            else
            {
                command.CommandText = "update compagnie set nomcomp='" + textBox2.Text + "',nationaliecomp='" + textBox3.Text + "' where codecl=" + textBox1.Text + " ";

                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("modification bient fait");
            }
            connection.Close();
            afficher();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=DESKTOP-SMJQGPU\\SQLEXPRESS;Initial Catalog=vols;Integrated Security=True");
            command = new SqlCommand("", connection);
            connection.Open();


            if (textBox1.Text == "")
            {
                MessageBox.Show("remplir tout les champs");
            }

            else if (confirmmation() == 0)
            {
                MessageBox.Show("cette compagnie pas existe");
            }

            else
            {
                command.CommandText = "delete compagnie where numcomp=" + textBox1.Text + " ";

                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("la supretion bient fait");
            }
            connection.Close();
            afficher();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dataGridView1.DataSource = "";
            listBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            afficher();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cpt = 0;
            naviguer();
            afficher();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cpt--;
            naviguer();
            afficher();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cpt++;
            naviguer();
            afficher();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cpt = table.Rows.Count - 1;
            naviguer();
            afficher();
        }
        public void naviguer()
        {
            textBox1.Text = table.Rows[cpt]["codecl"].ToString();
            textBox2.Text = table.Rows[cpt]["nom"].ToString();
            textBox3.Text = table.Rows[cpt]["ville"].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            command.CommandText = "select * from aeroport where villeaeroport = '" + comboBox1.SelectedValue.ToString() + "'";
            table = new DataTable();

            dataReader = command.ExecuteReader();

            table.Load(dataReader);
            dataGridView1.DataSource = table;
            listBox1.DataSource = table;
        }
    }
}
