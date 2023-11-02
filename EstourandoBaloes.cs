namespace SoftweekMaratona;

public class EstourandoBaloes : Problema
{
    protected override string Name => "Estourando Balões";

    protected override string Description => """
                Um enorme número de balões estão flutuando no Salão de Convenções após a Cerimônia
        de Premiação do Concurso Subregional da ICPC. O gerente do Salão de Convenções está
        irritado, porque ele vai sediar outro evento amanhã e os balões devem ser removidos.
        Felizmente este ano Carlinhos veio preparado com seu arco e flechas para estourar os
        balões. Além disso, felizmente, devido ao fluxo de ar condicionado, os balões estão todos
        no mesmo plano vertical (ou seja, um plano paralelo a uma parede), embora em alturas e
        posições distintas. Carlinhos vai atirar do lado esquerdo do salão de convenções, a uma
        altura escolhida, na direção do lado direito do Salão de Convenções. Cada flecha se move
        da esquerda para a direita, na altura em que foi atirada, no mesmo plano vertical dos
        balões. Quando uma flecha toca um balão, o balão estoura e a flecha continua seu
        movimento para a direita, a uma altura diminuída por 1. Em outras palavras, se a flecha
        estava na altura H, após estourar um balão ela continua na altura H-1. Carlinhos quer
        estourar todos os balões atirando o mínimo de flechas possível. Você pode ajudá-lo?
        """;

    protected override string[] Inputs => new[]{ """
        5
        3 2 1 5 4
        """,
        """
        4
        1 2 3 4
        """,
        """
        6
        5 3 2 4 6 1
        """
    };

    protected override string[] Outputs => new[] { "2", "4", "3" };
    private int count;

    public override void Run(bool showDesc = false)
    {
        List<string> result = new();
        foreach (var item in Inputs)
        {
            count = 0;
            var input = item.Split("\n");
            var n = int.Parse(input[0]);
            var baloes = input[1].Split(" ").Select(x => int.Parse(x)).ToArray();
            if (baloes.Length != n)
            {
                Console.WriteLine("Entrada Incorreta");
            }
            Solution(baloes);
            result.Add(count.ToString());
        }
        base.Run(result.ToArray(), showDesc);
    }

    private void Solution(int[] baloes)
    {
        List<int> rest = new();
        int max = baloes.Max();
        count++;
        for (int i = 0; i < baloes.Length; i++)
        {
            if (baloes[i] == max)
            {
                max--;
            }
            else
            {
                rest.Add(baloes[i]);
            }
        }
        if (rest.Count > 0)
        {
            Solution(rest.ToArray());
        }
    }
}