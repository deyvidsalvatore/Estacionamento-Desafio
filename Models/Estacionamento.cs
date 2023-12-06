namespace EstacionamentoDesafio
{
    class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = [];

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();

            try
            {
                VerificarPlacaExistente(placa);
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string? placa = Console.ReadLine();

            try
            {
                VerificarPlacaInexistente(placa);

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());

                // Calcular o valor total
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Exibir os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private void VerificarPlacaExistente(string? placa)
        {
            if (veiculos.Any(x => x.ToUpper() == placa?.ToUpper()))
            {
                throw new ArgumentException("Veículo com essa placa já está estacionado.");
            }
        }

        private void VerificarPlacaInexistente(string? placa)
        {
            if (!veiculos.Any(x => x.ToUpper() == placa?.ToUpper()))
            {
                throw new ArgumentException("Veículo com essa placa não está estacionado.");
            }
        }
    }
}