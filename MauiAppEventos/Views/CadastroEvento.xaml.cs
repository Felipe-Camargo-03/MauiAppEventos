
using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEvento : ContentPage
{
    public CadastroEvento()
    {
        InitializeComponent();

        dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_termino.MinimumDate = DateTime.Now.AddDays(1);
    }

    private void dtpck_inicio_DateSelected(object? sender, DateChangedEventArgs e)
    {
        dtpck_termino.MinimumDate = e.NewDate?.AddDays(1);
    }

    private async void btn_Cadastrar(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_nome_evento.Text))
            {
                await DisplayAlertAsync("Atenção", "Informe o nome do evento.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_local_evento.Text))
            {
                await DisplayAlertAsync("Atenção", "Informe o local do evento.", "OK");
                return;
            }

            if (!int.TryParse(txt_participantes.Text, out int participantes) || participantes <= 0)
            {
                await DisplayAlertAsync("Atenção", "Informe uma quantidade válida de participantes.", "OK");
                return;
            }

            if (!double.TryParse(txt_custo.Text, out double custo) || custo < 0)
            {
                await DisplayAlertAsync("Atenção", "Informe um custo válido.", "OK");
                return;
            }

            if (dtpck_inicio.Date == null || dtpck_termino.Date == null)
            {
                await DisplayAlertAsync("Atenção", "Informe as datas do evento.", "OK");
                return;
            }

            Evento ev = new()
            {
                NomeEvento = txt_nome_evento.Text,
                LocalEvento = txt_local_evento.Text,
                DataInicio = dtpck_inicio.Date.Value,
                DataTermino = dtpck_termino.Date.Value,
                NumeroParticipantes = participantes,
                CustoPorParticipante = custo
            };

            await Navigation.PushAsync(new ResumoEvento
            {
                BindingContext = ev
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops!", ex.Message, "OK");
        }
    }
}
