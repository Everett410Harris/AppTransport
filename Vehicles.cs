using MySql.Data.MySqlClient;
using System.Data;
using System.Linq.Expressions;

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

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel4.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Clear();
                    }
                }
                makeCb.Text = "";
                vehicleYearCb.Text = "";
                engineTypeCb.Text = "";
                typeCb.Text = "";
                bookedCb.Text = "";
                licensePlateTb.Clear();
                modelTb.Clear();
                mileageTb.Clear();
                colorTb.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConn.ConnectionString = "server =" + server + ";"
                    + "username =" + username + ";"
                    + "password =" + password + ";"
                    + "database =" + database;

                sqlConn.Open();
                sqlQuery = "insert into transportationapp.vehicles(license_plate,make,model,year,engine,color,mileage,type,booked)" +
                    "values('" + licensePlateTb.Text + "', '" + makeCb.Text + "', '" + modelTb.Text + "', '" + vehicleYearCb.Text + "', '" + engineTypeCb.Text + "', " +
                    "'" + colorTb.Text + "', '" + mileageTb.Text + "', '" + typeCb.Text + "', '" + bookedCb.Text + "')";

                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            upLoadData();
        }

        private void vehicledataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                licensePlateTb.Text = vehicledataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                makeCb.Text = vehicledataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                modelTb.Text = vehicledataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                vehicleYearCb.Text = vehicledataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                engineTypeCb.Text = vehicledataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                colorTb.Text = vehicledataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                mileageTb.Text = vehicledataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                typeCb.Text = vehicledataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                bookedCb.Text = vehicledataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayBtn_Click(object sender, EventArgs e)
        {
            sqlConn.Open();
            string sqlQuery = "select * from transportationapp.vehicles";
            
        }
    }
}