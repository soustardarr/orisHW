using System;
using System.Net;

namespace myServerBattleNet.Heandlers
{
	public abstract class Handler
	{
        public Handler Successor { get; set; }
        public abstract void HandleRequest(HttpListenerContext context);
    }
}

