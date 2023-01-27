namespace DatingAppFS.Extension
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateOnly dob)
        {
            var today=DateOnly.FromDateTime(DateTime.UtcNow);   //21-01-2023
            /**
             *  age= 2023 - 2000
             *  age=23
             */
            var age =today.Year-dob.Year;

            // 21-01-2023> 
            if (dob >today.AddYears(-age))
            { age--; }
            return age; 
        }
    }
}
