namespace Calcky.Test.TDD;

public class CalculatorTest
{
    [Fact]
    public void Test1()
    {
        Calculator calc = new Calculator();

        bool accepted = calc.AcceptInput("3 + 2");

        if (accepted)
        {
            var info = calc.Lcd.Info;  // Expect 3 + 2
            calc.SendEqual();
            var result = calc.Lcd.Info; // Expect 5
            
        }

    }
}
