using System;
using System.Net;
using myServerBattleNet.Configuration;
using Newtonsoft.Json.Linq;

namespace myServerBattleNet.Heandlers
{
    public class StaticFileHandler : Handler
    {

        private AppSetConfig _config = ConfigerAppSet.AppSet;


        public override void HandleRequest(HttpListenerContext context)
        {
            using var response = context.Response;
            var request = context.Request;
            var absolutPath = request.Url!.AbsolutePath;

            var pathOfStaticFile = Path.Combine(_config.StaticFilesPath, absolutPath.Trim('/'));
            Console.WriteLine(pathOfStaticFile);

            if (absolutPath!.Split('/')!.LastOrDefault()!.Contains('.'))
            {
                var pattern = absolutPath?.Split('/')?.LastOrDefault();
                pattern = pattern?[pattern.IndexOf('.')..];
                if (File.Exists(pathOfStaticFile) && pattern != null)
                {
                    response.ContentType = DictionaryExtensions._dictOfExtenshions[pattern];
                    var buffer = File.ReadAllBytes(pathOfStaticFile);
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
            else if(Successor != null)
            {
                Successor.HandleRequest(context);
            }
        }
    }
}

