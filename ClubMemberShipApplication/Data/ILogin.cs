using System;
using ClubMemberShipApplication.Models;

namespace ClubMemberShipApplication.Data
{
	public interface ILogin
	{
		User Login(string emailAddress, string password);
	}
}

