using myServerBattleNet;

class Program
{
    public static async Task Main()
    {
        var server = new HttpServer();
        await server.RunServer();
        Console.ReadKey();
    }
}