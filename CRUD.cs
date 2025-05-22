using System;
using System.Collections.Generic;
using System.Reflection;

class Pets
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especie { get; set; } 
    public string Raca { get; set; }
    public int Peso { get; set; }
}
class Program
{

    static void Main()
    {
        Dictionary<int, Pets> pets = new Dictionary<int, Pets>();
        int proximoId = 1;
        bool continuar = true;

        //Menu de escolha do usuário
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
    //Menu de escolha do criar cadastro de Pets
    static void Criar(Dictionary<int, Pets> pets, ref int proximoId)
    {
        Console.Write("Digite o nome do seu Pet: ");
        string nome = Console.ReadLine();

        Console.WriteLine("\n MENU DE ESPÉCIES");
        Console.WriteLine("1. Cachorros");
        Console.WriteLine("2. Gatos");
        Console.WriteLine("3. Serpentes");
        Console.Write("Escolha uma opção:  ");
        string especie = "";
        string opcao = Console.ReadLine();



        switch (opcao)
        {
            case "1":
                especie = "Cachorros";

                break;

            case "2":
                especie = "Gatos";

                break;

            case "3":
                especie = "Serpentes";

                break;

            default:
                Console.WriteLine("Tipo inválido. Refaça o cadastro.");
                return;
        }
        Console.WriteLine("\n MENU DE RAÇAS CACHORROS");
        Console.WriteLine("1. Rottweiler");
        Console.WriteLine("2. Doberman");
        Console.WriteLine("3. Pitbull Terrier");
        Console.WriteLine("4. Pastor Alemão");
        Console.WriteLine("5. Dogo Argentino");
        Console.WriteLine("6. Dálmata");
        Console.WriteLine("7. Pinscher");
        Console.WriteLine("8. SRD");
        Console.WriteLine("9. Escolha uma opção: ");

        string raca = "";
        string Racaopcao = Console.ReadLine();


        switch (especie)
        {
            case "Cachorro":
                switch (Racaopcao)
                {
                    case "1":
                        raca = "Rottweiler";
                        break;
                    case "2":
                        raca = "Doberman";
                        break;
                    case "3":
                        raca = "Pitbull Terrier";
                        break;
                    case "4":
                        raca = "Pastor Alemão";
                        break;
                    case "5":
                        raca = "Dogo Argentino";
                        break;
                    case "6":
                        raca = "Dálmata";
                        break;
                    case "7":
                        raca = "Pinscher";
                        break;
                    case "8":
                        raca = "SRD";
                        break;

                    default:
                        Console.WriteLine("Tipo inválido. Refaça o cadastro.");
                        return;
                }
                break;
                Console.WriteLine("\n MENU DE RAÇAS GATOS");
                Console.WriteLine("1. Siamês");
                Console.WriteLine("2. Persa");
                Console.WriteLine("3. Sphynx");
                Console.WriteLine("4. Maine Coon");
                Console.WriteLine("5. Siberiano");
                Console.WriteLine("6. SRD");
                Console.Write("7. Escolha uma opção: ");
            case "Gatos":
                switch (Racaopcao)
                {
                    case "1":
                        raca = "Siamês";
                        break;
                    case "2":
                        raca = "Persa";
                        break;
                    case "3":
                        raca = "Sphynx";
                        break;
                    case "4":
                        raca = "Maine Coon";
                        break;
                    case "5":
                        raca = "Siberiano";
                        break;
                    case "6":
                        raca = "SRD";
                        break;

                    default:
                        Console.WriteLine("Tipo inválido. Refaça o cadastro.");
                        return;
                }
                break;
                Console.WriteLine("MENU DE ESPÉCIES SERPENTES");
                Console.WriteLine("1. Jiboia Arco-Íris do Cerrado");
                Console.WriteLine("2. Jiboia Arco-Íris do Norte");
                Console.WriteLine("3. Jiboia Arco-Íris da Caatinga");
                Console.WriteLine("4. Jiboia (BCC)");
                Console.WriteLine("5. Escolha uma opção: ");

            case "Serpentes":
                switch (Racaopcao)
                {
                    case "1":
                        raca = "Jiboia Arco-Íris do Cerrado";
                        break;
                    case "2":
                        raca = "Jiboia Arco-Íris do Norte";
                        break;
                    case "3":
                        raca = "Jiboia Arco-Íris da Caatinga";
                        break;
                    case "4":
                        raca = "Jiboia (BCC)";
                        break;

                    default:
                        Console.WriteLine("Tipo inválido. Refaça o cadastro.");
                        return;

                }
                break;
        }
        Console.WriteLine("Digite o peso do seu PET em KG:");
        double peso;
        while (true)
        {
            Console.WriteLine("Por favor, insira um número double: ");
            string entrada = Console.ReadLine();

            if (double.TryParse(entrada, out peso))
            {
                Console.WriteLine($"Número inserido: {peso}");
                break; 
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
            }
            Pets novoPet = new Pets
            {
                Id = proximoId,
                Nome = nome,
                Especie = especie,
                Raca = raca,
                Peso = (int)peso,
            };
            pets.Add(proximoId, novoPet);
            Console.WriteLine($"Pet cadastrado com ID: {proximoId}");
            proximoId++;
        }
        static void Ler(Dictionary<int,Pets>pets)
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
            }
        }
    }
}
