using System;

class Program
{
    static string FormatoHora(int segundosTotales)
    {
        int horas = segundosTotales / 3600;
        int minutos = (segundosTotales % 3600) / 60;
        int segundos = segundosTotales % 60;

        return $"{horas:D2}:{minutos:D2}:{segundos:D2}";
    }

    static void Main(string[] args)
    {
        int entradaSegundos = 3665; // ejemplo: 3665 segundos
        string resultado = FormatoHora(entradaSegundos);
        Console.WriteLine(resultado); // salida: 01:01:05
    }
}
