using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace SoftweekMaratona;

public class Onibus : Problema
{
    protected override string Name => "Onibus";

    protected override string Description => """
                A Linearlândia é composta de N cidades, numeradas de 1 até N. Para alguns pares
        de cidades existe uma linha de ônibus que faz o trajeto de ida e volta diretamente entre as
        duas cidades do par. Os pares de cidades ligados diretamente por uma linha de ônibus são
        escolhidos de forma que sempre é possível ir de qualquer cidade para qualquer outra
        cidade por um, e somente um, caminho (um caminho é uma sequência de linhas de ônibus,
        sem repetição).
        Dada a lista de pares de cidades ligados diretamente por linhas de ônibus, uma
        cidade origem e uma cidade destino, seu programa deve computar quantos ônibus é
        preciso pegar para ir da origem ao destino.
        """;

    protected override string[] Inputs => new[] {
        """
        4 2 4
        1 2
        2 3
        3 4
        """,
        """
        16 2 12
        3 5
        12 3
        5 1
        2 1
        4 1
        6 1
        7 1
        12 8
        12 9
        12 10
        12 11
        3 13
        13 14
        15 13
        15 16
        """
    };

    protected override string[] Outputs => new[] { "2", "4" };

    private List<Conexao> Conexoes = new();

    private int Origem;
    private int Destino;
    private int count = 0;

    public override void Run(bool showDesc = false)
    {
        List<string> responses = new();
        foreach (var a in Inputs)
        {
            string[] lines = a.Split("\n");
            int[] firstLineNumbers = lines[0].Split(" ").Select(int.Parse).ToArray();
            int tamanhoCidade = firstLineNumbers[0];
            Origem = firstLineNumbers[1];
            Destino = firstLineNumbers[2];
            foreach (var line in lines[1..])
            {
                int[] numbers = line.Split(" ").Select(int.Parse).ToArray();
                Conexoes.Add(new Conexao(numbers[0], numbers[1]));
            }
            count = 0;
            responses.Add(Solution());
        }
        base.Run(responses.ToArray(), showDesc);
    }

    private string Solution()
    {
        if (Origem == Destino)
        {
            return "0";
        }
        var conexoesOrigem = Conexoes.Where(x => x.Equals(Origem) && !x.Visited);
        VisitNodes(conexoesOrigem);
        return count.ToString();
    }

    private bool VisitNodes(IEnumerable<Conexao> conexoes, int origem = -1)
    {
        if (origem == -1)
        {
            origem = Origem;
        }
        foreach (var conexao in conexoes)
        {
            if (CurrentNode(conexao, origem))
            {
                count++;
                return true;
            }
        }
        return false;
    }

    private bool CurrentNode(Conexao conn, int origem)
    {
        conn.Visited = true;
        var other = conn.Other(origem);
        if (other == Destino)
        {
            return true;
        }

        var connections = Conexoes.Where(x => x.Equals(other) && !x.Visited).ToList();
        return VisitNodes(connections, other);
    }

    public class Conexao : IEquatable<int>
    {
        public int A { get; }
        public int B { get; }
        public bool Visited { get; set; }

        public Conexao(int a, int b)
        {
            A = a;
            B = b;
            Visited = false;
        }

        public bool Equals(int other)
        {
            return this.A == other || this.B == other;
        }

        public int Other(int origem)
        {
            return this.A == origem ? this.B : this.A;
        }

        public override string ToString()
        {
            return $"{A} {B} {Visited}";
        }
    }
}