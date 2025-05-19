using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> gatos = new Dictionary<int, string>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("/n MENU VET SMART");
            Console.WriteLine("1. Adicionar Pets");
            Console.WriteLine("2. Listar Pets");
            Console.WriteLine("3. Atualizar Pets");
            Console.WriteLine("4. Deletar Pets");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Criar(Pets);
                    break;
                case "2":
                    Ler(Pets);
                    break;
                case "3":
                    Atualizar(Pets);
                    break;
                case "4":
                    Excluir(Pets);
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
    static void Criar(Dictionary<int, string> gatos)
    {
        C
    }
}