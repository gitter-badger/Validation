using System;

namespace Validation.Attributes
{
   [AttributeUsage( AttributeTargets.Parameter )]
   public class ValidateValueAttribute : Attribute
   {
      private readonly object _value;

      public ValidateValueAttribute( object value )
      {
         _value = value;
      }

      public void Validate( object input, string inputName )
      {
         if ( input == null )
         {
            throw new ArgumentNullException( inputName );
         }
      }
   }
}
