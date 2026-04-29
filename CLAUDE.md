# CLAUDE.md - Projeto Final PDM 2026

**Projeto:** Cadastro de Pessoas com SQLite  
**Disciplina:** Programação Para Dispositivos Móveis 2026  
**NotebookLM:** d7c17a87-6c17-4953-aa67-9cacd31e7a35 (9 apostilas + plano de aula)  
**Entrega:** 09/06 (Prova A1) - Resultados: 16/06

---

## 🎯 OBJETIVO

Implementar **appClassePessoaBD** completo:
- CRUD de pessoas (Create, Read, Update, Delete)
- SQLite com Model/DAL/MVVM
- ListView com SearchBar, ToolbarItem, ContextActions
- 3 telas: Lista, Incluir, Alterar

---

## 📚 ESTRUTURA OBRIGATÓRIA

```
projeto_final/
├── Model/Pessoa.cs           # Classe POCO com [Table, PrimaryKey]
├── DAL/crudSQLite.cs       # Classe CRUD async (Insert, Update, Delete, GetAll, Search)
├── Views/
│   ├── TelaListaPessoa.xaml       # ListView + SearchBar + ToolbarItem
│   ├── TelaIncluirPessoa.xaml    # Formulário CREATE
│   └── TelaAlterarPessoa.xaml     # Formulário UPDATE
├── Resources/
│   ├── Images/fundo.png
│   ├── Images/iconincluirpessoa.png
│   ├── Images/iconexcluirpessoa.png
│   ├── AppIcon/iconpessoa.svg
│   └── Splash/splash.png
└── App.xaml.cs                 # Database singleton (LocalApplicationData)
```

---

## 🛠️ IMPLEMENTAÇÃO RÁPIDA

### 1. Model/Pessoa.cs
```csharp
using SQLite;

namespace appClassePessoaBD.Model
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int pesID { get; set; }

        [MaxLength(1000)]
        public string? pesNome { get; set; }

        [MaxLength(3)]
        public int pesIdade { get; set; }
    }
}
```

### 2. DAL/crudSQLite.cs
```csharp
using SQLite;
using appClassePessoaBD.Model;

namespace appClassePessoaBD.DAL
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _conexao;

        public crudSQLite(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            _conexao.CreateTableAsync<Pessoa>().Wait();
        }

        public Task<int> Insert(Pessoa p) => _conexao.InsertAsync(pessoa);
        public Task<List<Pessoa>> GetAll() => _conexao.Table<Pessoa>().ToListAsync();
        public Task<List<Pessoa>> Update(Pessoa p) => _conexao.QueryAsync<Pessoa>("UPDATE Pessoa SET pesNome=?, pesIdade=? WHERE pesID=?", p.pesNome, p.pesIdade, p.pesID);
        public Task<int> Delete(int id) => _conexao.Table<Pessoa>().DeleteAsync(i => i.pesID == id);
        public Task<List<Pessoa>> Search(string nome) => _conexao.Table<Pessoa>().Where(i => i.pesNome.Contains(nome)).ToListAsync();
    }
}
```

### 3. App.xaml.cs (Database Singleton)
```csharp
using appClassePessoaBD.DAL;

namespace appClassePessoaBD
{
    public partial class App : Application
    {
        static crudSQLite? database;

        public static crudSQLite Database
        {
            get
            {
                if (database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "pessoas.db3"
                    );
                    database = new crudSQLite(path);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TelaListaPessoa());
        }
    }
}
```

### 4. TelaListaPessoa.xaml (Apostila 09)
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="appClassePessoaBD.Views.TelaListaPessoa"
             BackgroundImageSource="fundo.png"
             Title="Lista de Pessoas">
    
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Incluir" IconImageSource="iconincluirpessoa.png" Clicked="OnIncluirClicked" />
    </ContentPage.ToolbarItems>
    
    <ContentPage.Content>
        <StackLayout>
            <SearchBar x:Name="txtBusca" Placeholder="Qual a Pessoa?" TextChanged="OnBuscarTextChanged" />
            
            <ListView x:Name="lstPessoas" IsPullToRefreshEnabled="True" Refreshing="OnRefreshing" ItemSelected="OnItemSelected">
                <ListView.Header>
                    <Grid ColumnDefinitions="*, *, *">
                        <Label Grid.Column="0" Text="ID" FontAttributes="Bold" HorizontalTextAlignment="Center" />
                        <Label Grid.Column="1" Text="Nome" FontAttributes="Bold" HorizontalTextAlignment="Center" />
                        <Label Grid.Column="2" Text="Idade" FontAttributes="Bold" HorizontalTextAlignment="Center" />
                    </Grid>
                </ListView.Header>
                
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <ViewCell.ContextActions>
                                <MenuItem Text="Excluir" IconImageSource="iconexcluirpessoa.png" Clicked="OnExcluirClicked" />
                            </ViewCell.ContextActions>
                            
                            <Grid ColumnDefinitions="*, *, *">
                                <Label Grid.Column="0" Text="{Binding pesID}" HorizontalTextAlignment="Center" />
                                <Label Grid.Column="1" Text="{Binding pesNome}" HorizontalTextAlignment="Center" />
                                <Label Grid.Column="2" Text="{Binding pesIdade}" HorizontalTextAlignment="Center" />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

### 5. TelaListaPessoa.xaml.cs (Code-behind)
```csharp
using System.Collections.ObjectModel;
using appClassePessoaBD.Model;

namespace appClassePessoaBD.Views
{
    public partial class TelaListaPessoa : ContentPage
    {
        public ObservableCollection<Pessoa> ListaPessoas { get; set; }

        public TelaListaPessoa()
        {
            InitializeComponent();
            ListaPessoas = new ObservableCollection<Pessoa>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var lista = await App.Database.GetAll();
            ListaPessoas.Clear();
            foreach (var pessoa in lista)
                ListaPessoas.Add(pessoa);
            lstPessoas.ItemsSource = ListaPessoas;
        }

        private async void OnBuscarTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                var lista = await App.Database.GetAll();
                ListaPessoas.Clear();
                foreach (var pessoa in lista)
                    ListaPessoas.Add(pessoa);
            }
            else
            {
                var lista = await App.Database.Search(e.NewTextValue);
                ListaPessoas.Clear();
                foreach (var pessoa in lista)
                    ListaPessoas.Add(pessoa);
            }
            lstPessoas.ItemsSource = ListaPessoas;
        }

        private async void OnRefreshing(object sender, EventArgs e)
        {
            var lista = await App.Database.GetAll();
            ListaPessoas.Clear();
            foreach (var pessoa in lista)
                ListaPessoas.Add(pessoa);
            lstPessoas.ItemsSource = ListaPessoas;
            lstPessoas.EndRefresh();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var pessoa = e.SelectedItem as Pessoa;
            await Navigation.PushAsync(new TelaAlterarPessoa(pessoa));
            lstPessoas.SelectedItem = null;
        }

        private async void OnExcluirClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var pessoa = menuItem.CommandParameter as Pessoa;
            
            if (pessoa != null)
            {
                bool confirmar = await DisplayAlert("Confirmação", $"Deseja excluir {pessoa.pesNome}?", "Sim", "Não");
                if (confirmar)
                {
                    await App.Database.Delete(pessoa.pesID);
                    ListaPessoas.Remove(pessoa);
                }
            }
        }

        private async void OnIncluirClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaIncluirPessoa());
        }
    }
}
```

### 6. TelaIncluirPessoa.xaml (Formulário)
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="appClassePessoaBD.Views.TelaIncluirPessoa"
             Title="Incluir Pessoa">
    
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Salvar" IconImageSource="salvarpessoa.png" Clicked="OnSalvarClicked" />
    </ContentPage.ToolbarItems>
    
    <ContentPage.Content>
        <StackLayout Padding="20" Spacing="15">
            <Label Text="Nome:" FontAttributes="Bold" />
            <Entry x:Name="txtNome" Placeholder="Digite o nome..." ClearButtonVisibility="WhileEditing" />
            
            <Label Text="Idade:" FontAttributes="Bold" />
            <Entry x:Name="txtIdade" Placeholder="Digite a idade..." Keyboard="Numeric" ClearButtonVisibility="WhileEditing" />
            
            <Button Text="Salvar" Clicked="OnSalvarClicked" BackgroundColor="#512BD4" TextColor="White" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

### 7. TelaIncluirPessoa.xaml.cs
```csharp
using appClassePessoaBD.Model;

namespace appClassePessoaBD.Views
{
    public partial class TelaIncluirPessoa : ContentPage
    {
        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await DisplayAlert("Erro", "Campo nome obrigatório!", "OK");
                txtNome.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtIdade.Text))
            {
                await DisplayAlert("Erro", "Campo idade obrigatório!", "OK");
                txtIdade.Focus();
                return;
            }
            
            var pessoa = new Pessoa
            {
                pesNome = txtNome.Text,
                pesIdade = Convert.ToInt32(txtIdade.Text)
            };
            
            await App.Database.Insert(pessoa);
            await DisplayAlert("Sucesso!", "Pessoa salva com sucesso!", "OK");
            
            await Navigation.PushAsync(new TelaListaPessoa());
        }
    }
}
```

---

## ⚠️ REGRAS CRÍTICAS

### Nunca esquecer:
- ✅ **ApplicationId:** br.edu.udf.appclassepessoabd
- ✅ **ObservableCollection** (não List<>)
- ✅ **async/await** em métodos de banco
- ✅ **IsNullOrWhiteSpace** para validação
- ✅ **SVG referenciado como .png** no XAML

### Sempre fazer:
- ✅ **Commit descritivo** após cada implementação
- ✅ **Testar no emulador** Android
- ✅ **Chamar base.OnAppearing()** em overrides
- ✅ **Usar LocalApplicationData** para banco

---

## 📅 CRONOGRAMA

- **Semana 1 (19/05):** Model + DAL
- **Semana 2 (26/05):** Views + CRUD básico
- **Semana 3 (02/06):** ListView + SearchBar + ToolbarItem
- **Entrega (09/06):** Prova A1
- **Resultados (16/06):** Nota final

---

## 📞 NOTEBOOKLM

**NotebookID:** `d7c17a87-6c17-4953-aa67-9cacd31e7a7a35`  
**Apostilas:** 01-09 + Plano de Aula  
**Acesso:** Via MCP no Claude Code

**Consultar sobre:** SQLite, ListView, SearchBar, MVVM, DAL, etc.

---

## ✅ STATUS ATUAL (2026-04-29)

### Código Implementado: 100% COMPLETO
- ✅ Model/Pessoa.cs (POCO com atributos SQLite)
- ✅ DAL/crudSQLite.cs (CRUD completo async)
- ✅ App.xaml.cs (Database singleton)
- ✅ Views/TelaListaPessoa.xaml + .xaml.cs (ListView + SearchBar)
- ✅ Views/TelaIncluirPessoa.xaml + .xaml.cs (Formulário CREATE)
- ✅ Views/TelaAlterarPessoa.xaml + .xaml.cs (Formulário UPDATE)
- ✅ Resources (ícones, imagens, splash)

### Build Blockers (Ambiente macOS):
1. **MacCatalyst**: Xcode 26.4.1 vs .NET MAUI 10.0 requer 26.3
2. **Windows**: Não pode buildar Windows no macOS
3. **Android**: Android SDK não instalado

### Solução Recomendada (Apostilas):
> "Usar **Windows 11 + Visual Studio 2026** para desenvolvimento e testes"
> - Compilar para **Windows** (WinUI 3)
> - Compilar para **Android** (com Android Studio/SDK)
> - iOS/Mac Catalyst requer Mac (não abordado por custos)

### Entrega:
**Data:** 09/06 (Prova A1)
**Resultados:** 16/06

**Próximo passo:** Transferir projeto para Windows 11 + Visual Studio 2026 para build/testes
