using NewTalents;

namespace NewTalentsTests;

public class UnitTest1
{

    public Calculadora construirClasse(){

        string data = "15/10/2023";
        Calculadora calc = new Calculadora(data);
        return calc;
    }

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TestSoma(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Somar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (3, 2, 1)]
    [InlineData (4, 2, 2)]
    public void TestSubtracao(int num1, int num2, int resultado)
    {
        Calculadora calc =construirClasse();
        int resultadoCalculadora = calc.Subtrair(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (3, 2, 6)]
    [InlineData (4, 2, 8)]
    public void TestMultiplicacao(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Multiplicar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (8, 2, 4)]
    [InlineData (16, 2, 8)]
    public void TestDivisao(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Dividir(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestDivisaoPorZero()
    {
        Calculadora calc = construirClasse();

        Assert.Throws<DivideByZeroException>(() => 
            calc.Dividir(3, 0));
    }

    [Fact]
    public void TestHistorico()
    {
        Calculadora calc = construirClasse();

        calc.Somar(1, 2);
        calc.Somar(2, 8);
        calc.Somar(3, 7);
        calc.Somar(4, 1);

        var lista = calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);  
    }
}