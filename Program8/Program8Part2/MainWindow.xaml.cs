/*Name: Program 8 Part2
 *Author: Tyler Jackson
 *Date: 11/11/14
 *Summary: This part of the homework works with Windows Presentation Foundation (WPF)
 *      We create an ellipse control inside a canvas.  The ellipse has size 50x50 and the 
 *      window and canvas have size 300.  The application starts with the ellipse as white,
 *      upon clicking on either the left or the right of the screen the color of the ellipse
 *      changes to blue or red respectively.  I also added a line down the middle, to make it 
 *      easier to tell if the color changes at the correct time.  The ellipse also moves with
 *      the mouse click to be centered wherever the mouse was clicked.
 *      
 *      I tried to write a lot of comments because the grader said he was getting confused.
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

namespace Program8Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //get the x and y coordinates of where the mouse was clicked
            //it gets the position of the mouse click in reference to the canvas
            var xCoord = e.GetPosition(Canvas1).X;
            var yCoord = e.GetPosition(Canvas1).Y;

            //set the position of the ellipse in reference to the canvas
            //notice here I adjusted the coordinate so that the center of the ellipse moves
            //to where the mouse was clicked.  Before it was the top left corner, which looked
            //weird since it fell outside of colored part.
            Canvas.SetTop(Ellipse1, yCoord-25);
            Canvas.SetLeft(Ellipse1, xCoord-25);

            //if the mouse click is on the right side of the window
            if(xCoord >150)
            {
                //turn ellipse red
                Ellipse1.Fill = new SolidColorBrush(Colors.Red);
            }
            else
            {
                //turn ellipse blue
                Ellipse1.Fill = new SolidColorBrush(Colors.Blue);
            }
        }
    }
}
