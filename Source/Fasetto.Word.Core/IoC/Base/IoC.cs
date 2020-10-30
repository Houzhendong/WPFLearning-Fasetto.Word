using Ninject;
using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The ioc container for application
    /// </summary>
    public class IoC
    {
        /// <summary>
        /// the kernel for ico container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        public static void Setup()
        {
            //bind all required view model 
            BindViewModels();
        }

        /// <summary>
        /// get a service from the ioc , of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            //
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
