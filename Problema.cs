namespace SoftweekMaratona
{
    public abstract class Problema
    {
        protected abstract string Name { get; }
        protected abstract string Description { get; }
        protected abstract string[] Inputs { get; }
        protected abstract string[] Outputs { get; }

        public abstract void Run(bool showDesc = false);

        protected void Run(string[] responses, bool showDesc)
        {
            Console.WriteLine("Problema: " + Name);
            Console.WriteLine();
            if (showDesc)
            {
                Console.WriteLine("Descrição:");
                Console.WriteLine(Description);
                Console.WriteLine();
            }
            for (int i = 0; i < Inputs.Length; i++)
            {
                Console.WriteLine("Input:");
                Console.WriteLine(Inputs[i]);
                Console.WriteLine("Esperado/Resultado ");
                Console.WriteLine(Outputs[i] + "/" + responses[i]);
                Console.WriteLine("Correto: " + (Outputs[i] == responses[i] ? "Sim" : "Não"));
                Console.WriteLine();
            }
        }
    }
}