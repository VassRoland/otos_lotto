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
using System.Text.RegularExpressions;
using System.IO;

namespace kocka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(" Ötös lottó \n A játék menete: \n 1. Elsőnek rakj meg 5 számot! \n 2. Kérj a géptől számokat! \n 3. Nézd meg a nyereményed! \n Jó szórakozást, sok szerencsét! \n A szelvényed írásban le van vezetve. (bin/debug mappában találhatod)! ");
        }
        int elso = 0;
        int masodik = 0;
        int harmadik = 0;
        int negyedik = 0;
        int otodik = 0;
     
        

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-91]+");
            e.Handled = regex.IsMatch(e.Text);
           
            for (int i = 0; i < 5; i++)
            {

                elso = Convert.ToInt32(Console.ReadLine());

                masodik = Convert.ToInt32(Console.ReadLine());

                harmadik = Convert.ToInt32(Console.ReadLine());

                negyedik = Convert.ToInt32(Console.ReadLine());

                otodik = Convert.ToInt32(Console.ReadLine());
            }


        }

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            szamok[0]= Convert.ToInt32(NumberTextBox.Text);
            szamok[1] = Convert.ToInt32(NumberTextBox1.Text);
            szamok[2] = Convert.ToInt32(NumberTextBox2.Text);
            szamok[3] = Convert.ToInt32(NumberTextBox3.Text);
            szamok[4] = Convert.ToInt32(NumberTextBox4.Text);
            int db = 0;
            for (int i = 0; i < 5; i++)
            {
                if (lottoszamok.Contains(szamok[i]))
                {
                   
                    db++;
                }
                else
                    eredmeny.Content = ("Nincs találat");
            }
            eredmeny.Content = db;
            if (db == 0)
            {
                eredmeny_2.Content = ("Sajnos nem nyert");
            }
            if (db==1)
            {
                eredmeny_2.Content = ("Sajnos nem nyert");
            }
            if(db==2)
            {

                eredmeny_2.Content = ("1 355 Ft");
            }
            if (db == 3)
            {

                eredmeny_2.Content = ("10 840 Ft");
            }
            if (db == 4)
            {

                eredmeny_2.Content = ("560 965 Ft");
            }
            if (db == 5)
            {

                eredmeny_2.Content = ("940 millió Ft");
                MessageBox.Show("Főnyeremény!!!!!!!!! Gratulálunk!!!!!");
            }
            StreamWriter File = new StreamWriter("Nyeremény.txt");
            File.Write("Találatod száma: "+db  );
            if (db == 0)
            {

                File.Write("Nyereményed:");
                File.WriteLine(" 0 Ft");

            }
            if (db==1)
            {

                File.Write("Nyereményed:");
                File.WriteLine(" 0 Ft");

            }
            if (db == 2)
            {
                File.Write("Nyereményed:");
               File.WriteLine("1 355 Ft");
            }
            if (db == 3)
            {
                File.Write("Nyereményed:");
                File.WriteLine("10 840 Ft");
            }
            if (db == 4)
            {
                File.Write("Nyereményed:");
                File.WriteLine("560 965 Ft");
            }
            if (db == 5)
            {
                File.Write(" Nyereményed:");
                File.WriteLine("940 millió Ft");
               File.WriteLine("Főnyeremény!!!!!!!!! Gratulálunk!!!!!");
            }
            File.Close();


        }



        int[] lottoszamok = new int[5];
        int[] szamok = new int[5];

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Random r = new Random();
                lottoszamok[0] = r.Next(1,91);
                _1.Content = lottoszamok[0];

            lottoszamok[1] = r.Next(1, 91);
            _2.Content = lottoszamok[1];

            lottoszamok[2] = r.Next(1, 91);
            _3.Content = lottoszamok[2];

            lottoszamok[3] = r.Next(1, 91);
            _4.Content = lottoszamok[3];

            lottoszamok[4] = r.Next(1, 91);
            _5.Content = lottoszamok[4];

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
