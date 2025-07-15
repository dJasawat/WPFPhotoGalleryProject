using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFPhotoGalleryProject.Models;

namespace WPFPhotoGalleryProject.ViewModels
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private AppDbContext _db = new AppDbContext();
        private string _searchQuery;

        public ObservableCollection<Photo> FilteredPhotos { get; set; } = new();

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterPhotos();
            }
        }

        public void LoadPhotosFromFolder(string folderPath)
        {
            var files = Directory.GetFiles(folderPath)
                                 .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png"))
                                 .ToList();

            foreach (var file in files)
            {
                if (!_db.Photos.Any(p => p.FilePath == file))
                {
                    _db.Photos.Add(new Photo
                    {
                        FilePath = file,
                        Tag = Path.GetFileNameWithoutExtension(file),
                        AddedOn = System.DateTime.Now
                    });
                }
            }
            _db.SaveChanges();
            FilterPhotos();
        }

        public void FilterPhotos()
        {
            var query = _db.Photos.AsQueryable();
            if (!string.IsNullOrEmpty(SearchQuery))
                query = query.Where(p => p.Tag.Contains(SearchQuery));

            FilteredPhotos.Clear();
            foreach (var photo in query.ToList())
                FilteredPhotos.Add(photo);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
