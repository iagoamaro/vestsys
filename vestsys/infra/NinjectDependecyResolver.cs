using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vestsys.Models.Abstract;
using vestsys.Models.Concret;

namespace vestsys.infra
{
    public class NinjectDependecyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependecyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        public IKernel Kernel
        {
            get { return kernel; }
        }

        private void AddBindings()
        {
            Bind<IUsuario>().To<EFUsuario>();
            Bind<ICandidato>().To<EFCandidato>();
            Bind<ICurso>().To<EFCurso>();
            Bind<IVestibular>().To<EFVestibular>();
            Bind<Dbcontexto>().ToSelf();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}