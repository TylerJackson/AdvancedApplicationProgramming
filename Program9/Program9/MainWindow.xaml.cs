/* Name: Program 9
 * Date: 11/22/14
 * Author: Tyler Jackson
 * Summary: This assignment uses XAML to achieve the same results and functionality as assign. 8.
 *          I used a List property to hold my comment objects, and implemented 
 *          INotifyPropertyChanged on my MainWindow class to notify the UI after new comments
 *          were loaded.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Program9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public List<Comment> CommentsToDisplay
        {
            get
            {
                return _commentsToDisplay;
            }
            set
            {
                if(_commentsToDisplay != value)
                {
                    _commentsToDisplay = value;
                    OnPropertyChanged("CommentsToDisplay");
                }
            }
        }

        public Comment SelectedComment { get; set; }
        public int TotalRows { get; set; }
        public string SearchText { get; set; }
        private SuperUserEntities context;
        private List<Comment> _commentsToDisplay;
        public MainWindow()
        {
            InitializeComponent();
            CommentsToDisplay = new List<Comment>();
            _commentsToDisplay = CommentsToDisplay;
            this.DataContext = this;
            context = new SuperUserEntities();
            LoadData();
        }
        
        //load the data into the listbox
        private void LoadData()
        {
            //extend the timeout
            context.Database.CommandTimeout = 300;

            //wrap queries in a try catch block just to be safe
            try
            {
                //initialize a separate comments object to hold all the comments from the 
                //query as opposed to just the top 10.  This will be used to update the Total
                //Rows label
                IQueryable<Comment> comments = GetComments();

                //from the list of correct comments get the top 10 and update the label
                CommentsToDisplay = comments.OrderByDescending(c => c.Score).Take(10).ToList();
                TotalRowsTextBlock.Text = string.Format("Total Rows Found: {0}", comments.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        //get the comments either with a specific text or without
        private IQueryable<Comment> GetComments()
        {
            if (SearchText != null && SearchText != "")
            {
                return context.Comments.Where(c => c.Text.Contains(SearchText));
            }
            else
            {
                return context.Comments;
            }
        }

        //if they pushed search
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        //delete the selected comment from the db context and save it to push the
        //changes back to the db
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            //if nothing is selected then don't do anything
            if(SelectedComment == null)
            {
                return;
            }
            context.Comments.Remove(SelectedComment);
            context.SaveChanges();

            //reload the search results after the delete
            LoadData();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName=null)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
