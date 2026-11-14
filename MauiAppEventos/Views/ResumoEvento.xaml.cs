namespace MauiAppEventos.Views;

public partial class ResumoEvento : ContentPage
{
	public ResumoEvento()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CadastroEvento());
    }
}