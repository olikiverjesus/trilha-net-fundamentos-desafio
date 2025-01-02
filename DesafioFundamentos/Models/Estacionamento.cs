namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pedir para o usuário digitar a placa e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo que deseja estacionar (exemplo: ABC-1234):");
            string placa = Console.ReadLine()?.ToUpper(); // Lê a placa e a converte para maiúsculas

            // Adiciona a placa na lista de veículos
            if (!string.IsNullOrEmpty(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi adicionado ao estacionamento com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida! A placa não pode ser vazia. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo que deseja remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine()?.ToUpper(); // Lê a placa e converte para maiúsculas

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro válido de horas:");
                }

                // Realiza o cálculo do valor total
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remove o veículo da lista
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido com sucesso e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado! Verifique se a placa foi digitada corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados atualmente são:");
                // Exibe todos os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados no momento.");
            }
        }
    }
}
