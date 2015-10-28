using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Validation.Unity
{
   public class UnityContainerAdapter : IUnityContainerAdapter
   {
      private readonly List<InjectionMember> _injectionMembers;
      private readonly IUnityContainer _unityContainer;

      public UnityContainerAdapter( IUnityContainer unityContainer, List<InjectionMember> injectionMembers )
      {
         _unityContainer = unityContainer;
         _injectionMembers = injectionMembers;
      }

      public void RegisterInstance<T>( T instance )
      {
         _unityContainer.RegisterInstance( instance );
      }

      public void RegisterType<T1, T2>() where T2 : T1
      {
         _unityContainer.RegisterType<T1, T2>( _injectionMembers.ToArray() );
      }

      public T Resolve<T>()
      {
         return _unityContainer.Resolve<T>();
      }
   }
}