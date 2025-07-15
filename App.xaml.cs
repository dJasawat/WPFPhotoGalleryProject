using SQLitePCL;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WPFPhotoGalleryProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Batteries_V2.Init(); // ✅ This initializes SQLite properly
            base.OnStartup(e);
            AppDbContext db = new AppDbContext();
            db.Database.EnsureCreated();
        }
    }

}
