using System;

namespace Validation.Attributes
{
   [AttributeUsage( AttributeTargets.Parameter )]
   public class ValidateIntBoundsAttribute : Attribute
   {
      private readonly double _lessThan;
      private readonly double _greaterThan;

      public ValidateIntBoundsAttribute( int greaterThan, int lessThan )
      {
         _greaterThan = greaterThan;
         _lessThan = lessThan;
      }

      public ValidateIntBoundsAttribute( int greaterThan )
         : this( greaterThan, int.MaxValue )
      {
      }

      public void Validate( int input, string inputName )
      {
         if ( input < _greaterThan || input > _lessThan )
         {
            throw new ArgumentOutOfRangeException( inputName );
         }
      }
   }
}