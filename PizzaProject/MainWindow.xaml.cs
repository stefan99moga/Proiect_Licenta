using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using TaskAlocModel;

namespace PizzaProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        TaskAlocEntitiesModel ctx = new TaskAlocEntitiesModel();
        CollectionViewSource chefVSource;
        CollectionViewSource pizzaVSource;
        CollectionViewSource chefTasksVSource;



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //chefs
            chefVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("chefViewSource")));
            chefVSource.Source = ctx.Chefs.Local;
            ctx.Chefs.Load();
            //pizzas
            pizzaVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pizzaViewSource")));
            pizzaVSource.Source = ctx.Pizzas.Local;
            ctx.Pizzas.Load();
            //chefsTasks
            chefTasksVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("chefTasksViewSource")));
            //chefTasksVSource.Source = ctx.Tasks.Local;
            ctx.Tasks.Load();
            ctx.Pizzas.Load();
            //comboxes
            cmbChefs.ItemsSource = ctx.Chefs.Local;
            //cmbChefs.DisplayMemberPath = "FirstName";
            cmbChefs.SelectedValuePath = "ChefId";

            //cmbPizza.ItemsSource = ctx.Pizzas.Local;
            //cmbPizza.DisplayMemberPath = "Name";
            cmbPizza.SelectedValuePath = "Size";

            BindDataGrid();

            System.Windows.Data.CollectionViewSource chefViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("chefViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // chefViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource pizzaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pizzaViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pizzaViewSource.Source = [generic data source]

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            BindingOperations.ClearBinding(firstNameTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(lastNameTextBox, TextBox.TextProperty);
            SetValidationBinding();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            chefVSource.View.MoveCurrentToPrevious();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            chefVSource.View.MoveCurrentToNext();

        }
        private void btnPrev_Clickpizza(object sender, RoutedEventArgs e)
        {
            pizzaVSource.View.MoveCurrentToPrevious();
        }
        private void btnNext_ClickPizza(object sender, RoutedEventArgs e)
        {
            pizzaVSource.View.MoveCurrentToNext();
        }
        private void Button_PrevClickTask(object sender, RoutedEventArgs e)
        {
            chefTasksVSource.View.MoveCurrentToPrevious();
        }
        private void btnNextTask_Click(object sender, RoutedEventArgs e)
        {
            chefTasksVSource.View.MoveCurrentToNext();
        }
        private void SaveChefs()
        {
            Chef chef = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Chef entity
                    chef = new Chef()
                    {
                        FirstName = firstNameTextBox.Text.Trim(),
                        LastName = lastNameTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Chefs.Add(chef);
                    chefVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    chef = (Chef)chefDataGrid.SelectedItem;
                    chef.FirstName = firstNameTextBox.Text.Trim();
                    chef.LastName = lastNameTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    chef = (Chef)chefDataGrid.SelectedItem;
                    ctx.Chefs.Remove(chef);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                chefVSource.View.Refresh();
            }
        }
        private void SavePizza()
        {
            Pizza pizza = null;

            if (action == ActionState.New)
            {
                try
                {
                    pizza = new Pizza
                    {
                        Size = sizeTextBox.Text.Trim(),
                        Name = nameTextBox.Text.Trim()
                    };
                    ctx.Pizzas.Add(pizza);
                    pizzaVSource.View.Refresh();
                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    pizza = (Pizza)pizzaDataGrid.SelectedItem;
                    pizza.Size = sizeTextBox.Text.Trim();
                    pizza.Name = nameTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    pizza = (Pizza)pizzaDataGrid.SelectedItem;
                    ctx.Pizzas.Remove(pizza);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                pizzaVSource.View.Refresh();
            }
        }
        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlAutoLot.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Chefs":
                    SaveChefs();
                    break;
                case "Pizza":
                    SavePizza();
                    break;
                case "Tasks":
                    break;
            }
            ReInitialize();
        }
        private void SaveTasks()
        {
            TaskAlocModel.Task task = null;
            if (action == ActionState.New)
            {
                try
                {
                    Chef chef = (Chef)cmbChefs.SelectedItem;
                    Pizza pizza = (Pizza)cmbPizza.SelectedItem;
                    //instantiem Task entity
                    task = new TaskAlocModel.Task()
                    {

                        ChefId = chef.ChefId,
                        PizzaId = pizza.PizzaId
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Tasks.Add(task);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Edit)
            {
                dynamic selectedTask = tasksDataGrid.SelectedItem;
                try
                {
                    int curr_id = selectedTask.TaskId;
                    var editedTask = ctx.Tasks.FirstOrDefault(s => s.TaskId == curr_id);
                    if (editedTask != null)
                    {
                        editedTask.ChefId = Int32.Parse(cmbChefs.SelectedValue.ToString());
                        editedTask.PizzaId = Convert.ToInt32(cmbChefs.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                chefTasksVSource.View.MoveCurrentTo(selectedTask);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedTask = tasksDataGrid.SelectedItem;
                    int curr_id = selectedTask.TaskId;
                    var deletedTask = ctx.Tasks.FirstOrDefault(s => s.TaskId == curr_id);
                    if (deletedTask != null)
                    {
                        ctx.Tasks.Remove(deletedTask);
                        ctx.SaveChanges();
                        MessageBox.Show("Task Deleted Successfully", "Message");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BindDataGrid()
        {
            var queryTask = from tas in ctx.Tasks
                            join che in ctx.Chefs on tas.ChefId equals
                            che.ChefId
                            join piz in ctx.Pizzas on tas.PizzaId equals
                            piz.PizzaId
                            select new
                            {
                                tas.TaskId,
                                tas.PizzaId,
                                tas.ChefId,

                                che.FirstName,
                                che.LastName,

                                piz.Name,
                                piz.Size
                            };
        }

        private void SetValidationBinding()
        {
            Binding firstNameValidationBinding = new Binding();
            firstNameValidationBinding.Source = chefVSource;
            firstNameValidationBinding.Path = new PropertyPath("FirstName");
            firstNameValidationBinding.NotifyOnValidationError = true;
            firstNameValidationBinding.Mode = BindingMode.TwoWay;
            firstNameValidationBinding.UpdateSourceTrigger =
           UpdateSourceTrigger.PropertyChanged;
            //string required
            firstNameValidationBinding.ValidationRules.Add(new StringNotEmpty());
            firstNameTextBox.SetBinding(TextBox.TextProperty, firstNameValidationBinding);
            Binding lastNameValidationBinding = new Binding();
            lastNameValidationBinding.Source = chefVSource;
            lastNameValidationBinding.Path = new PropertyPath("LastName");
            lastNameValidationBinding.NotifyOnValidationError = true;
            lastNameValidationBinding.Mode = BindingMode.TwoWay;
            lastNameValidationBinding.UpdateSourceTrigger =
           UpdateSourceTrigger.PropertyChanged;
            //string min length validator
            lastNameValidationBinding.ValidationRules.Add(new StringMinLengthValidator());
            lastNameTextBox.SetBinding(TextBox.TextProperty,lastNameValidationBinding); //setare binding nou
        }

       
    }
} 

