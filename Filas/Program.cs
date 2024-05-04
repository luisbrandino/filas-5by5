using Filas;

Queue[] queues = new Queue[2] { new Queue(), new Queue() };

populateQueue(queues[0]);
populateQueue(queues[1]);

int inputInteger(string message, int? min = null, int? max = null)
{
    Console.Write(message);
    int value = int.Parse(Console.ReadLine());

    while (true)
    {
        bool correctValue = (min != null ? value >= min : true) && (max != null ? value <= max : true);

        if (correctValue)
            break;

        string invalid = min != null ? $"Valor precisa ser maior ou igual a {min}" : "";
        invalid += invalid == "" ? "Valor precisa ser " : " e ";
        invalid += max != null ? $"menor ou igual a {max}" : "";
        invalid += ": ";

        Console.Write(invalid);
        value = int.Parse(Console.ReadLine());
    }

    return value;
}

void waitForAnyKey()
{
    Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

void populateQueue(Queue queue)
{
    int length = new Random().Next(5, 15);

    for (int i = 0; i < length; i++)
        queue.Enqueue(new Random().Next(-50, 50));
}

void quantityOfEven()
{
    int index = selectQueueMenu();
    Queue queue = queues[index];

    Console.Clear();

    Console.WriteLine($"Quantidade de números pares da fila {index + 1}: {queue.EvenCount()}");

    waitForAnyKey();
}

void quantityOfOdd()
{
    int index = selectQueueMenu();
    Queue queue = queues[index];

    Console.Clear();

    Console.WriteLine($"Quantidade de números ímpares da fila {index + 1}: {queue.OddCount()}");

    waitForAnyKey();
}

void transferSelectedQueueToNewQueue()
{
    int index = selectQueueMenu();
    Queue queue = queues[index];

    Queue clonedQueue = queue.Clone();

    Console.Clear();

    Console.WriteLine($"Nova fila baseada na fila {index + 1}:");
    clonedQueue.Display();

    waitForAnyKey();
}

void displayQueueSummary()
{
    int index = selectQueueMenu();
    Queue queue = queues[index];

    Console.Clear();

    Console.WriteLine($"Estatísticas da fila {index + 1}:\n");

    Console.WriteLine($"Maior elemento: {queue.Max()}");
    Console.WriteLine($"Menor elemento: {queue.Min()}");
    Console.WriteLine($"Média: {queue.Average().ToString("0.0")}");

    waitForAnyKey();
}

void compareQueues()
{
    int indexA = selectQueueMenu();
    int indexB = selectQueueMenu();

    Console.Clear();

    Queue queueA = queues[indexA];
    Queue queueB = queues[indexB];

    if (queueA.Equals(queueB))
        Console.WriteLine($"Fila {indexA + 1} e fila {indexB + 1} são iguais");
    else if (queueA.Count() > queueB.Count())
        Console.WriteLine($"Fila {indexA + 1} é maior que fila {indexB + 1}");
    else
        Console.WriteLine($"Fila {indexA + 1} é menor que fila {indexB + 1}");

    waitForAnyKey();
}

void displayQueue()
{
    int index = selectQueueMenu();
    Queue queue = queues[index];
    Console.Clear();

    Console.WriteLine($"Fila {index + 1}:");
    queue.Display();
    waitForAnyKey();
}

int selectQueueMenu()
{
    Console.Clear();
    for (int i = 0; i < queues.Length; i++)
        Console.WriteLine($"[ {i + 1} ] Fila {i + 1}");

    return inputInteger("Sua opção: ", min: 1, max: queues.Length) - 1;
}

int selectOperationMenu()
{
    Console.Clear();
    Console.WriteLine("[ 1 ] Imprimir fila\n[ 2 ] Comparar filas\n[ 3 ] Maior, menor e média aritmética\n[ 4 ] Transferir elementos de uma fila para uma nova\n[ 5 ] Quantidade de pares\n[ 6 ] Quantidade de ímpares\n[ 0 ] Sair");

    return inputInteger("Sua opção: ", min: 0, max: 6);
}

while (true)
{
    switch (selectOperationMenu())
    {
        case 1:
            displayQueue();
            break;
        case 2:
            compareQueues();
            break;
        case 3:
            displayQueueSummary();
            break;
        case 4:
            transferSelectedQueueToNewQueue();
            break;
        case 5:
            quantityOfEven();
            break;
        case 6:
            quantityOfOdd();
            break;
        default:
            Environment.Exit(0);
            break;
    }
}