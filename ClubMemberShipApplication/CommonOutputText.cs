﻿using System;
namespace ClubMemberShipApplication
{
	public class CommonOutputText
	{
        private static string MainHeading
        {
			get
			{
				string heading = "Cycling Club";
				return $"{heading}{Environment.NewLine} {new string('-', heading.Length)}";
			}
        }
        private static string RegistrationHeading
        {
            get
            {
                string heading = "Register";
                return $"{heading}{Environment.NewLine} {new string('-', heading.Length)}";
            }
        }
        private static string LoginHeading
        {
            get
            {
                string heading = "Login";
                return $"{heading}{Environment.NewLine} {new string('-', heading.Length)}";
            }
        }

        public static void WriteMainHeading()
        {
            Console.Clear();
            Console.WriteLine(MainHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteRegisterHeading()
        {
            Console.Clear();
            Console.WriteLine(RegistrationHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteLoginHeading()
        {
            Console.Clear();
            Console.WriteLine(LoginHeading);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
