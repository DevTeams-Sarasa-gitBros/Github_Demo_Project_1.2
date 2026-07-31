using TaskTracker.Services;

var service = new TaskService();
service.Create("Set up dev environment", "High");
service.Create("Read GitHub workshop slides", "Medium");

bool running = true;
while (running)
{
    // comment test
    Console.WriteLine();
    Console.WriteLine("=== Task Tracker ===");
    Console.WriteLine("1. List tasks");
    Console.WriteLine("2. Add task");
    Console.WriteLine("3. Rename task");
    Console.WriteLine("4. Toggle done");
    Console.WriteLine("5. Delete task");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option : "); //COMMENT VINKI

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            foreach (var task in service.GetAll())
                Console.WriteLine(task);
            break;

        case "2":
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? "";
            Console.Write("Priority (Low/Medium/High): ");
            var priority = Console.ReadLine() ?? "Medium";
            var created = service.Create(title, priority);
            Console.WriteLine($"Added task #{created.Id}");
            break;

        case "3":
            Console.Write("Task ID: ");
            var renameId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("New title: ");
            var newTitle = Console.ReadLine() ?? "";
            Console.WriteLine(service.UpdateTitle(renameId, newTitle) ? "Updated." : "Not found.");
            break;

        case "4":
            Console.Write("Task ID: ");
            var toggleId = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine(service.ToggleDone(toggleId) ? "Toggled." : "Not found.");
            break;

        case "5":
            Console.Write("Task ID: ");
            var deleteId = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine(service.Delete(deleteId) ? "Deleted." : "Not found.");
            break;

        case "6":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
