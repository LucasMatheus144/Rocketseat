class Program
{

    static void Main()
    {
        Console.WriteLine("Digite a numeração da placa:");
        var x = Console.ReadLine();

        bool valida = ValidaPlaca(x);

        if (valida)
        {
            Console.WriteLine("A placa é valida");
        }
        else
        {
            Console.WriteLine("Não é valido");
        }
        
        static bool ValidaPlaca(string x)
        {
            if (string.IsNullOrEmpty(x) && x.Length != 7)
            {
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(x[i])) //se são letras os 3 primeiros digitos
                    return false;
            }
            for (int i = 3; i < 7; i++)
            {
                if (!char.IsDigit(x[i])) // se nao numeros os 4 ultimos digitas
                    return false;
            }
            return true;
        }

    }
}


