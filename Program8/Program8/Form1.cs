/* Name: Program 8
 * Author: Tyler Jackson
 * Date: 11/15/14
 * Summary: This part of program 8 does the same as program 7 but with the Entity Framework.  
 *          Similar to that assignment I had to adjust the timeout so that the query would
 *          time to complete.
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

namespace Program8
{
    public partial class Form1 : Form
    {
        private SuperUserEntities context;
        public Form1()
        {
            InitializeComponent();
            context = new SuperUserEntities();
        }

        //load the data into the listbox
        //can call it with search text to get specific results, or without to get top 10 of
        //all comments
        private void LoadData(string searchText=null)
        {
            //extend the timeout and initialize a temporary list to hold our results
            context.Database.CommandTimeout = 300;
            List<Comment> topTenComments = new List<Comment>();

            //wrap queries in a try catch block just to be safe
            try
            {
                //initialize a separate comments object to hold all the comments from the 
                //query as opposed to just the top 10.  This will be used to update the Total
                //Rows label
                IQueryable<Comment> comments;

                if (searchText == null || searchText == "")
                {
                    //if they didn't specify a search test
                    comments = GetComments();
                }
                else
                {
                    //if they did specify a search test
                    comments = GetComments(searchText);
                }
                //from the list of correct comments get the top 10 and update the label
                topTenComments = comments.OrderByDescending(c => c.Score).Take(10).ToList();
                TotalRowsFoundLabel.Text = string.Format("Total Rows Found: {0}", comments.Count());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            //reset the datasource to update the listbox display
            //use the comment's text as the display member
            SearchResultsListBox.DataSource = null;
            SearchResultsListBox.DataSource = topTenComments;
            SearchResultsListBox.DisplayMember = "Text";

        }

        //get the comments either with a specific text or without
        private IQueryable<Comment> GetComments(string searchText=null)
        {
            if (searchText != null)
            {
                return context.Comments.Where(c => c.Text.Contains(searchText));
            }
            else
            {
                return context.Comments;
            }
        }

        //if they pushed search
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //load the data with the search text
            LoadData(SearchTextTextBox.Text);
        }

        //delete the selected comment from the db context and save it to push the
        //changes back to the db
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedComment = SearchResultsListBox.SelectedItem as Comment;

            //if the list is empty then don't do anything
            if(selectedComment == null)
            {
                return;
            }
            context.Comments.Remove(selectedComment);
            context.SaveChanges();

            //reload the search results after the delete
            LoadData(SearchTextTextBox.Text);
        }

        //load the top 10 comments when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //dispose of the context when the form closes
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }

    }
}
