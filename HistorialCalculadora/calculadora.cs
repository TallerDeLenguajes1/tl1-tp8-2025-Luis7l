namespace CalculadoraHistorial;
public enum TipoOperacion
{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar
}
public class Operacion
{
    private List<Operacion> historial;
    private TipoOperacion tipoOperacion;
    public TipoOperacion TipoOperacion => tipoOperacion;

    // Valor de la operación, que puede ser un número a sumar, restar, multiplicar o dividir.
    // En el caso de "Limpiar", este valor no se utiliza.
    private double valor;

    public Operacion(List<Operacion> historial, TipoOperacion tipoOperacion, double valor)
    {
        this.historial = historial;
        this.tipoOperacion = tipoOperacion;
        this.valor = valor;
    }

    public void RealizarOperacion()
    {
        double resultado = tipoOperacion switch
        {
            TipoOperacion.Suma => historial.Sum(op => op.Resultado) + valor,
            TipoOperacion.Resta => historial.Sum(op => op.Resultado) - valor,
            TipoOperacion.Multiplicacion => historial.Aggregate(1.0, (acc, op) => acc * op.Resultado) * valor,
            TipoOperacion.Division => historial.Count > 0 && valor != 0 ? historial.Sum(op => op.Resultado) / valor : double.NaN,
            TipoOperacion.Limpiar => 0,
            _ => double.NaN
        };

        historial.Add(new Operacion(historial, tipoOperacion, resultado));
    }

    public double Resultado => tipoOperacion switch
    {
        TipoOperacion.Suma => valor,
        TipoOperacion.Resta => -valor,
        TipoOperacion.Multiplicacion => 0,
        TipoOperacion.Division => 0,
        TipoOperacion.Limpiar => 0,
        _ => double.NaN
    };
}