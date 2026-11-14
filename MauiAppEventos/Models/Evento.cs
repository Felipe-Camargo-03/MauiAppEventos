
namespace MauiAppEventos.Models
{
    public class Evento
    {
        public string NomeEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public string LocalEvento { get; set; }
        public double CustoPorParticipante { get; set; }

        public TimeSpan Duracao
        {
            get => DataTermino.Subtract(DataInicio);
        }

        public int DuracaoDias
        {
            get => Duracao.Days;
        }

        public double CustoTotal
        {
            get => NumeroParticipantes * CustoPorParticipante * DuracaoDias;
        }
    }
}
