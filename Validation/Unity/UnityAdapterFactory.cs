using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Validation.Unity
{
   public class UnityAdapterFactory : IUnityAdapterFactory
   {
      public List<UnityContainerExtension> Extensions
      {
         get;
         set;
      }
      public List<InjectionMember> InjectionMembers
      {
         get;
         set;
      }
      public UnityContainerAdapter CreateNewContainer()
      {
         IUnityContainer container = new UnityContainer();
         foreach ( UnityContainerExtension extension in Extensions )
         {
            container.AddExtension( extension );
         }

         return new UnityContainerAdapter( container, InjectionMembers );
      }
   }
}