using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chest2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  контроль состояния
        int howMuchItemsIsProcess = 0;
        static Button firstItem;
        static int firstRow;
        static int firstColumn;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if(firstItem!=null) int sameDiagonale = ((Grid.GetRow(((Button)sender) - Grid.GetColumn(((Button)sender))) == (Grid.GetColumn(((Button)firstItem)) - Grid.GetColumn(((Button)sender))))?true:false;
            
            //  отмечание выставленных фигур
            if (howMuchItemsIsProcess<2)
            {
                ((Button)sender).Background = Brushes.DarkRed;
                howMuchItemsIsProcess++;
            }

            //  контроль состояния
            var secondRow = Grid.GetRow(sender as Button);
            var secondColumn = Grid.GetColumn(sender as Button);
            int sameDiagonale = ((Math.Abs(firstColumn-firstRow)) == (Math.Abs(secondColumn-secondRow))) ? 1 : 0;
            int sameDiagonale2 = ((firstColumn + firstRow) == (secondColumn + secondRow)) ? 1 : 0;

            //MessageBox.Show(firstRow+"; "+ firstColumn);

            //  проверка одна строка столбик диагональ влево вправо
            if (firstItem!=null && (firstRow == secondRow || 
                firstColumn == secondColumn | sameDiagonale==1 | sameDiagonale2==1))
            {
                //  сообщение о победе
                MessageBox.Show("YES");
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }

            if (firstItem == null)
            {
                //  фиксация обьекта
                firstItem = (Button)sender; 
                firstRow = Grid.GetRow(sender as Button);
                firstColumn = Grid.GetColumn(sender as Button);
            }
        }
    }
}
