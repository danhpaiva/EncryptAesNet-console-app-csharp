using EncryptAesApp.Action;
using EncryptAesApp.Models;
using static System.Console;

do
{
    WriteLine("Insira o dado a ser Encryptado...");
    Data data = new()
    {
        Message = Console.ReadLine()
    };
    EncryptData.EncryptAesManaged(data.Message);

    WriteLine("\n\tAperte a tecla 'q' + 'Enter' para sair do programa." +
        "\n\tSe deseja continuar aperte 'Enter'.");
    string letra = ReadLine().ToLower();
    if (letra == "q") { break; }
}
while (true);

WriteLine("\nAté breve!");