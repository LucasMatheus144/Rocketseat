using System.Globalization;

class Program
{
    static void Main()
    {
        DateTime agora = DateTime.Now;

        Console.WriteLine("Selecione o formato de exibição da data:");
        Console.WriteLine("1 - Formato completo (dia da semana, dia do mês, mês, ano, hora, minutos, segundos)");
        Console.WriteLine("2 - Apenas a data no formato 'dd/MM/yyyy'");
        Console.WriteLine("3 - Apenas a hora no formato de 24 horas");
        Console.WriteLine("4 - A data com o mês por extenso");
        Console.WriteLine("Escolha uma opção (1-4):");

        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine(agora.ToString("dddd, dd 'de' MMMM 'de' yyyy, HH:mm:ss", new CultureInfo("pt-BR")));
                break;

            case "2":
                Console.WriteLine(agora.ToString("dd/MM/yyyy"));
                break;

            case "3":
                Console.WriteLine(agora.ToString("HH:mm:ss"));
                break;

            case "4":
                Console.WriteLine(agora.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-BR")));
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}