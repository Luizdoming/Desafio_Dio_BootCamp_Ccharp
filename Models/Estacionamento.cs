namespace DesafioDio.Models;
/*Projeto Criado Por Luiz Domingo Da Silva 02/11/2023 - Desafio Dio.Io */
public class Estacionamento
{
    public decimal PrecoInicial { get; set; }
    public decimal PrecoPorhora { get; set; }
    public List<string> Veiculos = new();

    //Construtor Padr�o
    public Estacionamento() { }

    //Contrutor com Argumentos
    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.PrecoInicial = precoInicial;
        this.PrecoPorhora = precoPorHora;
    }
    public void AdcionarVeiculos()
    {
        try
        {
            Console.Write("Digite a Placa do veiculo Para Estacionar: ");
            string novoVeiculo = Console.ReadLine();

            if (novoVeiculo.Length <= 7 || novoVeiculo.Length > 8)
            {
                Console.WriteLine("Erro, Placa tem que ter 8 Caracteres Para Continuar o Cadastro...");
                Menu();
            }
            else
            {
                Veiculos.Add(novoVeiculo);
                Console.WriteLine("Veiculo Pronto Para Estacinar !\n");
                Menu();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Erro ao cadastrar veiculo, tente novamente.");
            Menu();
        }
    }

    public void RemoverVeiculos()
    {
        Console.Write("Digite a Placa do Veiculo que Deseja Remover. ");
        string placa = Console.ReadLine();

        if (Veiculos.Any(v => v.ToUpper() == placa.ToUpper()))
        {
            Console.Write("Digite Quantas Horas o Veiculo Ficou Estacionado ? ");
            int valuePerHours = int.Parse(Console.ReadLine());
            decimal valueTotal = this.PrecoInicial + this.PrecoPorhora * valuePerHours;
            Veiculos.Remove(placa);
            Console.WriteLine($"O veiculo de Placa {placa.ToUpper()} Foi Removido Com Sucesso, o Valor de Estacionamento foi de R${Math.Round(valueTotal, 2)}");
            Menu();
        }
        else
        {
            Console.WriteLine("Veiculo N�o Cadastrado em Nosso Estacionamento, Verifique a Placa por Favor...");
            Console.WriteLine("\n");
            Menu();
        }
    }

    public void ListarVeiculos()
    {
        if (Veiculos.Count <= 0)
        {
            Console.Write("Lista de Veiculos Vazia...");
            Menu();
        }
        else
        {
            Console.WriteLine("Veiculos Cadastrados...");
            Console.WriteLine($"Temos um Total de {Veiculos.Count} Veiculos cadastrado em nosso systema");
            Veiculos.ForEach(v => Console.WriteLine(v.ToUpper()));
            Console.WriteLine("\n");
            Menu();
        }
    }

    public void Menu()
    {
        string[] opcoes =
        {
            "[ 1 ] Para Adcionar Veiculos",
            "[ 2 ] Para Remover Veiculos",
            "[ 3 ] Para Listar Veiculos",
            "[ 4 ] Para Encerrar o Systema"
        };

        try
        {
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < opcoes.Length; i++)
            {
                Console.WriteLine($"{opcoes[i]}");
            }

            bool opcao = true;
            Console.WriteLine("---------------------------------\n");
            Console.Write("Selecione uma Op��o: ");

            while (opcao)
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        AdcionarVeiculos();
                        break;
                    case 2:
                        RemoverVeiculos();
                        break;
                    case 3:
                        ListarVeiculos();
                        break;
                    case 4:
                        Console.WriteLine("Encerrando o Systema...");
                        opcao = false;
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Escolha uma op��o v�lida...");
            Menu();
        }
        Console.ReadKey();
    }
}
