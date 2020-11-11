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

namespace consultas_covid19
{
    public partial class Form1 : Form
    {
        private int stockMinimoVacunas = 10000;

        private int stockActualVacunas = 10000000;

        private string[] puntosDeReparto = {"Sacaba","Cercado","Quillacollo"};
        


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-LVVMBVB\SQLEXPRESS;Initial Catalog=consultas-covid19;User ID=sa;Password=123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;

            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT TutorialID, TutorialName FROM demotb";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }


            MessageBox.Show(Output);

            dataReader.Close();
            command.Dispose();            
            cnn.Close();
        }
    }
}
