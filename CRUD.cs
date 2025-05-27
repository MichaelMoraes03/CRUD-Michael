using System;
using System.Collections.Generic;

namespace VetSmartCRUD
{
    class Pets
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public int Peso { get; set; }
        public char Sexo { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<int, Pets> pets = new Dictionary<int, Pets>();
            int proximoId = 1;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n MENU VET SMART");
                Console.WriteLine("1. Adicionar Pets");
                Console.WriteLine("2. Listar Pets");
                Console.WriteLine("3. Atualizar Pets");
                Console.WriteLine("4. Deletar Pets");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Criar(pets, ref proximoId);
                        break;
                    case "2":
                        Ler(pets);
                        break;
                    case "3":
                        Atualizar(pets);
                        break;
                    case "4":
                        Excluir(pets);
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static string LerTextoValido(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && SomenteLetras(entrada))
                    return entrada;
                else
                    Console.WriteLine("Entrada inválida. Digite apenas letras.");
            }
        }

        static bool SomenteLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        static void Criar(Dictionary<int, Pets> pets, ref int proximoId)
        {
            string nome = LerTextoValido("Digite o nome do seu Pet: ");

            Console.Write("Digite o sexo do seu Pet (M/F): ");
            char sexo = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (sexo != 'M' && sexo != 'F')
            {
                Console.WriteLine("Sexo inválido. Por favor, insira 'M' ou 'F'.");
                return;
            }

            Console.WriteLine("\n MENU DE ESPÉCIES");
            Console.WriteLine("1. Cachorros");
            Console.WriteLine("2. Gatos");
            Console.WriteLine("3. Serpentes");
            Console.Write("Escolha uma opção:  ");
            string especie = "";
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": especie = "Cachorros"; break;
                case "2": especie = "Gatos"; break;
                case "3": especie = "Serpentes"; break;
                default:
                    Console.WriteLine("Tipo inválido. Refaça o cadastro.");
                    return;
            }

            Dictionary<string, string[]> racasPorEspecie = new Dictionary<string, string[]>
            {
                { "Cachorros", new [] { "Rottweiler", "Doberman", "Pitbull Terrier", "Pastor Alemão", "Dogo Argentino", "Dálmata", "Pinscher", "SRD" } },
                { "Gatos", new [] { "Siamês", "Persa", "Sphynx", "Maine Coon", "Siberiano", "SRD" } },
                {"Serpentes", new [] { "Jiboia Arco-Íris do Cerrado", "Jiboia Arco-Íris do Norte", "Jiboia Arco-Íris da Caatinga", "Jiboia (BCC)" } }
            };

            string[] racas = racasPorEspecie[especie];
            for (int i = 0; i < racas.Length; i++)
                Console.WriteLine($"{i + 1}. {racas[i]}");
            Console.Write("Escolha uma opção de raça: ");

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > racas.Length)
            {
                Console.WriteLine("Raça inválida. Refaça o cadastro.");
                return;
            }
            string raca = racas[index - 1];

            double peso;
            while (true)
            {
                Console.Write("Digite o peso do seu PET em KG: ");
                if (double.TryParse(Console.ReadLine(), out peso))
                    break;
                Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
            }

            Pets novoPet = new Pets
            {
                Id = proximoId,
                Nome = nome,
                Especie = especie,
                Raca = raca,
                Peso = (int)peso,
                Sexo = sexo
            };
            pets.Add(proximoId, novoPet);
            Console.WriteLine($"Pet cadastrado com ID: {proximoId}");
            proximoId++;
        }

        static void Ler(Dictionary<int, Pets> pets)
        {
            Console.WriteLine("\n LISTA DE PETS CADASTRADOS ");
            if (pets.Count == 0)
            {
                Console.WriteLine("Nenhum pet cadastrado.");
                return;
            }
            foreach (var item in pets)
            {
                int id = item.Key;
                Pets pet = item.Value;

                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Nome: {pet.Nome}");
                Console.WriteLine($"Espécie: {pet.Especie}");
                Console.WriteLine($"Raça: {pet.Raca}");
                Console.WriteLine($"Peso: {pet.Peso} kg");
                Console.WriteLine($"Sexo: {pet.Sexo}\n");
            }
        }

        static void Atualizar(Dictionary<int, Pets> pets)
        {
            Console.Write("Digite o ID do pet que deseja atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id) && pets.ContainsKey(id))
            {
                Pets pet = pets[id];
                Console.WriteLine($"Atualizando Pet: {pet.Nome}");

                Console.Write("Novo nome (deixe em branco para manter): ");
                string novoNome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoNome) && SomenteLetras(novoNome))
                    pet.Nome = novoNome;

                Console.Write("Novo peso (deixe em branco para manter): ");
                string novoPesoStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoPesoStr) && double.TryParse(novoPesoStr, out double novoPeso))
                    pet.Peso = (int)novoPeso;

                Console.Write("Nova espécie (deixe em branco para manter): ");
                string novaEspecie = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaEspecie) && SomenteLetras(novaEspecie))
                    pet.Especie = novaEspecie;

                Console.Write("Nova raça (deixe em branco para manter): ");
                string novaRaca = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaRaca) && SomenteLetras(novaRaca))
                    pet.Raca = novaRaca;

                Console.Write("Novo sexo (M/F - deixe em branco para manter): ");
                string novoSexoStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoSexoStr))
                {
                    char novoSexo = char.ToUpper(novoSexoStr[0]);
                    if (novoSexo == 'M' || novoSexo == 'F')
                        pet.Sexo = novoSexo;
                    else
                        Console.WriteLine("Sexo inválido. Deve ser 'M' ou 'F'.");
                }

                pets[id] = pet;
                Console.WriteLine("Pet atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Pet não encontrado.");
            }
        }

        static void Excluir(Dictionary<int, Pets> pets)
        {
            Console.Write("Digite o ID do pet que deseja excluir: ");
            if (int.TryParse(Console.ReadLine(), out int id) && pets.ContainsKey(id))
            {
                pets.Remove(id);
                Console.WriteLine("Pet excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Pet não encontrado.");
            }
        }
    }
}
