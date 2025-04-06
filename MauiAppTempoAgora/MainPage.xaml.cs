using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {

                        string dados_previsao = "";

                        dados_previsao = $"Descriçao: {t.description} \n" +
                                         $"Velocidade de vento: {t.speed} \n" +
                                         $"visibilidade: {t.visibility} \n" +
                                         $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n";

                        lbl_res.Text = dados_previsao;
                    }
                    else
                    {
                        lbl_res.Text = "Cidade não encontrada. Verifique o nome e tente novamente.";
                    }

                }
                else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }
            }

            catch (HttpRequestException)
            {
                await DisplayAlert("Erro de Conexão", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async Task DisplayAlert(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
    