/* Name: Program 7 Part1
 * Author: Tyler Jackson
 * Date: 11/1/14
 * Description:  This part of Program 7 uses a ListBox to display the top 10 Comments
 *              (based on score) from the SuperUser database Comments table.  It also allows
 *              the user to search for comments that contain a certain text, and to delete a 
 *              comment.  It utilizes a DataReader object, and a Comment class I made to store
 *              the data.  The loading of the data is all async.
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
namespace Program7
{
    public partial class Form1 : Form
    {
        public List<Comment> comments;
        public Form1()
        {
            InitializeComponent();
            comments = new List<Comment>();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //load data to be stored in listbox
        private async void LoadData()
        {
            comments.Clear();
            //load connection string from app.config
            var connectionString = ConfigurationManager.ConnectionStrings["SuperUser"].ConnectionString;
            try
            {
                //this first connection is used for getting the number of rows returned
                //for the particular query that's displayed on the bottom of the form
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    bool searchTextSpecified = false;
                    if (SearchTextBox.Text != "")
                    {
                        searchTextSpecified = true;
                    }
                    var query = "";

                    //if there is any text in the search text box then use this query
                    if (searchTextSpecified)
                    {
                        query = string.Format("SELECT Count(1) as Number FROM [SuperUser].[Dbo].[Comments]WHERE Text LIKE '%' + @SearchText + '%'");
                    }
                    else
                    {
                        query = string.Format("SELECT Count(1) as Number FROM [SuperUser].[Dbo].[Comments]");
                    }
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (searchTextSpecified)
                        {
                            var parameter = new SqlParameter("@SearchText", SqlDbType.NVarChar, 100);
                            parameter.Value = SearchTextBox.Text;
                            command.Parameters.Add(parameter);
                        }
                        command.CommandTimeout = 360;
                        //use execute scalar since it is only returning 1 number
                        var numberResultsAffected = command.ExecuteScalar();
                        NumberOfRowsLabel.Text = string.Format("Total Rows Found   {0}", numberResultsAffected);
                    }
                }
                //this next connection returns the data as opposed to the number of rows 
                //returned for the query
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    bool searchTextSpecified = false;
                    if (SearchTextBox.Text != "")
                    {
                        searchTextSpecified = true;
                    }
                    var query = "";
                    if (searchTextSpecified)
                    {
                        query = string.Format("SELECT TOP 10 [Id],[Text],[Score] FROM [SuperUser].[Dbo].[Comments]WHERE Text LIKE '%' + @SearchText + '%' ORDER BY Score Desc");
                    }
                    else
                    {
                        query = string.Format("SELECT TOP 10 [Id],[Text],[Score] FROM [SuperUser].[Dbo].[Comments] ORDER BY Score Desc");
                    }
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (searchTextSpecified)
                        {
                            var parameter = new SqlParameter("@SearchText", SqlDbType.NVarChar, 100);
                            parameter.Value = SearchTextBox.Text;
                            command.Parameters.Add(parameter);
                        }
                        command.CommandTimeout = 360;
                        //use datareader asynchronously
                        var dataReader = await Task.Run(() => command.ExecuteReader());

                        //loop through all the data adding a comment for each row to our 
                        //list
                        while (dataReader.Read())
                        {
                            var comment = new Comment()
                            {
                                Id = (int)dataReader["Id"],
                                Text = dataReader["Text"] as string,
                                Score = (int)dataReader["Score"]
                            };
                            comments.Add(comment);
                        }
                    }
                }

                listBox1.DataSource = null;
                listBox1.DataSource = comments;
                listBox1.DisplayMember = "Text";

                
            }catch(Exception ex)
            {
                Console.WriteLine("Check your connection string to make sure it is correct.");
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //deletes selected row from table/listbox
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedComment = listBox1.SelectedItem as Comment;
            if (selectedComment == null)
                return;

            //first prompt user to make sure they are not deleting in error
            DialogResult dr = MessageBox.Show(String.Format("Are you sure you want to delete this comment?"), "Delete Comment?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;


            var connectionString = ConfigurationManager.ConnectionStrings["SuperUser"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    var query = string.Format("DELETE FROM [SuperUser].[Dbo].[Comments] WHERE Id = {0}", selectedComment.Id);

                    using (var command = new SqlCommand(query, connection))
                    {
                        //connect our transaction to this command
                        command.Transaction = transaction;

                        //use ExecuteNonQuery since I don't care about getting any data
                        //from the query
                        var numberRowsAffected = command.ExecuteNonQuery();
                        transaction.Commit();
                    }

                }catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
            //reload data for listbox after row was deleted
            LoadData();

            //notify user that comment was deleted successfully
            MessageBox.Show(string.Format("The comment was successfully deleted"),"Deleted!",MessageBoxButtons.OK);
        }


       
    }

    public class Comment
    {
        public Int32 Id { get; set; }
        public string Text {get; set;}
        public Int32 Score { get; set; }
        public Comment()
        {
            Id = -1;
            Text = "";
            Score = -1;
        }
    }

}