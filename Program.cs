namespace PasteBinSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = PasteBin.Create("Hello World, from PasteBinSample!").Result;
            Console.WriteLine(url);
        }
    }
}