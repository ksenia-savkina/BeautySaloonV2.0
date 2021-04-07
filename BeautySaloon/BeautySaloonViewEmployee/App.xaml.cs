using BeautySaloonBusinessLogic.BusinessLogics;
using BeautySaloonBusinessLogic.Interfaces;
using BeautySaloonDatabaseImplement.Implements;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace BeautySaloonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer currentContainer = BuildUnityContainer();

            var mainWindow = currentContainer.Resolve<WindowInital>();
            mainWindow.Show();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICosmeticStorage, CosmeticStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDistributionStorage, DistributionStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReceiptStorage, ReceiptStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CosmeticLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<DistributionLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReceiptLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogicEmployee>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
