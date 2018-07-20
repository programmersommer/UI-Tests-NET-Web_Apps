using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFApp
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
