using EncryptAesApp.Action;
using EncryptAesApp.Models;

do
{
    Console.WriteLine("Insira o dado a ser Encryptado...");
    Data data = new()
    {
        message = Console.ReadLine()
    };
    EncryptData.EncryptAesManaged(data.message);

    Console.WriteLine("\n\tAperte a tecla 'q' + 'Enter' para sair do programa.\n\tSe deseja continuar aperte 'Enter'.");
    string letra = Console.ReadLine().ToLower();
    if (letra == "q") { break; }
}
while (true);

Console.WriteLine("\nAté breve!");