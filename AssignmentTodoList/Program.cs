// See https://aka.ms/new-console-template for more information

List<string> todos = new List<string>();

bool isExit = false;
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo?");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");
    var inputOptionRaw = Console.ReadLine();
    bool isValidOption;
    string inputOption = GetUserInput(inputOptionRaw, out isValidOption);
    if (!isValidOption)
    {
        Console.WriteLine("Invalid choice");
        continue;
    }
    
    switch (inputOption)
    {
        case "S":
            SeeAllTodos();
            break;
        case "A":
            AddTodo();
            break;
        case "R":
            RemoveTodo();
            break;
        case "E":
            isExit = true;
            break;
    }
    
} while (!isExit);

string GetUserInput(string input, out bool isValid)
{
    isValid = true;
    string result = "";
    string[] matchCase = new[] { "S", "A", "R", "E" };
    if (string.IsNullOrEmpty(input))
    {
        isValid = false;
    }
    else
    {
        result = input.ToUpper();
        if (!matchCase.Contains(result))
        {
            isValid = false;
        }
    }

    return result;
}

void SeeAllTodos()
{
    if (!todos.Any())
    {
        Console.WriteLine("There is no todo");
        return;
    }

    for (int i = 0; i < todos.Count(); i++)
    {
        Console.WriteLine($"{i+1}. {todos[i]}");
    }
}

void AddTodo()
{
    
    bool isExit = false;
    do
    {
        Console.WriteLine("Enter the todo description:");
        var inputTodo = Console.ReadLine();    
        if (string.IsNullOrEmpty(inputTodo))
        {
            Console.WriteLine("The description is required");
            continue;
        }

        if (todos.Contains(inputTodo))
        {
            Console.WriteLine("The description must be unique");
            continue;
        }
        todos.Add(inputTodo);
        Console.WriteLine($"Todo successfully added: {inputTodo}");
        isExit = true;
    } while (!isExit);
}


void RemoveTodo()
{
    bool isExit = false;
    if (!todos.Any())
    {
        Console.WriteLine("There is no todo");
        return;
    }
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        SeeAllTodos();
        var inputIndex = Console.ReadLine();


        if (int.TryParse(inputIndex, out int removeIndex))
        {
            if (removeIndex > todos.Count() || removeIndex <= 0)
            {
                Console.WriteLine("Invalid index");
                continue;
            }

            int todoIndex = removeIndex - 1;

            var todo = todos[todoIndex];
            todos.RemoveAt(removeIndex);
            Console.WriteLine($"Todo removed: {todo}");
            isExit = true;
        }
        else
        {
            Console.WriteLine("Invalid index");
        }
    } while (!isExit);
}