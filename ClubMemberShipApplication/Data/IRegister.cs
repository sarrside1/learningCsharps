using System;
namespace ClubMemberShipApplication.Data
{
	public interface IRegister
	{
		bool Register(string[] fields);
		bool EmailExists(string emailAddress);
	}
}

