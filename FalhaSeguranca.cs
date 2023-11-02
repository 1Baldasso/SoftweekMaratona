namespace SoftweekMaratona;

public class FalhaSeguranca : Problema
{
    protected override string Name => "Falha de Segurança";

    protected override string Description => """
                Rafael foi contratado como programador por um grande banco que está atualizando
        todo o sistema computacional. O novo sistema vai ser instalado amanhã, mas Rafael
        acabou de descobrir uma falha grave na nova autenticação para acesso às contas do
        banco: se um usuário digitar como senha uma cadeia de caracteres que contenha, como
        sub-cadeia contígua, a senha correta para esse usuário, o sistema se confunde e permite o
        acesso.
        Por exemplo, se a senha correta é 'senhafraca' e o usuário digitar
        `quesenhafracameu' ou `senhafraca123', o sistema permite o acesso. Note que nesse caso
        o sistema não permite o acesso se o usuário digitar `senha' ou `nhafra' ou `senha123fraca'.
        O chefe de Rafael chamou um programador mais experiente para alterar a autenticação do
        novo sistema, mas solicitou que Rafael determinasse, para o conjunto de senhas existentes,
        quantos pares ordenados (A,B) de usuários distintos existem tal que o usuário A, usando
        sua senha, consegue acesso à conta do usuário B. Você poderia por favor ajudar Rafael?
        """;

    protected override string[] Inputs => new[] { """
        3
        xxx
        x23
        xx
        """,
        """
        3
        a
        a
        a8
        """,
        """
        5
        jus
        justa
        ta
        us
        t
        """
    };

    protected override string[] Outputs => new[] { "1", "4", "6" };

    public override void Run(bool showDesc = false)
    {
        List<string> result = new();
        foreach (var item in Inputs)
        {
            var input = item.Split("\n");
            var n = int.Parse(input[0]);
            var senhas = input[1..];
            if (senhas.Length != n)
            {
                Console.WriteLine("Entrada Incorreta");
            }
            result.Add(Solution(senhas.Select(x => x.Replace("\r", "")).ToArray()));
        }
        base.Run(result.ToArray(), showDesc);
    }

    private string Solution(string[] senhas)
    {
        Func<char, bool> isNumber = x => x >= 48 && x <= 57;
        Func<char, bool> isLower = x => x >= 97 && x <= 122;
        Func<char, bool> combined = x => isNumber(x) || isLower(x);
        if (senhas.Any(x => x.Length > 20) || !senhas.All(x => x.All(combined)))
        {
            return "Entrada Incorreta";
        }
        int count = 0;
        foreach (var senha in senhas)
        {
            var senhasCorrespondentes = senhas.Where(x => x.Contains(senha)).ToArray();
            count += senhasCorrespondentes.Length - 1;
        }
        return count.ToString();
    }
}