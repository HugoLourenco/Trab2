using System;

namespace Trab2_csharp
{
    class Program
    {
        struct conta
        {
            public int numero;
            public string cliente;
            public double saldo;
        };
        static int conta_valida(conta[] contas, int c)

        {
            for (int i = 0; i < 5; i++)
            {
                if (contas[i].numero == c)
                {
                    return i;
                }
            }
            return -1;
        }
        static void consulta(conta c)
        {
            Console.WriteLine($"SALDO: {c.saldo}");
        }
        static void deposito(conta[] contas, int c, double q)
        {
            contas[c].saldo += q;
        }
        static void levantamento(conta[] contas, int c, double q)
        {
            if (contas[c].saldo >= q)
            {
                contas[c].saldo -= q;
            }
            else
            {
                Console.WriteLine("SALDO INSUFICIENTE!");
            }
        }
        static string transferencia(conta[] contas, int c, int d, double q)
        {
            if (contas[c].saldo >= q)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (contas[i].numero == d)
                    {
                        contas[i].saldo += q;
                        contas[c].saldo -= q;
                        return "Transferência efetuada";
                    }
                }
                return "Conta de destino não encontrada";
            }
            else
            {
                return "SALDO INSUFICIENTE!";
            }
        }
        static void Main(string[] args)
        {
            conta[] lista_contas = new conta[5];
            lista_contas[0].numero = 1;
            lista_contas[0].cliente = "Manuel";
            lista_contas[0].saldo = 50.0;
            lista_contas[1].numero = 2;
            lista_contas[1].cliente = "Rui";
            lista_contas[1].saldo = 250.0;
            lista_contas[2].numero = 3;
            lista_contas[2].cliente = "Sónia";
            lista_contas[2].saldo = 25.0;
            lista_contas[3].numero = 4;
            lista_contas[3].cliente = "Helena";
            lista_contas[3].saldo = 75.0;
            lista_contas[4].numero = 5;
            lista_contas[4].cliente = "Nuno";
            lista_contas[4].saldo = 150.0;
            int opcao, num_conta, id_conta;
            do
            {
                Console.WriteLine("Indique número da conta (-1 para sair):");
                num_conta = Convert.ToInt32(Console.ReadLine());
                id_conta = conta_valida(lista_contas, num_conta);
                if (num_conta != -1)
                {
                    if (id_conta != -1)
                    {
                        Console.WriteLine("Selecione uma opção:");
                        Console.WriteLine("1 - Consultar saldo");
                        Console.WriteLine("2 - Depósito");
                        Console.WriteLine("3 - Levantamento");
                        Console.WriteLine("4 - Transferência");
                        opcao = Convert.ToInt32(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                consulta(lista_contas[id_conta]);
                                break;
                            case 2:
                                Console.WriteLine("Indique montante a depositar:");
                               
                                double quantia =
                               Convert.ToDouble(Console.ReadLine());
                                deposito(lista_contas, id_conta, quantia);
                                break;
                            case 3:
                                Console.WriteLine("Indique montante a levantar:");
                               
                                quantia = Convert.ToDouble(Console.ReadLine());
                                levantamento(lista_contas, id_conta, quantia);
                                break;
                            case 4:
                                Console.WriteLine("Indique montante a transferir:");
                               
                                quantia = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Indique conta de destino: ");
                                int conta_dest =
                                Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(transferencia(lista_contas,
                               id_conta, conta_dest, quantia));
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta inválida");
                    }
                }
            } while (num_conta != -1);
        }
    }
}