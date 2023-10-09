using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private readonly decimal _precoInicial;
    private readonly decimal _precoPorHora;
    private readonly List<string> _veiculos;

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        _precoInicial = precoInicial;
        _precoPorHora = precoPorHora;
        _veiculos = new List<string>();
    }

    public void AdicionarVeiculo()
    {
        _veiculos.Add(ObterPlaca());
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");
        var placa = ObterPlaca();

        if (_veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
        {
            int horas;
            while (true)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                var horasInput = Console.ReadLine();

                if (int.TryParse(horasInput, out horas))
                    break;
                else
                    Console.WriteLine($"Erro: {horasInput} não é válido.");
            }

            var valorTotal = _precoInicial + _precoPorHora * horas;

            _veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine(
                "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }

    public void ListarVeiculos()
    {
        if (_veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados são:");
            foreach (var veiculo in _veiculos) Console.WriteLine(veiculo);
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }

    private static string ObterPlaca()
    {
        string placa;
        while (true)
        {
            var padraoRegex = @"^[A-Z]{3}-\d{4}$";
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa não pode ser vazia.");
                Console.ReadLine();
                continue;
            }

            if (!Regex.IsMatch(placa, padraoRegex))
            {
                Console.WriteLine("A placa deve estar no formato AAA-1111.");
                Console.ReadLine();
                continue;
            }

            break;
        }

        return placa;
    }
}