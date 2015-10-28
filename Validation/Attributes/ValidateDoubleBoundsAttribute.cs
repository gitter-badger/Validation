using System;

namespace Validation.Attributes
{
   [AttributeUsage( AttributeTargets.Parameter )]
   public class ValidateDoubleBoundsAttribute : Attribute
   {
      private readonly double _lessThan;
      private readonly double _greaterThan;

      public ValidateDoubleBoundsAttribute( double greaterThan, double lessThan )
      {
         _greaterThan = greaterThan;
         _lessThan = lessThan;
      }

      public ValidateDoubleBoundsAttribute( double greaterThan )
         : this( greaterThan, double.MaxValue )
      {
      }

      public void Validate( double input, string inputName )
      {
         if ( input < _greaterThan || input > _lessThan )
         {
            throw new ArgumentOutOfRangeException( inputName );
         }
      }
   }
}