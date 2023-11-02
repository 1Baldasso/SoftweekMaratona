using System.Text;

namespace SoftweekMaratona;

public class FibonacciQuantasChamadas : Problema
{
    protected override string Name => "Fibonacci, Quantas Chamadas Recursivas?";

    protected override string Description => """
                Às vezes, quando você é um estudante de Ciência da Computação, verá um
        exercício ou um problema envolvendo a sequência de Fibonacci. Esta sequência tem os
        dois primeiros valores 0 (zero) e 1 (um) e cada próximo valor será sempre a soma dos dois
        números anteriores. Por definição, a fórmula para encontrar qualquer número de Fibonacci
        é:
        fib(0) = 0
        fib(1) = 1
        fib(n) = fib(n-1) + fib(n-2);
        Uma maneira de encontrar os números de Fibonacci é por meio de chamadas
        recursivas.
        """;

    protected override string[] Inputs => new[] { "5", "4" };

    protected override string[] Outputs => new[] { "14 5", "8 3" };

    private int count;

    public override void Run(bool showDesc = false)
    {
        List<string> result = new();
        foreach (var item in Inputs)
        {
            int n = int.Parse(item);
            result.Add(Solution(n));
        }
        base.Run(result.ToArray(), showDesc);
    }

    private string Solution(int n)
    {
        count = -1; //Isso é feito porque a primeira chamada não é recursiva
        var result = Fib(n);
        return $"{count} {result}";
    }

    private int Fib(int n)
    {
        count++;
        if (n < 0)
        {
            throw new ArgumentException("n deve ser maior ou igual a 0", nameof(n));
        }
        if (n < 2)
        {
            return n;
        }
        return Fib(n - 1) + Fib(n - 2);
    }
}