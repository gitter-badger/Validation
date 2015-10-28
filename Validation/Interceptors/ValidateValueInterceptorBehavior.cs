using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Validation.Attributes;

namespace Validation.Interceptors
{
   public class ValidateValueInterceptorBehavior : IInterceptionBehavior
   {
      public IMethodReturn Invoke( IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext )
      {
         for ( var i = 0; i < input.Arguments.Count; i++ )
         {
            ParameterInfo parameterInfo = input.Arguments.GetParameterInfo( i );
            var doubleBoundsAttribute = parameterInfo.GetCustomAttribute<ValidateValueAttribute>();
            if ( doubleBoundsAttribute != null )
            {
               doubleBoundsAttribute.Validate( input.Inputs[i], parameterInfo.Name );
            }
         }

         return getNext()( input, getNext );
      }

      public IEnumerable<Type> GetRequiredInterfaces()
      {
         return Type.EmptyTypes;
      }

      public bool WillExecute
      {
         get
         {
            return true;
         }
      }
   }
}
