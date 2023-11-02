using SoftweekMaratona;

Problema[] problemas = new Problema[]
{
    new Bondinho(),
    new PilotoAutomatico(),
    new Montanha(),
    new Onibus(),
    new FalhaSeguranca(),
    new EstourandoBaloes(),
    new FibonacciQuantasChamadas(),
};

foreach (var problema in problemas)
{
    problema.Run();
}