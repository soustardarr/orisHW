using System;
namespace myServerBattleNet.Attribuets
{
	public class HttpController : Attribute
	{
		public HttpController(string controllerName)
		{
			ControllerName = controllerName;
		}

		public string ControllerName { get; }
	}
}

