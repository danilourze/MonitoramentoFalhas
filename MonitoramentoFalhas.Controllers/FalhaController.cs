using MonitoramentoFalhas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static MonitoramentoFalhas.Models.Severiadade;

namespace MonitoramentoFalhas.Controllers
{
    public class FalhaController
    {
        private List<Falha> falhas = new List<Falha>();

        public void RegistrarFalha(string local, int severidade)
        {
            Falha novaFalha = new Falha
            {
                Id = falhas.Count + 1,
                Local = local,
                DataHora = DateTime.Now,
                Severidade = (Severidade)severidade
            };

            falhas.Add(novaFalha);
            Console.WriteLine("Falha registrada com sucesso!");
        }

        public void VisualizarFalhas()
        {
            Console.Clear();
            Console.WriteLine("--- Falhas Registradas ---");

            if (falhas.Count == 0)
            {
                Console.WriteLine("Nenhuma falha registrada.");
                return;
            }

            foreach (var falha in falhas)
            {
                Console.WriteLine(falha);
            }
        }

        public void GerarRelatorio()
        {
            Console.Clear();
            Console.WriteLine("--- Relatório por Severidade ---");

            var agrupadas = falhas.GroupBy(f => f.Severidade);

            foreach (var grupo in agrupadas)
            {
                Console.WriteLine($"Severidade: {grupo.Key} - Quantidade: {grupo.Count()}");
            }
        }

        public void ExportarLog()
        {
            string caminho = "falhas_log.txt";
            using StreamWriter writer = new StreamWriter(caminho);
            foreach (var falha in falhas)
            {
                writer.WriteLine(falha);
            }
            Console.WriteLine($"Log exportado para {caminho}");
        }
    }
}
