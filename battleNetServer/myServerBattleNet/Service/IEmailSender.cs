using System;
namespace myServerBattleNet.Service
{
	public interface IEmailSender
	{
		void SendEmail(string passwrodUser, string emailUser, string subject);
	}
}

