/*Name: Test 2
 * Author: Tyler Jackson
 * Date: 10/29/14
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
namespace Test2
{
    public partial class Form1 : Form
    {
        List<User> users;
        public Form1()
        {
            InitializeComponent();
            users = new List<User>();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // LoadData();
        }

        private async void LoadData()
        {
            users.Clear();
            var connectionString = ConfigurationManager.ConnectionStrings["SuperUser"].ConnectionString;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    bool searchNameSpecified = false;
                    if (SearchTextBox.Text != "")
                    {
                        searchNameSpecified = true;
                    }
                    var query = "";
                    if (searchNameSpecified)
                    {
                        query = string.Format("SELECT TOP 10 [Id],[Reputation],[DisplayName],[Location]FROM [SuperUser].[Dbo].[Users]WHERE DisplayName LIKE '%' + @SearchText + '%'");
                    }
                    else
                    {
                        query = string.Format("SELECT TOP 10 [Id],[Reputation],[DisplayName],[Location]FROM [SuperUser].[Dbo].[Users]");
                    }
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (searchNameSpecified)
                        {
                            var parameter = new SqlParameter("@SearchText", SqlDbType.NVarChar, 100);
                            parameter.Value = SearchTextBox.Text;
                            command.Parameters.Add(parameter);
                        }
                        var dataReader = await Task.Run(() => command.ExecuteReader());
                        while (dataReader.Read())
                        {
                            var user = new User()
                            {
                                Id = (int)dataReader["Id"],
                                DisplayName = dataReader["DisplayName"] as string,
                                Location = dataReader["Location"] as string,
                                Reputation = (int)dataReader["Reputation"]

                            };
                            users.Add(user);
                        }
                    }
                }
                listBox1.DataSource = null;
                listBox1.DataSource = users;
                listBox1.DisplayMember = "DisplayName";
            }catch(Exception ex)
            {
                Console.WriteLine("Check your connection string to make sure it is correct.");
            }

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedUser = listBox1.SelectedItem as User;
            if (selectedUser == null)
                return;

            DialogResult dr = MessageBox.Show(String.Format("Are you sure you want to delete {0}", selectedUser.DisplayName), "Delete User?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;


            var connectionString = ConfigurationManager.ConnectionStrings["SuperUser"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //var transaction = connection.BeginTransaction();
                try
                {
                    var query = string.Format("DELETE FROM [SuperUser].[Dbo].[Users] WHERE Id = {0}", selectedUser.Id);

                    using (var command = new SqlCommand(query, connection))
                    {
                        var numberRowsAffected = command.ExecuteNonQuery();
                    }
                    //transaction.Commit();

                }catch(Exception ex)
                {
                    //transaction.Rollback();
                }
            }
            LoadData();

            RefreshBoxes();

            //added
            MessageBox.Show(string.Format("{0} has been terminated!",selectedUser.DisplayName),"Terminated!",MessageBoxButtons.OK);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBoxes();
        }
        private void RefreshBoxes()
        {
            var selectedUser = listBox1.SelectedItem as User;
            if (selectedUser == null)
            {
                IdTextBox.Text = "";
                DisplayNameTextBox.Text = "";
                LocationTextBox.Text = "";
                ReputationTextBox.Text = "";
            }
            else
            {
                IdTextBox.Text = string.Format("{0}", selectedUser.Id);
                DisplayNameTextBox.Text = selectedUser.DisplayName;
                LocationTextBox.Text = selectedUser.Location;
                ReputationTextBox.Text = string.Format("{0}", selectedUser.Reputation);
            }
        }
    }

    public class User
    {
        public Int32 Id { get; set; }
        public string DisplayName { get; set; }
        public string Location { get; set; }
        public Int32 Reputation { get; set; }
        public User()
        {
            Id = -1;
            DisplayName = "";
            Location = "";
            Reputation = -1;
        }
    }
}
