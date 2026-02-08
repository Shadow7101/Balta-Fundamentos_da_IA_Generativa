using OllamaSharp;


var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri);

var models = await ollama.ListLocalModelsAsync();

foreach (var model in models)
{
    Console.WriteLine($"Model Name: {model.Name}");
}


ollama.SelectedModel = "phi3:latest";

var chat = new Chat(ollama);


while (true)
{
    Console.WriteLine("Digite sua mensagem (ou 'sair' para encerrar):");
    var prompt = Console.ReadLine() ?? string.Empty;
    
    if (prompt.ToLower() == "sair")
    {
        break;
    }

    await foreach (var resposta in chat.SendAsync(prompt))
    {
        Console.Write(resposta);
    }


    Console.WriteLine("\n\nConversa encerrada.");
    Console.ReadKey();
    Console.Clear();
}