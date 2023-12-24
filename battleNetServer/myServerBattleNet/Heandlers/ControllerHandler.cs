using System;
using System.Net;
using System.Reflection;
using myServerBattleNet.Attribuets;

namespace myServerBattleNet.Heandlers
{
    public class ControllerHandler : Handler
    {
        public override void HandleRequest(HttpListenerContext context)
        {
            try
            {
                var strParams = context?.Request.Url!
                    .Segments
                    .Skip(1)
                    .Select(s => s.Replace("/", ""))
                    .ToArray();

                if (strParams!.Length < 2)
                    throw new ArgumentNullException("the number of lines in the query string is less than two!");

                using var streamReader = new StreamReader(context!.Request.InputStream);
                var tempOfData = streamReader.ReadToEnd();
                var currentOfUserData = tempOfData.Split('&');
                var formData = new string[] { WebUtility.UrlDecode(currentOfUserData[0][6..]), currentOfUserData[1][9..] };

                var controllerName = strParams[0];
                var methodName = strParams[1];
                var assembly = Assembly.GetExecutingAssembly();

                var controller = assembly.GetTypes()
                    .Where(t => Attribute.IsDefined(t, typeof(HttpController)))
                    .FirstOrDefault(c => ((HttpController)Attribute.GetCustomAttribute(c, typeof(HttpController))!)
                        .ControllerName.Equals(controllerName, StringComparison.OrdinalIgnoreCase));

                var method = controller?.GetMethods()
                    .FirstOrDefault(t => t.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                var queryParams = method?.GetParameters()
                    .Select((p, i) => Convert.ChangeType(formData[i], p.ParameterType))
                    .ToArray();

                method?.Invoke(Activator.CreateInstance(controller), queryParams);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}

