using System.Collections.ObjectModel;
using System.Windows;

namespace WPFCoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Country> Countries { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Countries = new ObservableCollection<Country>();
            Countries.Add(new Country() { Name = "Poland", TwoLetterCode = "PL" });
            Countries.Add(new Country() { Name = "Russia", TwoLetterCode = "RU" });
            Countries.Add(new Country() { Name = "Ukrainе", TwoLetterCode = "UA" });
            Countries.Add(new Country() { Name = "Belarus", TwoLetterCode = "BY" });
            DataContext = this;
        }
    }

    public class Country
    {
        public string Name { get; set; }
        public string TwoLetterCode { get; set; }
    }

}
