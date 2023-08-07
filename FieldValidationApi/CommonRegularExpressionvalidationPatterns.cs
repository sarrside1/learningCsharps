using System;
namespace FieldValidationApi
{
	public static class CommonRegularExpressionvalidationPatterns
	{
        public const string Email_Address_RegEx_Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public const string SEN_PhoneNumber_RegEx_Pattern = @"^\+221-[0-9]{2}-[0-9]{2}-[0-9]{2}-[0-9]{2}$";

        public const string SEN_Post_Code_RegEx_Pattern = @"^[0-9]{5}$";

        public const string Strong_Password_RegEx_Pattern = @"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
        
	}
}

