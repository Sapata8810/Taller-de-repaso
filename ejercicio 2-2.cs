using System;

public class ChanceGame
{
    public static int CalcularPremio(int apuesta, string numeroJugado, string numeroSorteo)
    {
        if (numeroJugado.Length != 4 || numeroSorteo.Length != 4)
            throw new ArgumentException("Los números deben tener exactamente 4 dígitos.");

        // Caso 1: Acierta las 4 cifras en orden
        if (numeroJugado == numeroSorteo)
            return apuesta * 4500;

        // Caso 2: Acierta las 4 cifras en desorden
        char[] jugadoChars = numeroJugado.ToCharArray();
        char[] sorteoChars = numeroSorteo.ToCharArray();
        Array.Sort(jugadoChars);
        Array.Sort(sorteoChars);
        if (new string(jugadoChars) == new string(sorteoChars))
            return apuesta * 200;

        // Caso 3: Últimas 3 cifras en orden
        if (numeroJugado.Substring(1) == numeroSorteo.Substring(1))
            return apuesta * 400;

        // Caso 4: Últimas 2 cifras en orden
        if (numeroJugado.Substring(2) == numeroSorteo.Substring(2))
            return apuesta * 50;

        // Caso 5: Última cifra en orden
        if (numeroJugado[3] == numeroSorteo[3])
            return apuesta * 5;

        // No obtuvo premio
        return 0;
    }

    public static void Main()
    {
        int apuesta = 1000;
        string numeroJugado = "1234";
        string numeroSorteo = "4321";

        int premio = CalcularPremio(apuesta, numeroJugado, numeroSorteo);
        Console.WriteLine($"El premio obtenido es: ${premio}");
    }
}
