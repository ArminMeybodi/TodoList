
bool shallExit = false;
var todos = new List<string>();

while (!shallExit)
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");

    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "E":
        case "e":
            shallExit = true;
            break;
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        default:
            break;
    }
}

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }

    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Enter TODO description:");
        description = Console.ReadLine();
    }
    while (!IsDescriptionValid(description));

    todos.Add(description);
}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("description cannot be empry");
        return false;
    }
    else if (todos.Contains(description))
    {
        Console.WriteLine("description must be unique");
        return false;
    }
    return true;
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodos();
    }
    while (!TryReadIndex(out index));
    RemoveTodoAtIndex(index - 1);
}

void RemoveTodoAtIndex(int index)
{
    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToBeRemoved);
}

bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }
    if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
    {
        return true;
    }
    Console.WriteLine("The given index is not valid.");
    return false;
}

static void ShowNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}