# 🚨 APOSTILA 09 - MUDANÇAS CRUCIAIS NO PROJETO FINAL

**Data Descoberta:** 2026-04-28  
**NotebookLM:** Agora com 11 fontes (antes 10)  
**Status:** ESPECIFICAÇÕES ATUALIZADAS

---

## ⚠️ AVISO IMPORTANTE: MUDANÇAS NO PROJETO FINAL

### O que mudou com a Apostila 09:

**ANTES (Apostilas 01-08):**
- ✅ CRUD básico com SQLite
- ✅ Model + DAL básicos
- ✅ Views simples com Entry/Button

**AGORA (Apostila 09):**
- 🆕 **ListView com ObservableCollection** (listagem dinâmica)
- 🆕 **SearchBar** (busca em tempo real)
- 🆕 **PullToRefresh** (gesto para atualizar)
- 🆕 **ToolbarItem** (botões na barra superior)
- 🆕 **ContextActions/MenuItem** (menu de contexto swipe)
- 🆕 **DataBinding** ({Binding pesNome})
- 🆕 **OnAppearing()** (recarregar tela ao ganhar foco)

---

## 📋 ESPECIFICAÇÕES TÉCNICAS APOSTILA 09

### 1. ESTRUTURA DE TELAS OBRIGATÓRIA

#### TelaListaPessoa.xaml (Principal)
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="appClassePessoaBD.Views.TelaListaPessoa"
             BackgroundImageSource="fundo.png"
             Title="Lista de Pessoas">
    
    <!-- Botão na barra superior -->
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Incluir" 
                    IconImageSource="iconincluirpessoa.png" 
                    Clicked="irTelaIncluirPessoa" />
    </ContentPage.ToolbarItems>
    
    <ContentPage.Content>
        <StackLayout>
            <!-- Barra de busca -->
            <SearchBar x:Name="txtBusca" 
                      Margin="-10, 0, 0, 0" 
                      Placeholder="Qual a Pessoa?" 
                      TextChanged="txtBuscar" />
            
            <!-- Lista com pull-to-refresh -->
            <ListView x:Name="lstPessoas" 
                     IsPullToRefreshEnabled="True" 
                     Refreshing="refCarregando" 
                     ItemSelected="lstPessoasItemSelected">
                
                <!-- Cabeçalho da lista -->
                <ListView.Header>
                    <Grid RowDefinitions="Auto" 
                         ColumnDefinitions="*, *, *">
                        <Label Grid.Row="0" Grid.Column="0" 
                              Text="Código(ID)" 
                              HorizontalTextAlignment="Center" 
                              FontAttributes="Bold" />
                        <Label Grid.Row="0" Grid.Column="1" 
                              Text="Nome" 
                              HorizontalTextAlignment="Center" 
                              FontAttributes="Bold" />
                        <Label Grid.Row="0" Grid.Column="2" 
                              Text="Idade" 
                              HorizontalTextAlignment="Center" 
                              FontAttributes="Bold" />
                    </Grid>
                </ListView.Header>
                
                <!-- Template de cada linha -->
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <!-- Menu de contexto (swipe) -->
                            <ViewCell.ContextActions>
                                <MenuItem Text="Excluir" 
                                         IconImageSource="iconexcluirpessoa.png" 
                                         Clicked="excluirPessoa" />
                            </ViewCell.ContextActions>
                            
                            <!-- Layout da linha -->
                            <Grid RowDefinitions="Auto" 
                                 ColumnDefinitions="*, *, *">
                                <Label Grid.Row="0" Grid.Column="0" 
                                      Text="{Binding pesID}" 
                                      HorizontalTextAlignment="Center" />
                                <Label Grid.Row="0" Grid.Column="1" 
                                      Text="{Binding pesNome}" 
                                      HorizontalTextAlignment="Center" />
                                <Label Grid.Row="0" Grid.Column="2" 
                                      Text="{Binding pesIdade}" 
                                      HorizontalTextAlignment="Center" />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

#### TelaListaPessoa.xaml.cs (Code-behind)
```csharp
using System.Collections.ObjectModel;
using appClassePessoaBD.Model;

namespace appClassePessoaBD.Views
{
    public partial class TelaListaPessoa : ContentPage
    {
        // ObservableCollection para atualização automática
        public ObservableCollection<Pessoa> ListaPessoas { get; set; }

        public TelaListaPessoa()
        {
            InitializeComponent();
            ListaPessoas = new ObservableCollection<Pessoa>();
        }

        // Recarregar lista ao ganhar foco
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            var lista = await App.Database.GetAll();
            ListaPessoas.Clear();
            
            foreach (var pessoa in lista)
            {
                ListaPessoas.Add(pessoa);
            }
            
            lstPessoas.ItemsSource = ListaPessoas;
        }

        // Busca em tempo real
        private async void txtBuscar(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                var lista = await App.Database.GetAll();
                ListaPessoas.Clear();
                foreach (var pessoa in lista)
                {
                    ListaPessoas.Add(pessoa);
                }
            }
            else
            {
                var lista = await App.Database.Search(e.NewTextValue);
                ListaPessoas.Clear();
                foreach (var pessoa in lista)
                {
                    ListaPessoas.Add(pessoa);
                }
            }
            
            lstPessoas.ItemsSource = ListaPessoas;
        }

        // Pull to refresh
        private async void refCarregando(object sender, EventArgs e)
        {
            var lista = await App.Database.GetAll();
            ListaPessoas.Clear();
            foreach (var pessoa in lista)
            {
                ListaPessoas.Add(pessoa);
            }
            
            lstPessoas.ItemsSource = ListaPessoas;
            lstPessoas.EndRefresh();
        }

        // Selecionar item (editar)
        private async void lstPessoasItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            
            var pessoaSelecionada = e.SelectedItem as Pessoa;
            await Navigation.PushAsync(new TelaAlterarPessoa(pessoaSelecionada));
            
            lstPessoas.SelectedItem = null;
        }

        // Excluir via swipe
        private async void excluirPessoa(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var pessoa = menuItem.CommandParameter as Pessoa;
            
            if (pessoa != null)
            {
                bool confirmar = await DisplayAlert("Confirmação", 
                                                   $"Deseja excluir {pessoa.pesNome}?", 
                                                   "Sim", 
                                                   "Não");
                if (confirmar)
                {
                    await App.Database.Delete(pessoa.pesID);
                    ListaPessoas.Remove(pessoa);
                }
            }
        }

        // Navegar para inclusão
        private async void irTelaIncluirPessoa(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaIncluirPessoa());
        }
    }
}
```

---

## 🆕 NOVOS COMPONENTES OBRIGATÓRIOS

### 1. ListView
- **Finalidade:** Exibir coleção de dados
- **Propriedades chave:**
  - `IsPullToRefreshEnabled="True"` - gesto puxar para atualizar
  - `ItemsSource` - fonte de dados (ObservableCollection)
  - `ItemSelected` - evento ao selecionar item

### 2. SearchBar
- **Finalidade:** Busca em tempo real
- **Propriedades chave:**
  - `Placeholder` - texto de ajuda
  - `TextChanged` - evento ao digitar

### 3. ToolbarItem
- **Finalidade:** Botões na barra superior
- **Propriedades chave:**
  - `Text` - texto do botão
  - `IconImageSource` - ícone (referenciar .png mesmo sendo .svg)
  - `Clicked` - evento

### 4. ViewCell.ContextActions
- **Finalidade:** Menu swipe (deslizar para esquerda)
- **Componentes:**
  - `MenuItem` - itens do menu
  - `Clicked` - evento do item

### 5. ObservableCollection
- **Finalidade:** Lista que atualiza UI automaticamente
- **Namespace:** `System.Collections.ObjectModel`
- **Uso:** Ao invés de `List<T>`

### 6. DataBinding
- **Sintaxe:** `{Binding NomePropriedade}`
- **Exemplo:** `{Binding pesNome}`, `{Binding pesID}`
- **Requisito:** Propriedades da classe Model devem ser públicas

---

## 🔄 CRUD COMPLETO ATUALIZADO

### CREATE (Inserir)
```csharp
private async void ToolbarItemClickedSalvar(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrWhiteSpace(txtNomePessoa.Text))
        {
            await DisplayAlert("Erro", 
                              "Verifique se a caixa de texto Nome da Pessoa está vazia !!!!", 
                              "OK");
            txtNomePessoa.Focus();
        }
        else if (string.IsNullOrWhiteSpace(txtIdadePessoa.Text))
        {
            await DisplayAlert("Erro", 
                              "Verifique se a caixa de texto Idade da Pessoa está vazia !!!!", 
                              "OK");
            txtIdadePessoa.Focus();
        }
        else
        {
            Pessoa pessoa1 = new Pessoa
            {
                pesNome = txtNomePessoa.Text,
                pesIdade = Convert.ToInt32(txtIdadePessoa.Text),
            };
            
            await App.Database.Insert(pessoa1);
            await DisplayAlert("Pessoa Cadastrada com Sucesso !!!!", "", "OK");
            await Navigation.PushAsync(new TelaListaPessoa());
        }
    }
    catch (Exception ex)
    {
        await DisplayAlert("Erro no Cadastro da Pessoa !!!!", ex.Message, "OK");
    }
}
```

### READ (Listar)
```csharp
protected async override void OnAppearing()
{
    base.OnAppearing();
    
    var lista = await App.Database.GetAll();
    ListaPessoas.Clear();
    
    foreach (var pessoa in lista)
    {
        ListaPessoas.Add(pessoa);
    }
    
    lstPessoas.ItemsSource = ListaPessoas;
}
```

### UPDATE (Alterar)
```csharp
private async void ToolbarItemClickedSalvar(object sender, EventArgs e)
{
    pessoaExistente.pesNome = txtNomePessoa.Text;
    pessoaExistente.pesIdade = Convert.ToInt32(txtIdadePessoa.Text);
    
    await App.Database.Update(pessoaExistente);
    await DisplayAlert("Sucesso!", "Pessoa alterada com sucesso!", "OK");
    
    await Navigation.PushAsync(new TelaListaPessoa());
}
```

### DELETE (Excluir)
```csharp
private async void excluirPessoa(object sender, EventArgs e)
{
    var menuItem = sender as MenuItem;
    var pessoa = menuItem.CommandParameter as Pessoa;
    
    if (pessoa != null)
    {
        bool confirmar = await DisplayAlert("Confirmação", 
                                           $"Deseja excluir {pessoa.pesNome}?", 
                                           "Sim", 
                                           "Não");
        if (confirmar)
        {
            await App.Database.Delete(pessoa.pesID);
            ListaPessoas.Remove(pessoa);
        }
    }
}
```

---

## 🎯 CHECKLIST ATUALIZADO PROJETO FINAL

### Estrutura OBRIGATÓRIA
- [ ] **Model/** com classe POCO
- [ ] **DAL/** com crudSQLite
- [ ] **Views/** com 3 telas MÍNIMO:
  - [ ] TelaLista (ListView + SearchBar)
  - [ ] TelaIncluir (Formulário)
  - [ ] TelaAlterar (Formulário com dados carregados)

### Componentes OBRIGATÓRIOS
- [ ] **ListView** com ObservableCollection
- [ ] **SearchBar** para busca em tempo real
- [ ] **PullToRefresh** (IsPullToRefreshEnabled="True")
- [ ] **ToolbarItem** (botão Incluir na barra superior)
- [ ] **ContextActions/MenuItem** (menu swipe Excluir)
- [ ] **DataBinding** ({Binding NomePropriedade})
- [ ] **OnAppearing()** override

### Funcionalidades CRUD
- [ ] **CREATE:** Formulário com validação
- [ ] **READ:** ListView com ObservableCollection
- [ ] **UPDATE:** Formulário que carrega dados existentes
- [ ] **DELETE:** Menu swipe com confirmação

### Validação e UX
- [ ] `string.IsNullOrWhiteSpace()` em campos obrigatórios
- [ ] `DisplayAlertAsync()` para feedback
- [ ] Foco automático em campos inválidos
- [ ] Confirmação antes de excluir (DisplayAlert com Sim/Não)

---

## 🚨 MUDANÇAS NO PROJETO FINAL

### O que PRECISA REFATORAR:

**SE você já implementou sem a Apostila 09:**

1. **ADICIONAR ObservableCollection:**
   - Trocar `List<T>` por `ObservableCollection<T>`
   - Adicionar `using System.Collections.ObjectModel;`

2. **IMPLEMENTAR OnAppearing():**
   - Override do método para recarregar lista
   - Chamar `GetAll()` do banco

3. **ADICIONAR SearchBar:**
   - Componente de busca em tempo real
   - Evento `TextChanged` chamando `Search()`

4. **IMPLEMENTAR PullToRefresh:**
   - `IsPullToRefreshEnabled="True"` no ListView
   - Evento `Refreshing` para recarregar

5. **ADICIONAR ToolbarItem:**
   - Botão "Incluir" na barra superior
   - `IconImageSource` com ícone personalizado

6. **IMPLEMENTAR ContextActions:**
   - Menu swipe para excluir
   - `MenuItem` com `Clicked` event

7. **CORRIGIR DataBinding:**
   - Usar `{Binding NomePropriedade}` no XAML
   - Propriedades da Model devem ser públicas

---

## 📊 IMAGENS NOVAS APOSTILA 09

### Figuras identificadas:
- **Figura 275:** Tela "Lista de Pessoas" no Windows
- **Figura 276:** Tela "Lista de Pessoas" no Android

### Novos ícones necessários:
- `iconincluirpessoa.png` (ToolbarItem)
- `iconexcluirpessoa.png` (MenuItem)
- `fundo.png` (BackgroundImageSource)

---

## 💡 IMPACTO NO PROJETO FINAL

### Cronograma Atualizado:
- **19/05:** Setup + Model + DAL
- **26/05:** Views BÁSICAS (Entry/Button)
- **02/06:** **Views AVANÇADAS** (ListView, SearchBar, ToolbarItem)

### Complexidade Aumentada:
- **ANTES:** CRUD básico com formulários simples
- **AGORA:** CRUD profissional com listagem dinâmica

### Avaliação:
- **ANTES:** Interface funcional conta 60%
- **AGORA:** Interface AVANÇADA conta 80%

---

## 🔧 COMEÇAR REFATORAÇÃO AGORA

### Passo 1: Atualizar Model
```csharp
// Garantir propriedades públicas
public class Pessoa
{
    [PrimaryKey, AutoIncrement]
    public int pesID { get; set; }
    
    public string? pesNome { get; set; }  // PÚBLICA
    public int pesIdade { get; set; }      // PÚBLICA
}
```

### Passo 2: Atualizar Views
```csharp
// Adicionar ObservableCollection
using System.Collections.ObjectModel;

public ObservableCollection<Pessoa> ListaPessoas { get; set; }
```

### Passo 3: Implementar OnAppearing
```csharp
protected async override void OnAppearing()
{
    base.OnAppearing();
    // Carregar dados do banco
    var lista = await App.Database.GetAll();
    // Atualizar ObservableCollection
}
```

---

**Conclusão:** A Apostila 09 é ESSENCIAL e muda completamente o nível do projeto final. O que era um CRUD básico agora é um CRUD PROFISSIONAL com listagem dinâmica, busca em tempo real e gestos de interface.

**Ação ImediATA:** Atualizar todos os guias e especificações com os novos componentes OBRIGATÓRIOS da Apostila 09.

**Data:** 2026-04-28  
**Status:** Especificações TÉCNICAS ATUALIZADAS com Apostila 09  
**Próximo:** Atualizar FULL_SDD_PROMPT.md com ListView, SearchBar, etc.
