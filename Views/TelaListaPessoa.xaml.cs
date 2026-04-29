using appClassePessoaBD.Model;
using System.Collections.ObjectModel;

namespace appClassePessoaBD.Views;

public partial class TelaListaPessoa : ContentPage
{
    ObservableCollection<Pessoa> listagemPessoas = new ObservableCollection<Pessoa>();

    public TelaListaPessoa()
    {
        InitializeComponent();
        lstPessoas.ItemsSource = listagemPessoas;
    }

    private async void irTelaIncluirPessoa(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new TelaIncluirPessoa());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro no Cadastro da Pessoa !!!!", ex.Message, "OK");
        }
    }

    protected async override void OnAppearing()
    {
        try
        {
            listagemPessoas.Clear();
            List<Pessoa> temp = await App.Database.GetAll();
            temp.ForEach(i => listagemPessoas.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro Desconhecido no Carregamento da Lista !!!!", ex.Message, "OK");
        }
    }

    private async void excluirPessoa(object sender, EventArgs e)
    {
        try
        {
            MenuItem itemSelecionado = sender as MenuItem;
            Pessoa pessoaSelecionada = itemSelecionado.BindingContext as Pessoa;

            bool confirmacao = await DisplayAlert("Tem Certeza que quer excluir a Pessoa?",
                $"Excluir {pessoaSelecionada.pesNome}", "Sim", "Não");

            if (confirmacao)
            {
                await App.Database.Delete(pessoaSelecionada.pesID);
                listagemPessoas.Remove(pessoaSelecionada);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Exclusão da Pessoa !!!!", ex.Message, "OK");
        }
    }

    private async void txtBuscar(object sender, TextChangedEventArgs e)
    {
        try
        {
            string busca = e.NewTextValue;
            lstPessoas.IsRefreshing = true;

            listagemPessoas.Clear();
            List<Pessoa> temp = await App.Database.Search(busca);
            temp.ForEach(i => listagemPessoas.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na Busca de Pessoas !!!!", ex.Message, "OK");
        }
        finally
        {
            lstPessoas.IsRefreshing = false;
        }
    }

    private void lstPessoasItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Pessoa pessoa1 = e.SelectedItem as Pessoa;

            Navigation.PushAsync(new TelaAlterarPessoa
            {
                BindingContext = pessoa1,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro Desconhecido na Seleção de Pessoa !!!!", ex.Message, "OK");
        }
    }

    private async void refCarregando(object sender, EventArgs e)
    {
        try
        {
            listagemPessoas.Clear();
            List<Pessoa> temp = await App.Database.GetAll();
            temp.ForEach(i => listagemPessoas.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro Desconhecido no carregamento de Pessoas !!!!", ex.Message, "OK");
        }
        finally
        {
            lstPessoas.IsRefreshing = false;
        }
    }
}
