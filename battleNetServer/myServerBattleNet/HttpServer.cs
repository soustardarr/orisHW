using System;
using System.Net;
using System.Net.Mime;
using myServerBattleNet.Configuration;
using myServerBattleNet.Heandlers;

namespace myServerBattleNet
{
	public class HttpServer
	{
		private HttpListener _listener = new HttpListener();
		private CancellationTokenSource source = new();
		private AppSetConfig _config = ConfigerAppSet.AppSet;
		private bool _running = false;
		private Handler _staticfileHandler = new StaticFileHandler();
		private Handler _controllerHandler = new ControllerHandler();



        public HttpServer()
		{
			Console.WriteLine($"{_config.Address}:{_config.Port}/");
		}



		public async Task RunServer()
		{
			await Task.Run(async () => { await ProcessServer(); });	
		}


		private async Task ProcessServer()
		{
            _listener.Prefixes.Add($"{_config.Address}:{_config.Port}/");
            _listener.Start();
			_running = true;
			var token = source.Token;
			Console.WriteLine("Server has been started.");

			Task.Run(ProccessCallback);

			while (_running)
			{
				if (token.IsCancellationRequested)
					return;

                var context = await _listener.GetContextAsync();
				_staticfileHandler.Successor = _controllerHandler;
				_staticfileHandler.HandleRequest(context);
            }

			_running = false;
			_listener.Close();
		}

		private void ProccessCallback()
		{
			while (true)
			{
				if(Console.ReadLine() == "stop")
				{
					source.Cancel();
					_running = false;
					break;
                }
			}
		}

	}
}

