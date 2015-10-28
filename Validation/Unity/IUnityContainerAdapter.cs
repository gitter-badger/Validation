namespace Validation.Unity
{
   public interface IUnityContainerAdapter
   {
      void RegisterInstance<T>( T instance );
      void RegisterType<T1, T2>() where T2 : T1;
      T Resolve<T>();
   }
}