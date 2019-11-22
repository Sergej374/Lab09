using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'g374_L09_BezuglyiSergeyDDataSet.l09_planets' table. You can move, or remove it, as needed.
            this.l09_planetsTableAdapter.Fill(this.g374_L09_BezuglyiSergeyDDataSet.l09_planets);

        }

        private void Test_Click(object sender, EventArgs e)
        {
            string str = "Data Source=127.0.0.1;Initial Catalog=g374_L09_BezuglyiSergeyD;Persist Security Info=True;User ID=student;Password=student";

            SqlConnection con = new SqlConnection(str);
            con.Open();

            string sql = "SELECT PlanetName, DistanceFromSun FROM l09_planets;";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                double dist = rdr.GetDouble(1);

                MessageBox.Show(name + ";" + dist.ToString());
            }
            rdr.Close();
            con.Close();
        }
    }
}
