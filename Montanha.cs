namespace SoftweekMaratona;

public class Montanha : Problema
{
    protected override string Name => "Montanha";

    protected override string Description => """
                Um sistema de informações geográficas computadorizado está representando o
        perfil de uma montanha através de uma sequência de números inteiros, na qual não há dois
        números consecutivos iguais, como ilustrado na figura abaixo para três montanhas. Os
        números representam a altura da montanha ao longo de uma certa direção.
        O gerente do sistema de informações geográficas pesquisou e encontrou uma
        maneira de identificar se uma sequência de números inteiros representa uma montanha
        com mais de um pico, ou com apenas um pico. Ele observou que, como não há números
        consecutivos iguais, se houver três números consecutivos na sequência, tal que o número
        do meio é menor do que os outros dois números, então a montanha tem mais de um pico.
        Caso contrário, a montanha tem apenas um pico. De forma mais rigorosa, se a sequência é
        A=[A1, A2, A3, …, AN-2, A_N-1, AN], ele quer saber se há uma posição i, para 2 ≤ i ≤ N-1,
        tal que Ai-1 > Ai e Ai < Ai+1.
        Para ajudar o gerente, seu programa deve determinar, dada a sequência de
        números inteiros representando a montanha, se ela tem mais de um pico, ou se tem um
        pico apenas.
        """;

    protected override string[] Inputs => new[] { "8\n2 3 5 6 7 5 4 2", "8\n2 3 6 5 4 6 3 2" };

    protected override string[] Outputs => new[] { "N", "S" };

    public override void Run(bool showDesc = false)
    {
        List<string> resultados = new();
        foreach (var item in Inputs)
        {
            var largura = int.Parse(item.Split("\n")[0]);
            var montanha = item.Split("\n")[1].Split(" ").Select(x => int.Parse(x)).ToArray();
            resultados.Add(Solution(montanha));
        }
        base.Run(resultados.ToArray(), showDesc);
    }

    public string Solution(int[] montanha)
    {
        for (int i = 1; i < montanha.Length - 1; i++)
        {
            if (montanha[i] < montanha[i + 1] && montanha[i] < montanha[i - 1])
            {
                return "S";
            }
        }
        return "N";
    }
}