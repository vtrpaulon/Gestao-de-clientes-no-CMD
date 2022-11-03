using System;
using System.Collections.Generic;

class Program
{
    [System.Serializable]

    struct Cliente
    {
        public string nome;
        public string email;
        public string cpf;
    }
    static List<Cliente> clientes = new List<Cliente>();

    enum Menu { Listar = 1, Adicionar = 2, Remover = 3, Sair = 4 }
    public static void Main(string[] args)
    {
        bool escolheuSair = false;
        while (!escolheuSair)
        {
            Console.WriteLine("Bem vindo ao sistema!");
            Console.WriteLine(" 1 - Listar \n 2 - Adicionar \n 3 - Remover \n 4 - Sair");
            int intOpcao = int.Parse(Console.ReadLine());
            Menu opcao = (Menu)intOpcao;

            switch (opcao)
            {
                case Menu.Adicionar:
                    break;
                case Menu.Listar:
                    break;
                case Menu.Remover:
                    break;
                case Menu.Sair:
                    escolheuSair = true;
                    Console.WriteLine("***** Fechando sistema!!! *****");
                    break;
            }
            Console.Clear();
        }
        static void Adicionar()
        {

        }
    }
}