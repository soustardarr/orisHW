using System;
using myServerBattleNet.Attribuets;
using myServerBattleNet.Service;

namespace myServerBattleNet.Controllers
{
	[HttpController("account")]
	public class AccountController
	{
		public void Add(string emailFromUser, string passwordUser)
		{
			new EmailSender().SendEmail(passwordUser, emailFromUser, "");
			Console.WriteLine("Email has been sent.");
		}
	}
}

