PasteBin Example C# .NET
========================

A quick example of posting text to PasteBin with an easy helper method.

Perfect for remote debugging!

Read the full tutorial: [Remote Debugging with Pastebin and Automatic Logging of Errors](https://www.primaryobjects.com/2011/09/12/remote-debugging-with-pastebin-and-automatic-logging-of-errors/)

*Note, this version is for VSCode. See the Visual Studio .sln version [here](https://github.com/primaryobjects/PasteBin-Auto-Post).*

## Usage

1. In VSCode, open the project folder and open a new Terminal window and type the following command:

    ```bash
    dotnet add package System.Configuration.ConfigurationManager
    ```

2. Edit App.config to add your pastebin [API key](https://pastebin.com/doc_api#1).

3. Run the helper method with the following code:

    ```cs
    string url = PasteBin.Create("Hello World, from PasteBinSample!").Result;
    Console.WriteLine(url);
    ```

    ```bash
    dotnet run
    ```

4. The result is a url on pastebin containing the posted message.

## License

MIT

## Author

Kory Becker http://www.primaryobjects.com/kory-becker
