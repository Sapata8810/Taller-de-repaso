using System;

public abstract class AbstractSample
{
    private string message;

    // Constructor para inicializar el mensaje
    public AbstractSample(string msg)
    {
        message = msg;
    }

    // Método abstracto
    public abstract void PrintMessage(string msg);

    // Método virtual: invierte el mensaje
    public virtual void InvertMessage(string msg)
    {
        char[] chars = msg.ToCharArray();
        Array.Reverse(chars);
        message = new string(chars);
        Console.WriteLine("Mensaje invertido: " + message);
    }

    // Método protegido para acceder al mensaje
    protected string GetMessage()
    {
        return message;
    }

    // Método protegido para modificar el mensaje
    protected void SetMessage(string msg)
    {
        message = msg;
    }
}

// Primera subclase: imprime el mensaje tal cual
public class SimplePrinter : AbstractSample
{
    public SimplePrinter(string msg) : base(msg) { }

    public override void PrintMessage(string msg)
    {
        Console.WriteLine("Mensaje original: " + GetMessage());
    }
}

// Segunda subclase: imprime el mensaje con mayúsculas y minúsculas invertidas
public class CaseInverterPrinter : AbstractSample
{
    public CaseInverterPrinter(string msg) : base(msg) { }

    public override void PrintMessage(string msg)
    {
        string transformed = "";
        foreach (char c in GetMessage())
        {
            if (char.IsUpper(c))
                transformed += char.ToLower(c);
            else if (char.IsLower(c))
                transformed += char.ToUpper(c);
            else
                transformed += c;
        }
        Console.WriteLine("Mensaje con mayúsculas/minúsculas invertidas: " + transformed);
    }

    // Sobrescribe InvertMessage para invertir y además cambiar mayúsculas por minúsculas
    public override void InvertMessage(string msg)
    {
        base.InvertMessage(msg); // primero invierte
        string lower = GetMessage().ToLower(); // luego pasa todo a minúsculas
        SetMessage(lower);
        Console.WriteLine("Mensaje invertido y en minúsculas: " + lower);
    }
}

// Clase principal que gestiona los objetos
class MessageManager
{
    public static void Main(string[] args)
    {
        // Instancia de la primera subclase
        AbstractSample printer1 = new SimplePrinter("Hola Mundo");
        printer1.PrintMessage("");
        printer1.InvertMessage("Hola Mundo");

        Console.WriteLine(); // separación visual

        // Instancia de la segunda subclase
        AbstractSample printer2 = new CaseInverterPrinter("Hola Mundo");
        printer2.PrintMessage("");
        printer2.InvertMessage("Hola Mundo");
    }
}
