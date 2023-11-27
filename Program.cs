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

    enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4 }
    public static void Main(string[] args)
    {
        Carregar();
        bool escolheuSair = false;
        while (!escolheuSair)
        {
            Console.WriteLine("Bem vindo ao sistema!");
            Console.WriteLine(" 1 - Listagem \n 2 - Adicionar \n 3 - Remover \n 4 - Sair");
            int intOpcao = int.Parse(Console.ReadLine());
            Menu opcao = (Menu)intOpcao;

            switch (opcao)
            {
                case Menu.Adicionar:
                    Adicionar();
                    break;
                case Menu.Listagem:
                    Listagem();
                    break;
                case Menu.Remover:
                    Remover();
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
            Cliente cliente = new Cliente();
            Console.WriteLine("Cadastro de clientes: ");

            Console.WriteLine("Nome do cliente: ");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Email do cliente: ");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do cliente: ");
            cliente.cpf = Console.ReadLine();
            

            Console.Add(cliente);
            Salvar();

            Console.WriteLine("Cadastro concluido! Aperte ENTER para sair");
            Console.ReadLine();
        }

        static void Listagem()
        {
            if(clientes.Count > 0)
            {
                Console.WriteLine("Lista de clientes: ");
                int i=0;
                foreach(Cliente cliente in clientes)
                {
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"Email: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    Console.WriteLine("**************************************");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado.")
            }
            Console.WriteLine("Aperte ENTER para sair");
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do cliente que voce quer remover");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                Salvar();

            }
            else
            {
                Console.WriteLine("O id digitado é invalido, tente novamente!");
                Console.ReadLine();
            }

        }

        static void Salvar()
        {
            FileStream stream = new FileStream("clientes.dat",FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, clientes);
            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("clientes.dat",FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter enconder = new BinaryFormatter();

                clientes = (List<Cliente>)enconder.Deserialize(stream);

                if(clientes == null)
                {
                    clientes = new List<Cliente>();
                }
            }
            catch(Exception e)
            {
                clientes = new List<Cliente>();
            }
            finally
            {
                stream.Close();
            }
        }

    }
}