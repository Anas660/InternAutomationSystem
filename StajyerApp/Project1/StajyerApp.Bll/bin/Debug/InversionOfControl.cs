﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using StajyerApp.Dal;
using StajyerApp.Infrastructure.Interceptors;
using StajyerApp.Interfaces;

namespace StajyerApp.Infrastructure
{
    //Inversion of Control 
    //Kontrollerin Yönünü değiştirme

    public static   class InversionOfControl
    {
        private static IWindsorContainer _container = null;

        private static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = BootstrapContainer();
                }
                return _container;
            }
        }

        private static IWindsorContainer BootstrapContainer()
        {

                    // Bu kısım program il ebirlikte dos ekranında açılmasını sğlıyor  
                    //NativeMethods.AllocConsole();
                    //IntPtr stdHandle = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);

                    //config dosyasından tanımlamalar için bu kod açık olmalı.
                    //return new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));
                    //Kod tarafından tanımlama için aşağıdaki kod açık olmalı.

                    return new WindsorContainer().Register(

                     Castle.MicroKernel.Registration.Component.For<Interceptor>().LifeStyle.Transient,                                 
                        Component.For<IStajyer>().ImplementedBy<StajyerDal>().Interceptors<Interceptor>(),
                        Component.For<IOkul>().ImplementedBy<OkulDal>().Interceptors<Interceptor>(),
                         Component.For<IBolum>().ImplementedBy<BolumDal>().Interceptors<Interceptor>(),
                          Component.For<IBirim>().ImplementedBy<BirimDal>().Interceptors<Interceptor>()


                  );
        }


        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
