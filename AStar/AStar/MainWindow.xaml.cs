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

namespace AStar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {

            List<List<int>> items = new List<List<int>>();

            for (int i = 0; i < 15; i++)
            {
                items.Add(new List<int>());
                for (int j = 0; j < 15; j++)
                {
                    items[i].Add(i * 10 + j);
                }
            }

            InitializeComponent();
            Cells.ItemsSource = items;
        }

        
    }
}
