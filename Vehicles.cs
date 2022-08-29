using MySql.Data.MySqlClient;
using System.Data;

namespace AppTransport
{
    public partial class Vehicle : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        string sqlQuery;
        MySqlDataAdapter sqlDtAp = new MySqlDataAdapter();
        MySqlDataReader sqlRd;

        DataSet dS = new DataSet();

        string server = "localhost";
        string username = "root";
        string password = "DREADhead2638!";
        string database = "transportationapp";
        public Vehicle()
        {
            InitializeComponent();
        }

        public void upLoadData()
        {
            sqlConn.ConnectionString = "server =" + server + ";"
                + "username =" + username + ";"
                + "password =" + password + ";"
                + "database =" + database;

            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "select * from transportationapp.vehicles";
            sqlRd = sqlCmd.ExecuteReader();
            sqlRd.Close();
            sqlConn.Close();

            vehicledataGridView1.DataSource = sqlDt;
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            upLoadData();
        }

        private void exitPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                
                iExit = MessageBox.Show("Do you want to exit?", "Confirm that you want to exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}