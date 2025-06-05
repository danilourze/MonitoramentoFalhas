using static MonitoramentoFalhas.Models.Severiadade;

namespace MonitoramentoFalhas.Models
{
    public class Falha
    {
        public int Id { get; set; }
        public string Local { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public Severidade Severidade { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Local: {Local} | Data/Hora: {DataHora} | Severidade: {Severidade}";
        }
    }
}
