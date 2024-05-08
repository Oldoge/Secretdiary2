using Calender.UserControls;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calender
{
    public partial class MainWindow : Window
    {

        private string noteText = "";
        private string timeText = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNote.Focus();
        }

        private void lblTime_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTime.Focus();
        }

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 0)
                lblNote.Visibility = Visibility.Collapsed;
            else
                lblNote.Visibility = Visibility.Visible;

            noteText = txtNote.Text;

            string NoteText = txtNote.Text;

        us: Item targetItem = new Item();



            targetItem.Title = NoteText;
            targetItem.Time = txtTime.Text;



        }
        private void txtTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Find the corresponding Item control based on the visual tree
                Item item = FindParent<Item>(textBox);
                if (item != null)
                {
                    // Update the Time property of the corresponding Item
                    timeText = textBox.Text;
                    item.Time = textBox.Text;
                }
            }
        }
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            return parent ?? FindParent<T>(parentObject);
        }


        private void CreateNewItem(object sender, RoutedEventArgs e)
        {
            // Create a new Item control
            Item newItem = new Item();

            // Set properties from noteText and timeText
            newItem.Title = noteText;
            newItem.Time = timeText;


            // Clear txtNote and txtTime
            txtNote.Text = "";
            txtTime.Text = "";

            // Clear noteText and timeText for future use
            noteText = "";
            timeText = "";
        }
        private void Item_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
