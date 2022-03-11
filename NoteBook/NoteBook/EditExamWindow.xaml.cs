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
using System.Windows.Shapes;
using Logic;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        private Logic.NoteBook nb;
        private Exam exam;
        private IStorage storage;

        public EditExamWindow(Logic.NoteBook nb, IStorage s)
        {
            InitializeComponent();
            this.nb = nb;
            exam = new Exam();
            this.storage = s;
            DrawModules();
        }

        private void DrawModules()
        {
            var list = nb.ListModules();
            modules.Items.Clear();
            foreach (var item in list)
            {
                modules.Items.Add(item);
            }
                
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                exam.Module = (Module)modules.SelectedItem;
                exam.IsAbsent = absent.IsEnabled;
                exam.Score = (float)Convert.ToDouble(score.Text);
                exam.DateExam = (DateTime)date.SelectedDate;
                exam.Teacher = prof.Text;
                exam.Coef = (float)Convert.ToDouble(coef.Text);
                //sauvegarde apres ajout d'un exam dans le notebook
                nb.AddExam(exam);
                storage.Save(nb);
                Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }           
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            score.IsEnabled = false;
            score.Text = "0";
        }

        private void NotCheck(object sender, RoutedEventArgs e)
        {
            score.IsEnabled = true;
        }
    }
}
