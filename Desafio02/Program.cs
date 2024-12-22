Console.WriteLine("Digite o seu nome: ");
var nome = Console.ReadLine();

Console.WriteLine("Digite o seu sobrenome: ");
var sobrenome = Console.ReadLine();

var concatenacao = nome + ' ' +  sobrenome;

Console.WriteLine($"O nome concatenado seria {concatenacao}");