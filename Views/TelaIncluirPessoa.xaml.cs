using appClassePessoaBD.Model;

namespace appClassePessoaBD.Views;

public partial class TelaIncluirPessoa : ContentPage
{
    public TelaIncluirPessoa()
    {
        InitializeComponent();
    }

    private async void ToolbarItemClickedSalvar(object sender, EventArgs e)
    {
        try
        {
            if ((string.IsNullOrWhiteSpace(txtNomePessoa.Text)))
            {
                await DisplayAlert("Erro", "Verifique se a caixa de texto Nome da Pessoa está vazia !!!!", "OK");
                txtNomePessoa.Focus();
                return;
            }

            Pessoa pessoa1 = new Pessoa
            {
                pesNome = txtNomePessoa.Text,
                pesIdade = Convert.ToInt32(txtIdadePessoa.Text),
            };

            await App.Database.Insert(pessoa1);

            await DisplayAlert("Pessoa Cadastrada com Sucesso !!!!", "", "OK");

            await Navigation.PushAsync(new TelaListaPessoa());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro no Cadastro da Pessoa !!!!", ex.Message, "OK");

            txtNomePessoa.Text = "";
            txtIdadePessoa.Text = "";
            txtNomePessoa.Focus();
        }
    }
}
