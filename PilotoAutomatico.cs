namespace SoftweekMaratona;

public class PilotoAutomatico : Problema
{
    protected override string Name => "Piloto Automático";

    protected override string Description => """
                Uma grande fábrica de carros elétricos está realizando melhorias no sistema de
        piloto automático e precisa da sua ajuda para implementar um programa que decida se um
        carro B, que está trafegando no meio de dois carros A e C, precisa acelerar, desacelerar ou
        manter a velocidade atual. Os carros são iguais e os sensores do piloto automático vão
        fornecer, como entrada, a posição atual da traseira dos três carros. Veja um exemplo na
        figura.
        O carro B precisa ser acelerado se a distância da sua traseira para a traseira do
        carro A for menor do que a distância da sua traseira para a traseira do carro C. Se for maior,
        ele precisa ser desacelerado. Se for igual, precisa manter a velocidade atual. Quer dizer, o
        carro B precisa ser acelerado se (B-A) < (C-B), desacelerado se (B-A) > (C-B) e manter a
        velocidade se (B-A) for igual a (C-B).
        """;

    protected override string[] Inputs => new[] { "10\n23\n38", "105\n212\n319", "80\n120\n132" };

    protected override string[] Outputs => new[] { "1", "0", "-1" };

    public override void Run(bool showDesc = false)
    {
        List<string> responses = new();
        foreach (var item in Inputs)
        {
            var input = item.Split("\n");
            var a = int.Parse(input[0]);
            var b = int.Parse(input[1]);
            var c = int.Parse(input[2]);
            responses.Add(Solution(a, b, c));
        }
        base.Run(responses.ToArray(), showDesc);
    }

    private string Solution(int a, int b, int c)
    {
        if (a < 0 || b < 0 || c < 0 || a > 500 || b > 500 || c > 500 || a > b || b > c || a > c)
        {
            return "Entrada Incorreta";
        }
        return (b - a) < (c - b) ? "1" : (b - a) > (c - b) ? "-1" : "0";
    }
}