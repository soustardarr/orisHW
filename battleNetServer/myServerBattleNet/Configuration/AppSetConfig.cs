using System;
using Newtonsoft.Json;

namespace myServerBattleNet.Configuration
{
	public class AppSetConfig
	{
		[JsonProperty("address")]
		public string Address { get; set; }

        [JsonProperty("staticFilesPath")]
        public string StaticFilesPath { get; set; }

        [JsonProperty("port")]
        public uint Port { get; set; }

		[JsonProperty("emailSender")]
		public string EmailSender { get; set; }

        [JsonProperty("passwordSender")]
		public string PasswordSender { get; set; }

        [JsonProperty("fromName")]
		public string FromName { get; set; }


        [JsonProperty("smtpServerHost")]
        public string SmtpServerHost { get; set; }

        [JsonProperty("smtpServerPort")]
        public int SmtpServerPort { get; set; }

    }
}

//"port": 2203,
//  "address": "http://127.0.0.1",
//  "staticFilesPath": "static",
//  "emailSender": "Ruselkk@yandex.ru",
//  "passwordSender": "dbaavkesvceevpbs",
//  "fromName": "Ruslan",
//  "smtpServerHost": "smtp.yandex.ru",
//  "smtpServerPort": 465