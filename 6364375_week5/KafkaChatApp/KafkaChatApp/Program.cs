using KafkaChatApp;

Console.WriteLine("1. Publisher\n2. Receiver\nChoose:");
var choice = Console.ReadLine();

if (choice == "1")
    await ChatPublisher.RunAsync();
else
    ChatReceiver.Run();
