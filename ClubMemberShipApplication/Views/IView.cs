using System;
using ClubMemberShipApplication.FieldValidators;

namespace ClubMemberShipApplication.Views
{
	public interface IView
	{
		void RunView();
		IFieldValidator FieldValidator { get; }
	}
}

