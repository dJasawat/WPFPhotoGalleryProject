using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFPhotoGalleryProject.ViewModels;
using System.Windows.Forms;


namespace WPFPhotoGalleryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void LoadFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new  FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                viewModel.LoadPhotosFromFolder(dialog.SelectedPath);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SearchQuery = SearchBox.Text;
            viewModel.FilterPhotos();
        }
    }
}