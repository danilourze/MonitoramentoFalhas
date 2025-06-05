using MonitoramentoFalhas.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoFalha.Views
{
     public class MenuView
    {
        private FalhaController controller = new FalhaController();

        public void MostrarMenu()
        {
            if (!AutenticarUsuario()) return;

            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Monitoramento de Falhas ===");
                Console.WriteLine("1. Registrar falha de energia");
                Console.WriteLine("2. Visualizar falhas registradas");
                Console.WriteLine("3. Gerar relatório por severidade");
                Console.WriteLine("4. Exportar log para arquivo");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        RegistrarFalha();
                        break;
                    case 2:
                        controller.VisualizarFalhas();
                        break;
                    case 3:
                        controller.GerarRelatorio();
                        break;
                    case 4:
                        controller.ExportarLog();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (opcao != 0);
        }

        private void RegistrarFalha()
        {
            Console.Clear();
            Console.WriteLine("--- Registro de Falha de Energia ---");
            Console.Write("Local da falha: ");
            string? local = Console.ReadLine();

            Console.Write("Severidade (1=Leve, 2=Moderada, 3=Crítica): ");
            if (!int.TryParse(Console.ReadLine(), out int nivel) || nivel < 1 || nivel > 3 || string.IsNullOrEmpty(local))
            {
                Console.WriteLine("Dados inválidos.");
                return;
            }

            controller.RegistrarFalha(local, nivel);
        }

        private bool AutenticarUsuario()
        {
            Console.Write("Usuário: ");
            string? usuario = Console.ReadLine();
            Console.Write("Senha: ");
            string? senha = Console.ReadLine();

            if (usuario == "admin" && senha == "1234")
            {
                Console.WriteLine("Autenticação bem-sucedida!");
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.WriteLine("Acesso negado.");
                return false;
            }
        }
    }
}
