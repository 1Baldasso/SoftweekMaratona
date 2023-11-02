using System.Security.Cryptography.X509Certificates;

namespace SoftweekMaratona;

public class Bondinho : Problema
{
    protected override string Name => "Bondinho";

    protected override string Description => """
                A turma do colégio vai fazer uma excursão na serra e todos os alunos e monitores
        vão tomar um bondinho para subir até o pico de uma montanha. A cabine do bondinho pode
        levar 50 pessoas no máximo, contando alunos e monitores, durante uma viagem até o pico.
        Neste problema, dado como entrada o número de alunos A e o número de monitores M,
        você deve escrever um programa que diga se é possível ou não levar todos os alunos e
        monitores em apenas uma viagem!
        """;

    protected override string[] Inputs => new[] { "10\n20", "12\n39", "49\n1" };

    protected override string[] Outputs => new[] { "S", "N", "S" };

    public override void Run(bool showDesc = false)
    {
        List<string> responses = new();
        foreach (var item in Inputs)
        {
            var input = item.Split("\n");
            var alunos = int.Parse(input[0]);
            var monitores = int.Parse(input[1]);
            responses.Add(Solution(alunos, monitores));
        }
        base.Run(responses.ToArray(), showDesc);
    }

    private string Solution(int alunos, int monitores)
    {
        if (alunos > 50 || monitores > 50 || alunos < 1 || monitores < 1)
        {
            return "Entrada Incorreta";
        }
        return alunos + monitores <= 50 ? "S" : "N";
    }
}