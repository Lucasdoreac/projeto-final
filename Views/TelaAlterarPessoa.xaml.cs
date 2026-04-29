using appClassePessoaBD.Model;

namespace appClassePessoaBD.Views;

public partial class TelaAlterarPessoa : ContentPage
{
    public TelaAlterarPessoa()
    {
        InitializeComponent();
    }

    private async void ToolbarItemClickedSalvar(object sender, EventArgs e)
    {
        try
        {
            Pessoa PessoaAnexada = BindingContext as Pessoa;

            if ((string.IsNullOrWhiteSpace(txtNomePessoa.Text)))
            {
                DisplayAlert("Erro", "Verifique se a caixa de texto Nome da Pessoa está vazia !!!!", "OK");
                txtNomePessoa.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtIdadePessoa.Text))
            {
                DisplayAlert("Erro", "Verifique se a caixa de texto Idade da Pessoa está vazia !!!!", "OK");
                txtIdadePessoa.Focus();
            }
            else
            {
                Pessoa pessoa1 = new Pessoa
                {
                    pesID = PessoaAnexada.pesID,
                    pesNome = txtNomePessoa.Text,
                    pesIdade = Convert.ToInt32(txtIdadePessoa.Text),
                };

                await App.Database.Update(pessoa1);
                await DisplayAlert("Pessoa Alterada com Sucesso !!!!", "", "OK");
                await Navigation.PushAsync(new TelaListaPessoa());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Alteração da Pessoa !!!!", ex.Message, "OK");
        }
    }
}
