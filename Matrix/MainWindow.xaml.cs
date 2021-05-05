using MatrixClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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


namespace Matrix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        Matrica<double> a = new Matrica<double>();
        Matrica<double> b = new Matrica<double>();
        Matrica<double> c = new Matrica<double>();
        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            int nA = Convert.ToInt32(nA_TextBox.Text);
            int mA = Convert.ToInt32(mA_TextBox.Text);
            int nB = Convert.ToInt32(nB_TextBox.Text);
            int mB = Convert.ToInt32(mB_TextBox.Text);
            a.Create(nA, mA);
            b.Create(nB, mB);
            Random ran = new Random();
            a.Generation((x, y) => (x * (y - 2) + 14) * ran.Next(-10, 10));
            b.Generation((x, y) => (2 * x * (2 * y + 7) + 14) * ran.Next(-10, 10));
            MatrixA_TextBox.Text = "";
            MatrixB_TextBox.Text = "";
            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < mA; j++)
                {
                    MatrixA_TextBox.Text += a[i, j] + " ";
                }
                MatrixA_TextBox.Text += "\n";
            }
            for (int i = 0; i < nB; i++)
            {
                for (int j = 0; j < mB; j++)
                {
                    MatrixB_TextBox.Text += b[i, j] + " ";
                }
                MatrixB_TextBox.Text += "\n";
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            int nC = Convert.ToInt32(nA_TextBox.Text);
            int mC = Convert.ToInt32(mB_TextBox.Text);
            string way = Directory.GetCurrentDirectory() + "\\Matrix_C.csv";
            StreamWriter sw = new StreamWriter(way);
            for (int i = 0; i < nC; i++)
            {
                sw.Write("\t");
                for (int j = 0; j < mC; j++)
                {
                    sw.Write(Convert.ToString(c[i,j]) + ";");
                    sw.Write("\t");
                }
                sw.WriteLine();
            }
            sw.Close();
            MessageBox.Show("Матрица сохранена по пути " + way);
        }

        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch time = new Stopwatch();
            TimeSpan resulttime;
            Time_TextBox.Text = "";
            MatrixC_TextBox.Text = "";
            int nA = Convert.ToInt32(nA_TextBox.Text);
            int mA = Convert.ToInt32(mA_TextBox.Text);
            int nB = Convert.ToInt32(nB_TextBox.Text);
            int mB = Convert.ToInt32(mB_TextBox.Text);
            if (Action_Combo_Box.SelectedIndex == 0)
            {
                if ((nA != nB) || (mA != mB))
                {
                    Exception ex = new ArgumentException("Размерности матриц А и В не совпадают");
                    throw ex;
                }
                c.Create(nA, mA);
                time.Restart();
                c = a + b;
                time.Stop();
                for (int i = 0; i < nA; i++)
                {
                    for (int j = 0; j < mA; j++)
                    {
                        MatrixC_TextBox.Text += c[i, j] + " ";
                    }
                    MatrixC_TextBox.Text += "\n";
                }
            }
            else
            {
                if ((mA != nB))
                {
                    Exception ex = new ArgumentException("Кол-во стоблцов матрицы А не совпадает с кол-вом строк матрицы В");
                    throw ex;
                }
                c.Create(nA, mB);
                time.Restart();
                c = a * b;
                time.Stop();
                for (int i = 0; i < nA; i++)
                {
                    for (int j = 0; j < mB; j++)
                    {
                        MatrixC_TextBox.Text += c[i, j] + " ";
                    }
                    MatrixC_TextBox.Text += "\n";
                }
            }
            resulttime = time.Elapsed;
            Time_TextBox.Text = Convert.ToString(resulttime);
        }
    }
}

