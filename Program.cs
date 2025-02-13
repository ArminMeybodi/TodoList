﻿bool shallExit = false;
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
    }
    else
    {
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }
}

void AddTodo()
{
    bool isValidDescription = false;
    while (!isValidDescription)
    {
        Console.WriteLine("Enter TODO description:");
        var description = Console.ReadLine();
        if (IsDescriptionValid(description))
        {
            isValidDescription = true;
            todos.Add(description);
        }
    }
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

    bool isIndexValid = false;
    while (!isIndexValid)
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodos();
        var userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.WriteLine("Selected index cannot be empty");
            continue;
        }
        if (int.TryParse(userInput, out int index) && index >= 1 && index <= todos.Count)
        {
            var indexOfTodo = index - 1;
            var todoToBeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            isIndexValid = true;
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
        }
        else
        {
            Console.WriteLine("The given index is not valid.");
        }
    }
}

static void ShowNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}