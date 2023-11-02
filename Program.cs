using DesafioDio.Models;

Console.Write("Digite o Valor do Preço Inicial: ");
decimal precoInicial = decimal.Parse(Console.ReadLine());

Console.Write("Digite o Valor do Preço Por Hora: ");
decimal precoPorhora = decimal.Parse(Console.ReadLine());

Estacionamento estacionamento = new(precoInicial, precoPorhora);
Console.Clear();
estacionamento.Menu();