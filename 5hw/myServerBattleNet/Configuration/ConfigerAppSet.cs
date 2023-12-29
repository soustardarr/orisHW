using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace myServerBattleNet.Configuration
{
	public class ConfigerAppSet
	{
		public static AppSetConfig AppSet { get; private set; }
		static ConfigerAppSet()
		{
			ApplyConfig();

		}

		private static void ApplyConfig()
		{
			try
			{
				var json = File.OpenText("appsettings.json").ReadToEnd();
				AppSet = JsonConvert.DeserializeObject<AppSetConfig>(json);
			}
			catch (FileNotFoundException ex1)
            {
				Console.WriteLine($"{ex1.Message} - ошибка ");
			}
			catch (Exception ex2) {
				Console.WriteLine(ex2.Message);
			} 
		}

	}
}

