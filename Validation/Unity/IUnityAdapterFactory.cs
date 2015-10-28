using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Validation.Unity
{
   public interface IUnityAdapterFactory
   {
      List<UnityContainerExtension> Extensions
      {
         get;
         set;
      }
      List<InjectionMember> InjectionMembers
      {
         get;
         set;
      }

      UnityContainerAdapter CreateNewContainer();
   }
}
