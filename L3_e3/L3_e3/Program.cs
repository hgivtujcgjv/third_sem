
using System.Globalization;

StartProgram();
CurrencyEur wallet1 = new CurrencyEur(150);
CurrencyUSD wallet2 = wallet1;
CurrencyRub wallet3 = (CurrencyEur)wallet1;
Console.WriteLine(wallet3.Value);
void StartProgram()
{
    Console.WriteLine("Введите рубль , доллар , евро ");
    string? curs = Console.ReadLine();
    string[]? curs1 = curs.Split(" ");
    double.TryParse(curs1[0], out double number1);
    double.TryParse(curs1[1], out double number2);
    double.TryParse(curs1[2], out double number3);
    Console.WriteLine($"{number1}, {number2}, {number3}");
    Curency.E_curs = number3;
    Curency.R_curs = number1;
    Curency.D_curs = number2;
}
class Curency {
    double money;
    public static double E_curs;
    public static double D_curs;
    public static double R_curs;
    public Curency() { }
    public Curency(double money)
    {
        this.money = money;
    }
    public double Value {
        get { return money; }
        set { money = value; }
}

}

class CurrencyUSD : Curency {
    public CurrencyUSD(double money) : base(money)
    {
    }

    public static explicit operator CurrencyUSD(CurrencyEur? other = null) => new CurrencyUSD(other.Value*E_curs/R_curs);
    public static explicit operator CurrencyUSD(CurrencyRub? other = null)
    {
        return new CurrencyUSD(other.Value*R_curs);
    }
    public static implicit operator CurrencyRub(CurrencyUSD? other = null) => new CurrencyRub(other.Value * R_curs);
    public static implicit operator CurrencyEur(CurrencyUSD? other = null)
    {
        return new CurrencyEur(other.Value * R_curs / E_curs);
    }

}

class CurrencyEur : Curency
{
    double Eur;
    public CurrencyEur(double money) : base(money)
    {
        Eur = money;
    }
    public static explicit operator CurrencyEur(CurrencyUSD? other = null)
    {
        return new CurrencyEur(other.Value*R_curs/E_curs);
    }
    public static explicit operator CurrencyEur(CurrencyRub? other = null)
    {
        return new CurrencyEur(other.Value * E_curs / R_curs);
    }
    public static implicit operator CurrencyUSD(CurrencyEur? other = null) => new CurrencyUSD(other.Value * E_curs / R_curs);
    public static implicit operator CurrencyRub(CurrencyEur? other = null)
    {
        return new CurrencyRub(other.Value * E_curs/R_curs);
    }
}

class CurrencyRub : Curency
{
    double Rub;
    public CurrencyRub(double money) : base(money)
    {
        Rub = money;
    }
    public static explicit operator CurrencyRub(CurrencyEur? other = null)
    {
        return new CurrencyRub(other.Value*E_curs);
    }
    public static explicit operator CurrencyRub(CurrencyUSD? other = null)
    {
        return new CurrencyRub(other.Value*D_curs);
    }
    public static implicit operator CurrencyUSD(CurrencyRub? other = null) => new CurrencyUSD(other.Value * D_curs /R_curs);
    public static implicit operator CurrencyEur(CurrencyRub? other = null)
    {
        return new CurrencyEur(other.Value * E_curs/R_curs);
    }
}
