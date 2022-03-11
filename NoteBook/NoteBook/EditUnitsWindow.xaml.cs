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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Logic.NoteBook notebook;
        private IStorage storage;
        public EditUnitsWindow(Logic.NoteBook n, IStorage s)
        {
            InitializeComponent();
            notebook = n;
            this.storage = s;
            this.DrawUnits();
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            units.Items.Clear();
            foreach (var item in list)
                units.Items.Add(item);
        }

        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (units.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    storage.Save(notebook);
                    DrawUnits();
                }
            }
        }

        private void CreateUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    DrawUnits();
                    storage.Save(notebook);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);

            }
        }

        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer l'unit", "supprimer ?", MessageBoxButton.YesNo);
                    if (r == MessageBoxResult.Yes)
                    {
                        notebook.RemoveUnit(unit);
                        DrawUnits();
                        storage.Save(notebook);
                    }             
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void DrawModules()
        {
            if (units.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                modules.Items.Clear();
                foreach (Module m in list)
                {
                    modules.Items.Add(m);
                }
            }
        }

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        private void EditModules(object sender, MouseButtonEventArgs e)
        {
            if (modules.SelectedItem is Module m)
            {
                EditElementWindow third = new EditElementWindow(m);
                if (third.ShowDialog() == true)
                {
                    storage.Save(notebook);
                    DrawModules();
                }
            }
        }

        private void CreateModule(object sender, RoutedEventArgs e)
        {
            try
            {
                Module newModule = new Module();
                EditElementWindow third = new EditElementWindow(newModule);
                if (third.ShowDialog() == true)
                {
                    if (units.SelectedItem is Unit unit)
                    {
                        unit.Add(newModule);
                        storage.Save(notebook);
                        DrawModules();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);

            }
        }

        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modules.SelectedItem is Module m)
                {
                    if (units.SelectedItem is Unit unit)
                    {
                        MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer ce module", "supprimer ?", MessageBoxButton.YesNo);
                        if (r == MessageBoxResult.Yes)
                        {
                            unit.Remove(m);
                            storage.Save(notebook);
                            DrawModules();
                        }     
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
