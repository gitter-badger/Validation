# Validation

[![Join the chat at https://gitter.im/jonest/Validation](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/jonest/Validation?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
C# parameter validation


### Example
```cs
public interface IIntWriter
{
   void WriteInt( [ValidateIntBounds( 0, 2 )] int intToWrite );
}

var containerFactory = new UnityAdapterFactory
{
   Extensions = new List<UnityContainerExtension>
   {
      new Interception()
   },
   InjectionMembers = new List<InjectionMember>
   {
      new Interceptor<InterfaceInterceptor>(),
      new InterceptionBehavior<ValidateBoundsInterceptorBehavior>()
   }
};

UnityContainerAdapter container = containerFactory.CreateNewContainer();
container.RegisterType<IIntWriter, IntWriter>();

var intWriter = container.Resolve<IIntWriter>();

try
{
   intWriter.WriteInt( 10 );
}
catch ( ArgumentOutOfRangeException ex )
{
   Console.WriteLine( "Argument out of range! {0}", ex.ParamName );
}

try
{
   intWriter.WriteInt( -1 );
}
catch ( ArgumentOutOfRangeException ex )
{
   Console.WriteLine( "Argument out of range! {0}", ex.ParamName );
}

try
{
   intWriter.WriteInt( 1 );
}
catch ( ArgumentOutOfRangeException ex )
{
   Console.WriteLine( "Argument out of range! {0}", ex.ParamName );
}
```
