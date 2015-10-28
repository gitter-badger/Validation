using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Validation.Attributes;

namespace Validation.Interceptors
{
   public class ValidateBoundsInterceptorBehavior : IInterceptionBehavior
   {
      public IMethodReturn Invoke( IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext )
      {
         for ( var i = 0; i < input.Arguments.Count; i++ )
         {
            ParameterInfo parameterInfo = input.Arguments.GetParameterInfo( i );
            var doubleBoundsAttribute = parameterInfo.GetCustomAttribute<ValidateDoubleBoundsAttribute>();
            if ( doubleBoundsAttribute != null )
            {
               doubleBoundsAttribute.Validate( (double) input.Inputs[i], parameterInfo.Name );
               continue;
            }

            var attribute = parameterInfo.GetCustomAttribute<ValidateIntBoundsAttribute>();
            if ( attribute != null )
            {
               attribute.Validate( (int) input.Inputs[i], parameterInfo.Name );
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
