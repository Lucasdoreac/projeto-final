# FULL SDD ONE-SHOT PROMPT - .NET MAUI PDM 2026
## Prompt Mestre para Claude Code com NotebookLM Context

---

## CONTEXTO INICIAL

Você está atuando como **Arquiteto de Software Sênior** especializado em **.NET MAUI 10.0** e **Visual Studio 2026**. 

**Base de Conhecimento:** Todo o conhecimento técnico está disponível no NotebookLM "Plano de Ensino: Programação Para Dispositivos Móveis 2026" (ID: `d7c17a87-6c17-4953-aa67-9cacd31e7a35`), contendo **9 apostilas técnicas** + plano de aula.

**Seu papel:** Usar o NotebookLM via MCP como mentor/arquiteto e executar as implementações via Claude Code no terminal.

---

## TAREFA PRINCIPAL

Gerar um **Software Design Document (SDD)** completo em Markdown, especificando CADA ARQUIVO, CADA LINHA DE CÓDIGO e CADA CONFIGURAÇÃO necessária para o projeto final de PDM 2026.

---

## ESPECIFICAÇÕES TÉCNICAS COMPLETAS

### 1. INFRAESTRUTURA E SETUP (Apostila 01-02)

#### 1.1 Requisitos de Sistema
- **RAM Mínima:** 8 GB (quanto mais, melhor)
- **Processador:** 64 bits
- **Espaço em Disco:** 55.84 GB para instalação completa
- **Sistema Operacional:** Windows 11 Pro 64 bits (ou Windows 10 1809+)
- **Modo Desenvolvedor:** Ativar em "Para Desenvolvedores" → Ativado

#### 1.2 Visual Studio 2026 - Workloads Obrigatórios
Marcar NO Visual Studio Installer:
- **.NET Multi-platform App UI** (.NET MAUI)
- **Desenvolvimento para desktop com .NET**
- **Desenvolvimento de aplicativo WinUI**
- **ASP.NET e desenvolvimento Web**
- **Desenvolvimento Python**
- **Configuração do SDK do Android**

#### 1.3 Emulador Android Recomendado
Criar no Android Device Manager:
- **Dispositivo Base:** Nexus 5X (+ Store)
- **Processador:** x86_64
- **Sistema Operacional:** API 29 (Android 10.0)
- **Dica:** Desmarcar "Google Play Store" para evitar lentidão

#### 1.4 Estrutura de Pastas do Projeto
```
appProjetoFinal/
├── Dependencies/          # Bibliotecas e SDKs
├── Properties/            # launchsettings.json
├── Platforms/
│   ├── Android/          # AndroidManifest.xml, MainActivity.cs
│   ├── iOS/
│   ├── MacCatalyst/
│   └── Windows/
├── Resources/
│   ├── AppIcon/          # appicon.svg, appiconfg.svg
│   ├── Fonts/            # OpenSans-Regular.ttf
│   ├── Images/           # Imagens gerais
│   ├── Raw/              # Dados brutos
│   ├── Splash/           # splash.svg
│   └── Styles/           # Colors.xaml, Styles.xaml
├── Model/                 # Classes POCO (SQLite)
├── DAL/                   # Data Access Layer (crudSQLite)
├── Views/                 # Páginas XAML
├── App.xaml
├── App.xaml.cs
└── appProjetoFinal.csproj
```

#### 1.5 Configuração Git e GitHub
**Caminho do Repositório Local:** `C:\GitHub\ExemplosApp`

**Passos:**
1. Criar pasta `C:\GitHub\ExemplosApp`
2. No VS: Alterações do Git → Criar Repositório Git
3. Apontar caminho local para `C:\GitHub\ExemplosApp`
4. Vincular ao GitHub: Autorizar VS → Criar repositório Private
5. Push inicial: "Confirmar Tudo e Sincronizar"

---

### 2. METADADOS DO PROJETO (.csproj) (Apostila 02-03)

#### 2.1 Propriedades Obrigatórias no .csproj

```xml
<PropertyGroup>
    <ApplicationTitle>Nome do Seu App</ApplicationTitle>
    <ApplicationId>br.edu.udf.nomeapp</ApplicationId>
    <ApplicationDisplayVersion>1.0.0</ApplicationDisplayVersion>
    <ApplicationVersion>100</ApplicationVersion>
</PropertyGroup>
```

**Regras:**
- **ApplicationTitle:** Nome amigável que o usuário vê
- **ApplicationId:** Domínio reverso OBRIGATÓRIO (br.edu.udf.nomedoprojeto)
- **ApplicationDisplayVersion:** 3 segmentos X.Y.Z (ex: 1.0.0)
- **ApplicationVersion:** Número inteiro sem pontos (ex: 100)

---

### 3. RECURSOS VISUAIS E ÍCONES (Apostila 04)

#### 3.1 MauiIcon - Configuração no .csproj

```xml
<MauiIcon Include="Resources\AppIcon\appicon.svg">
    <ForegroundFile>Resources\AppIcon\appiconfg.svg</ForegroundFile>
    <Color>#512BD4</Color>
    <TintColor>#FFFFFF</TintColor>
    <ForegroundScale>0.5</ForegroundScale>
</MauiIcon>
```

**Propriedades:**
- **Include:** Caminho do ícone de fundo
- **ForegroundFile:** Ícone de primeiro plano
- **Color:** Cor de fundo em hexadecimal
- **TintColor:** Cor da imagem de primeiro plano (#FFFFFF = branco)
- **ForegroundScale:** Redimensionamento (0.5 para centralizar)

#### 3.2 MauiSplashScreen - Configuração no .csproj

```xml
<MauiSplashScreen Include="Resources\Splash\splash.svg"
                  Color="#512BD4"
                  BaseSize="800,600" />
```

**Propriedades:**
- **Include:** Caminho da splash screen
- **Color:** Cor de fundo
- **BaseSize:** Tamanho base "LARGURA,ALTURA"

#### 3.3 Regras CRÍTICAS de Imagens

**Nomenclatura de Arquivos:**
- Letras **minúsculas** obrigatoriamente
- Sem acentuação
- Iniciar e terminar com letra
- Apenas caracteres alfanuméricos ou underscore (_)

**Regra TÉCNICA CRUCIAL:**
- Arquivos SVG são adicionados como .svg
- MAS no XAML devem ser referenciados como .png
- Exemplo: `bemvindo.svg` → XAML: `Source="bemvindo.png"`

---

### 4. ARQUITETURA DE NAVEGAÇÃO (Apostila 05-06)

#### 4.1 Limpeza do Projeto Boilerplate

**EXCLUIR os arquivos padrão:**
1. Gerenciador de Soluções (Ctrl+Alt+L)
2. Segurar Ctrl e clicar em:
   - `MainPage.xaml`
   - `AppShell.xaml`
3. Botão direito → Excluir → OK

#### 4.2 Criar Estrutura Views

Criar pasta `Views/` e adicionar:
- **FlyoutPage** (para menu lateral)
- OU **TabbedPage** (para abas, máximo 6)

#### 4.3 App.xaml.cs - Instanciar Navegação

```csharp
using SeuProjeto.Views;

namespace SeuProjeto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new FlyoutPageMenu());
        }
    }
}
```

#### 4.4 Estrutura FlyoutPage COMPLETA

**XAML da FlyoutPage:**
```xml
<FlyoutPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
            xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
            x:Class="SeuProjeto.Views.FlyoutPageMenu"
            FlyoutLayoutBehavior="Popover"
            Title="Menu Principal">

    <FlyoutPage.Flyout>
        <ContentPage Title="Menu">
            <StackLayout Padding="20">
                <Button Text="Página 1" Clicked="OnNavigatePage1"/>
                <Button Text="Página 2" Clicked="OnNavigatePage2"/>
            </StackLayout>
        </ContentPage>
    </FlyoutPage.Flyout>

    <FlyoutPage.Detail>
        <NavigationPage>
            <x:Arguments>
                <ContentPage Title="Bem-vindo">
                    <Label Text="Conteúdo Principal"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"/>
                </ContentPage>
            </x:Arguments>
        </NavigationPage>
    </FlyoutPage.Detail>

</FlyoutPage>
```

**Code-behind (C#):**
```csharp
private void OnNavigatePage1(object sender, EventArgs e)
{
    ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new Page1());
}

private void OnNavigatePage2(object sender, EventArgs e)
{
    ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new Page2());
}
```

**FlyoutLayoutBehavior:**
- **"Popover":** Página de detalhes cobre parcialmente o menu
- Menu lateral abre deslizando do canto esquerdo (Android)

#### 4.5 TabbedPage vs FlyoutPage

**TabbedPage:**
- Máximo de **6 abas**
- Abas na parte superior ou inferior
- Acesso rápido com um toque
- Usar quando: poucas seções principais

**FlyoutPage:**
- Menu lateral estilo sanduíche
- Sem limite de itens
- Menu não ocupa espaço permanente
- Usar quando: muitas opções de navegação

---

### 5. XAML E CONTROLES VISUAIS (Apostila 03, 07)

#### 5.1 StackLayout Completo

```xml
<StackLayout Orientation="Vertical"
             Padding="20"
             Spacing="10">
    <Label Text="Título"
           FontSize="24"
           TextColor="#512BD4"
           HorizontalOptions="Center"/>
    <Entry Placeholder="Digite algo"/>
    <Button Text="Clique Aqui"/>
</StackLayout>
```

#### 5.2 Grid Completo

```xml
<Grid RowDefinitions="Auto, *" 
      ColumnDefinitions="*, *"
      Padding="20">
    <Label Grid.Row="0" Grid.Column="0"
           Text="Nome:"/>
    <Entry Grid.Row="0" Grid.Column="1"
           Placeholder="Seu nome"/>
    <Label Grid.Row="1" Grid.Column="0"
           Text="Idade:"/>
    <Entry Grid.Row="1" Grid.Column="1"
           Placeholder="Sua idade"
           Keyboard="Numeric"/>
</Grid>
```

#### 5.3 Entry com Validação

```xml
<Entry x:Name="txtNome"
       Placeholder="Digite seu nome"
       ClearButtonVisibility="WhileEditing"/>
       
<Entry x:Name="txtSenha"
       Placeholder="Senha"
       IsPassword="True"
       ClearButtonVisibility="WhileEditing"/>
```

#### 5.4 Button com Evento

```xml
<Button Text="Salvar"
        Clicked="OnSalvarClicked"
        BackgroundColor="#512BD4"
        TextColor="White"/>
```

**C# Code-behind:**
```csharp
private async void OnSalvarClicked(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtNome.Text))
    {
        await DisplayAlert("Erro", "Campo nome obrigatório!", "OK");
        txtNome.Focus();
        return;
    }
    
    // Lógica de salvamento...
    await DisplayAlert("Sucesso", "Dados salvos!", "OK");
}
```

---

### 6. PERSISTÊNCIA DE DADOS - SQLite (Apostila 08)

#### 6.1 Instalar Pacote NuGet

**Pacote:** `sqlite-net-pcl`

```bash
dotnet add package sqlite-net-pcl
```

#### 6.2 Model - Classe POCO COMPLETA

```csharp
using SQLite;

namespace SeuProjeto.Model
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

        [MaxLength(100)]
        public string? pesEmail { get; set; }
    }
}
```

**Atributos SQLite:**
- **[Table("NomeTabela")]:** Define nome da tabela
- **[PrimaryKey]:** Chave primária
- **[AutoIncrement]:** Incremento automático
- **[Unique]:** Valor único
- **[NotNull]:** Não pode ser nulo
- **[MaxLength(N)]:** Tamanho máximo string

#### 6.3 DAL - crudSQLite COMPLETA

```csharp
using SQLite;
using SeuProjeto.Model;

namespace SeuProjeto.DAL
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _conexao;

        public crudSQLite(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            _conexao.CreateTableAsync<Pessoa>().Wait();
        }

        // CREATE
        public Task<int> Insert(Pessoa p)
        {
            return _conexao.InsertAsync(p);
        }

        // READ ALL
        public Task<List<Pessoa>> GetAll()
        {
            return _conexao.Table<Pessoa>().ToListAsync();
        }

        // UPDATE
        public Task<List<Pessoa>> Update(Pessoa p)
        {
            string sql = "UPDATE Pessoa SET pesNome=?, pesIdade=?, pesEmail=? WHERE pesID=?";
            return _conexao.QueryAsync<Pessoa>(sql, 
                p.pesNome, p.pesIdade, p.pesEmail, p.pesID);
        }

        // DELETE
        public Task<int> Delete(int id)
        {
            return _conexao.Table<Pessoa>().DeleteAsync(i => i.pesID == id);
        }

        // SEARCH
        public Task<List<Pessoa>> Search(string nome)
        {
            return _conexao.Table<Pessoa>()
                .Where(i => i.pesNome.Contains(nome))
                .ToListAsync();
        }
    }
}
```

**IMPORTANTE:** Todos os métodos são **async** e retornam **Task** para não travar a UI

#### 6.4 App.xaml.cs - Inicializar Banco (Singleton)

```csharp
using SeuProjeto.DAL;
using SeuProjeto.Views;

namespace SeuProjeto
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
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
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
            MainPage = new NavigationPage(new FlyoutPageMenu());
        }
    }
}
```

**Caminho Multiplataforma:**
- `LocalApplicationData` funciona automaticamente em:
  - Windows
  - Android
  - iOS
  - MacCatalyst

#### 6.5 Usar Banco no Code-behind

```csharp
private async void OnSalvarClicked(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtNome.Text))
    {
        await DisplayAlert("Erro", "Nome obrigatório!", "OK");
        return;
    }

    var pessoa = new Pessoa
    {
        pesNome = txtNome.Text,
        pesIdade = int.Parse(txtIdade.Text),
        pesEmail = txtEmail.Text
    };

    await App.Database.Insert(pessoa);
    await DisplayAlert("Sucesso", "Pessoa salva!", "OK");
    
    // Limpar campos
    txtNome.Text = string.Empty;
    txtIdade.Text = string.Empty;
    txtEmail.Text = string.Empty;
}
```

---

### 7. VALIDAÇÃO E UX (Apostila 07)

#### 7.1 Validação de Campos

```csharp
// Validar campo vazio ou apenas espaços
if (string.IsNullOrWhiteSpace(txtNome.Text))
{
    await DisplayAlert("Erro", "Campo obrigatório!", "OK");
    txtNome.Focus(); // Retorna foco
    return;
}
```

#### 7.2 DisplayAlertAsync

**Alerta Simples:**
```csharp
await DisplayAlert("Título", "Mensagem", "OK");
```

**Alerta com Confirmação:**
```csharp
bool resultado = await DisplayAlert(
    "Confirmação", 
    "Deseja realmente excluir?", 
    "Sim", 
    "Não"
);

if (resultado)
{
    // Usuário clicou "Sim"
}
```

**IMPORTANTE:** Métodos que usam `await` DEVEM ser marcados como `async`

---

### 8. CICLO DE VIDA E DEBUG

#### 8.1 Estados da Aplicação

- **Running:** App em execução ativa
- **Deactivated:** App em segundo plano
- **Stopped:** App fechado/parado

#### 8.2 Debug no Emulador

1. Selecionar "Android Emulator" como target
2. Escolher emulador (Nexus 5X API 29 x86_64)
3. F5 para depurar
4. Breakpoints funcionam normalmente

#### 8.3 Debug em Dispositivo Físico (Android)

1. Ativar "Modo Desenvolvedor" no celular
2. Ativar "Depuração USB"
3. Conectar via USB
4. Selecionar dispositivo no Visual Studio
5. F5 para instalar e depurar

#### 8.4 Limpeza de Solução

**Antes de deploy de novos recursos:**
1. VS → Compilação → Limpar Solução
2. Isso garante que recursos visuais sejam atualizados

---

### 9. NAVEGAÇÃO ENTRE PÁGINAS

#### 9.1 Navegação em FlyoutPage

```csharp
// Trocar página de detalhes
((FlyoutPage)App.Current.MainPage).Detail = 
    new NavigationPage(new NovaPagina());
```

#### 9.2 Navegação com NavigationPage

```csharp
// Empilhar página (hierárquica)
await Navigation.PushAsync(new DetalhesPage());

// Desempilhar (voltar)
await Navigation.PopAsync();
```

---

## CRONOGRAMA DO PROJETO FINAL

### Datas Importantes (2026)
- **19 de maio:** Sessão Projeto Final 1
- **26 de maio:** Sessão Projeto Final 2
- **02 de junho:** Sessão Projeto Final 3
- **09 de junho:** Prova Regimental A1
- **16 de junho:** Resultados A1

### Funcionalidades Esperadas no Projeto Final

**Mínimo Obrigatório:**
1. **Arquitetura:** MVVM + DAL
2. **Navegação:** FlyoutPage OU TabbedPage (mínimo 3 telas)
3. **Interface:** Componentes Entry, Button, Label, imagens
4. **Persistência:** SQLite com CRUD completo
5. **Validação:** Campos obrigatórios, alertas
6. **Controle de Versão:** GitHub com commits

---

## OUTPUT ESPERADO

Gerar um arquivo Markdown contendo:

1. **Introdução:** Visão geral do projeto
2. **Arquitetura:** MVVM + DAL diagrama
3. **Estrutura de Arquivos:** Árvore completa
4. **Especificações de Cada Arquivo:**
   - Nome do arquivo
   - Caminho completo
   - Código COMPLETO (cada linha)
   - Explicação de cada bloco
5. **Banco de Dados:** Schema, DAL, Model
6. **Telas/Views:** XAML + Code-behind
7. **Navegação:** Fluxo entre telas
8. **Validação e UX:** Regras de negócio
9. **Deploy:** Passos para gerar APK/instalar

---

## INSTRUÇÕES PARA CLAUDE CODE

1. **Ler primeiro:** Use `ls -R` para ver estrutura atual
2. **Comparar:** Identifique o que já existe vs especificação
3. **Implementar:** Crie/altere arquivos seguindo EXATAMENTE as especificações acima
4. **Validar:** Verifique se cada linha de código segue os padrões das apostilas
5. **Testar:** Compile e execute no emulador
6. **Documentar:** Gere o SDD em Markdown

---

## NOTAS FINAIS

- **NUNCA** use nomes de recursos com maiúsculas ou acentos
- **SEMPRE** referencie SVG como .png no XAML
- **TODOS** os métodos de banco DEVEM ser async/await
- **SEMPRE** valide campos com `string.IsNullOrWhiteSpace`
- **USE** `LocalApplicationData` para caminho do banco
- **OBRIGATÓRIO** domínio reverso em ApplicationId (br.edu.udf.*)

---

**Baseado em:** Apostilas 01-09 PDM 2026 + Plano de Aula  
**NotebookLM ID:** d7c17a87-6c17-4953-aa67-9cacd31e7a35  
**Framework:** .NET MAUI 10.0 LTS  
**IDE:** Visual Studio 2026 Community  
**Linguagem:** C# 12 / XAML

---

## 🆕 APOSTILA 09 - LISTVIEW E COLLECTIONS (NOVO!)

### 9.1 ListView COM ObservableCollection

**TelaLista.xaml - Lista Dinâmica:**
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="SeuProjeto.Views.TelaLista"
             Title="Lista de Itens">
    
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Incluir" 
                    IconImageSource="iconincluir.png" 
                    Clicked="OnIncluirClicked" />
    </ContentPage.ToolbarItems>
    
    <ContentPage.Content>
        <StackLayout>
            <SearchBar x:Name="txtBusca" 
                      Placeholder="Buscar..." 
                      TextChanged="OnBuscarTextChanged" />
            
            <ListView x:Name="lstItens" 
                     IsPullToRefreshEnabled="True" 
                     Refreshing="OnRefreshing" 
                     ItemSelected="OnItemSelected">
                
                <ListView.Header>
                    <Grid ColumnDefinitions="*, *, *">
                        <Label Grid.Column="0" Text="ID" FontAttributes="Bold" />
                        <Label Grid.Column="1" Text="Nome" FontAttributes="Bold" />
                        <Label Grid.Column="2" Text="Detalhe" FontAttributes="Bold" />
                    </Grid>
                </ListView.Header>
                
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <ViewCell.ContextActions>
                                <MenuItem Text="Excluir" 
                                         IconImageSource="iconexcluir.png" 
                                         Clicked="OnExcluirClicked" />
                            </ViewCell.ContextActions>
                            
                            <Grid ColumnDefinitions="*, *, *">
                                <Label Grid.Column="0" Text="{Binding Id}" />
                                <Label Grid.Column="1" Text="{Binding Nome}" />
                                <Label Grid.Column="2" Text="{Binding Detalhe}" />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

### 9.2 Code-Behind com ObservableCollection

```csharp
using System.Collections.ObjectModel;

public partial class TelaLista : ContentPage
{
    public ObservableCollection<SeuItem> ListaItens { get; set; }

    public TelaLista()
    {
        InitializeComponent();
        ListaItens = new ObservableCollection<SeuItem>();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        var lista = await App.Database.GetAll();
        ListaItens.Clear();
        
        foreach (var item in lista)
        {
            ListaItens.Add(item);
        }
        
        lstItens.ItemsSource = ListaItens;
    }

    private async void OnBuscarTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            var lista = await App.Database.GetAll();
            ListaItens.Clear();
            foreach (var item in lista)
            {
                ListaItens.Add(item);
            }
        }
        else
        {
            var lista = await App.Database.Search(e.NewTextValue);
            ListaItens.Clear();
            foreach (var item in lista)
            {
                ListaItens.Add(item);
            }
        }
        
        lstItens.ItemsSource = ListaItens;
    }

    private async void OnRefreshing(object sender, EventArgs e)
    {
        var lista = await App.Database.GetAll();
        ListaItens.Clear();
        foreach (var item in lista)
        {
            ListaItens.Add(item);
        }
        
        lstItens.ItemsSource = ListaItens;
        lstItens.EndRefresh();
    }
}
```

### 9.3 Componentes NOVOS OBRIGATÓRIOS

- **ListView:** `IsPullToRefreshEnabled`, `ItemsSource`, `ItemSelected`
- **SearchBar:** `Placeholder`, `TextChanged` (busca em tempo real)
- **ToolbarItem:** `Text`, `IconImageSource`, `Clicked`
- **ViewCell.ContextActions:** Menu swipe com `MenuItem`
- **ObservableCollection:** Atualização automática de UI
- **DataBinding:** `{Binding NomePropriedade}`
- **OnAppearing():** Override para recarregar dados

### 9.4 NOVAS Imagens Necessárias

- `iconincluir.png` (ToolbarItem)
- `iconexcluir.png` (MenuItem)
- `fundo.png` (BackgroundImageSource)

---
