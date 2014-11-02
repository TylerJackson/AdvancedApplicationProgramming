/* Name: Program 7 Part2
 * Author: Tyler Jackson
 * Date: 11/1/14
 * Description:  This part of Program 7 uses a DataGridView to display the top 10 Comments
 *              (based on score) from the SuperUser database Comments table.  It also allows
 *              the user to edit the comments and then save their changes.  It utilizes a 
 *              DataAdapter object, which is handy because it can just find any changes
 *              made and update the corresponding table in the DB accordingly.  The loading
 *              of the data is all async.
 * 
 * Note: the queries were taking forever on my VM so I had to alter the command timeout to
 *      like 6 minutes just to make sure they were actually working.  
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Program7Part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            //load connection string from app.config
            var connectionString = ConfigurationManager.ConnectionStrings["SuperUser"].ConnectionString;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    //load current data from datagridview
                    var dataTable = dataGridView1.DataSource as DataTable;

                    var query = "SELECT TOP 10 Id,Text,Score FROM Comments ORDER BY Score DESC";

                    var dataAdapter = new SqlDataAdapter(query, connection);

                    //create this so that INSERT,UPDATE, and DELETE functions will all be 
                    //createdfor the DataAdapter
                    var sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);

                    //update table async
                    var result = await Task.Run(() => dataAdapter.Update(dataTable));

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error when saving the changes.");
            }
        }

        private void LoadData()
        {
            //load connection string from app.config
            var connectionString = ConfigurationManager.ConnectionStrings["SuperUser"].ConnectionString;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var dataSet = new DataSet();
                    //top 10 comments by score
                    var query = "SELECT TOP 10 Id,Text,Score FROM Comments ORDER BY Score DESC";

               
                    var dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.CommandTimeout = 360;

                    //populate our dataSet with the data from the query
                    dataAdapter.Fill(dataSet);

                    dataGridView1.DataSource = dataSet.Tables[0];
                }
            }catch(Exception ex)
            {
                Console.WriteLine("There was an error when loading the data.");
            }
        }
    }
}
