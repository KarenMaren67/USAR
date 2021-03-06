﻿using Application;
using DAL;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using TestProjectForUSAR.Views.Shell;

namespace TestProjectForUSAR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {

        }

        /// <summary>
        /// Точка входа клиентского кода.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Приложение закрываем, если пользователь закрывает главное окно приложения.
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IContainerProvider>(Container);
        }

        /// <summary>
        /// Создаем главное окно приложения.
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell() => Container.Resolve<ShellWindow>();

        /// <summary>
        /// Для автоматического связывания и регистрации вью моделей описываем правила поиска вьюмоделей для вьюх.
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName != null ? viewType.FullName : throw new NullReferenceException("viewType.FullName является обязательным");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
                return Type.GetType(viewModelName);
            });
        }

        /// <summary>
        /// Добавляем модули в приложение.
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<MessageSaverModule>();
            moduleCatalog.AddModule<AppModule>();
            moduleCatalog.AddModule<DALModule>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate("ShellRegion", "MessageView", (NavigationResult navigationResult) =>{ });
        }
    }
}
