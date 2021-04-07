﻿using System;
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
using BeautySaloonBusinessLogic.ViewModels;
using BeautySaloonBusinessLogic.BusinessLogic;
using BeautySaloonBusinessLogic.BindingModels;
using Unity;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace BeautySaloonViewClient
{
    /// <summary>
    /// Логика взаимодействия для WindowProcedures.xaml
    /// </summary>
    public partial class WindowProcedures : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ProcedureLogic logic;

        public int Id { set { id = value; } }

        private int? id;

        public WindowProcedures(ProcedureLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowProcedure>();
            window.ClientId = (int)id;
            if (window.ShowDialog().Value)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridProcedures.SelectedCells.Count != 0)
            {
                var window = Container.Resolve<WindowProcedure>();
                var cellInfo = dataGridProcedures.SelectedCells[0];
                ProcedureViewModel content = (ProcedureViewModel)(cellInfo.Item);
                window.Id = Convert.ToInt32(content.Id);
                window.ClientId = (int)id;
                if (window.ShowDialog().Value)
                {
                    LoadData();
                }
               
            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProcedures.SelectedCells.Count != 0)
            {
                var result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
               MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var cellInfo = dataGridProcedures.SelectedCells[0];
                        ProcedureViewModel content = (ProcedureViewModel)(cellInfo.Item);
                        int id = Convert.ToInt32(content.Id);
                        logic.Delete(new ProcedureBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
   
        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void WindowProcedures_Loaded(object sender, RoutedEventArgs e)
        {
          
            LoadData();
        }
        private void LoadData()
        {
           
            var list = logic.Read(new ProcedureBindingModel
            {
                ClientId = id
            });
            if (list != null)
            {
                dataGridProcedures.ItemsSource = list;
                dataGridProcedures.Columns[0].Visibility = Visibility.Hidden;
                dataGridProcedures.Columns[0].Width = 0;

                dataGridProcedures.Columns[1].Visibility = Visibility.Hidden;
                dataGridProcedures.Columns[1].Width = 0;

            }
        }

        /// <summary>
        /// Данные для привязки DisplayName к названиям столбцов
        /// </summary>
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
            new DataGridLength(1, DataGridLengthUnitType.Star); // честно я хз, но вроде это растягивает последний столбец до полной ширины

        }
        /// <summary>
        /// метод привязки DisplayName к названию столбца
        /// </summary>
        public static string GetPropertyDisplayName(object descriptor)
        {

            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                DisplayNameAttribute displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }

            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        DisplayNameAttribute displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }
    }
}
