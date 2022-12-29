namespace Calcky;

public class Calculator
{
    public CalculatorLcd Lcd { get; set; }

    public bool AcceptInput(string s)
    {
        return false;
    }

    public void SendEqual()
    {
    }
}

public class CalculatorLcd
{
    public string Info { get; set; }
}
