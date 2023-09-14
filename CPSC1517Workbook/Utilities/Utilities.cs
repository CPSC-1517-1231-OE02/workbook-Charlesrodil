namespace Utils
{
    public static class Utilities
    {
        //Validate if string is Null/Empty/Whitespace

        //Expression-bodied method 
        public static bool IsNullEmptyOrWhiteSpace(string value) => String.IsNullOrWhiteSpace(value);


        //Validate if number is Zero or negative
        public static bool IsZeroOrNegative(int value)
        {
            /*Simple Method
             
            return value <= 0;

            */

            /* Explicit

            bool result;

            if (value <= 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

            */

            //Ternary Operator - Simple Explicit

            return value <= 0 ? true : false;
        }

        public static bool IsPositive(int value) => value <= 0 ? true : false;

        public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);
    }
}
