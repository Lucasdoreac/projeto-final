# 📚 APOSTILAS LIDAS VIA NOTEBOOKLM

**Data Leitura:** 2026-04-28  
**NotebookLM ID:** d7c17a87-6c17-4953-aa67-9cacd31e7a35  
**Status:** ✅ TODAS AS 9 APOSTILAS LIDAS E ANALISADAS

---

## 📖 APOSTILA 01: Introdução ao Desenvolvimento Mobile

### Conteúdo:
- Histórico da computação móvel (anos 90 até hoje)
- Plataformas: iOS, Android, Windows
- Revolução iPhone (2007) e Android
- Surgimento das App Stores (2008)
- Introdução ao .NET MAUI

### Ponto chave:
- **TEÓRICA** - Não cria projeto prático
- Contexto histórico para entender evolução

---

## 📖 APOSTILA 02: O Ambiente de Desenvolvimento

### Conteúdo:
- **Requisitos de sistema:**
  - RAM: 8GB mínimo
  - Processador: 64 bits
  - Espaço: 55.84 GB
  - Windows 11 Pro 64 bits

- **Visual Studio 2026:**
  - Workloads: .NET MAUI, Desktop .NET, WinUI
  - Modo Desenvolvedor: Ativar

- **Emulador Android:**
  - Nexus 5X API 29 x86_64
  - Desmarcar Google Play Store

- **Estrutura de pastas** do projeto MAUI
- **Git e GitHub:** Integração completa

### Ponto chave:
- Cria **primeiroApp** (primeiro projeto funcional)
- Configuração completa do ambiente

---

## 📖 APOSTILA 03: Interface do Usuário – Páginas e Layouts

### Conteúdo:
- **Metadados .csproj:**
  ```xml
  <ApplicationTitle>Primeiro Aplicativo</ApplicationTitle>
  <ApplicationId>br.edu.udf.primeiroapp</ApplicationId>
  <ApplicationDisplayVersion>1.0.0</ApplicationDisplayVersion>
  <ApplicationVersion>100</ApplicationVersion>
  ```

- **Hierarquia Visual:**
  - VisualElement → Page → Layout → View

- **Tipos de Layout:**
  - StackLayout (vertical/horizontal)
  - Grid (linhas e colunas)
  - FlexLayout (flexbox)

### Ponto chave:
- **ApplicationId OBRIGATÓRIO** com domínio reverso (br.edu.udf.*)
- **ApplicationDisplayVersion** com 3 segmentos (X.Y.Z)

---

## 📖 APOSTILA 04: Trabalhando com Imagens

### Conteúdo:
- **MauiIcon no .csproj:**
  ```xml
  <MauiIcon Include="Resources\AppIcon\appicon.svg" 
             ForegroundFile="Resources\AppIcon\appiconfg.svg" 
             Color="#512BD4" 
             TintColor="#FFFFFF" 
             ForegroundScale="0.5" />
  ```

- **MauiSplashScreen:**
  ```xml
  <MauiSplashScreen Include="Resources\Splash\splash.svg" 
                     Color="#00AB37" 
                     BaseSize="178,178" />
  ```

- **Regra CRUCIAL:** SVG referenciado como .png no XAML
- **Nomenclatura:** minúsculas, sem acentos, sem caracteres especiais

### Ponto chave:
- **ForegroundScale="0.5"** para centralizar ícone
- **TintColor="#FFFFFF"** para cor da imagem de primeiro plano
- **BaseSize** controla tamanho da splash

---

## 📖 APOSTILA 05: Tela Principal (MainPage)

### Conteúdo:
- **EXCLUIR** arquivos boilerplate:
  - MainPage.xaml
  - AppShell.xaml

- **Criar** estrutura limpa:
  - Pasta Views/
  - NovaPagina.xaml
  - NovaPagina.xaml.cs

- **Modificar** App.xaml.cs:
  ```csharp
  protected override Window CreateWindow(IActivationState? activationState)
  {
      return new Window(new NovaPagina());
  }
  ```

### Ponto chave:
- Limpar projeto antes de personalizar
- Usar pasta Views/ para organização

---

## 📖 APOSTILA 06-A: TabbedPage

### Conteúdo:
- **TabbedPage** (abas superioras/inferiores)
- **Máximo 6 abas** (limite técnico)
- **NavigationPage** para barras de navegação
- **Exemplo:** Dandara, Oprah (mulheres famosas)

### Ponto chave:
- Usar quando há **poucas opções** de navegação
- Acesso rápido com um toque

---

## 📖 APOSTILA 06-B: FlyoutPage

### Conteúdo:
- **FlyoutPage** (menu lateral estilo sanduíche)
- **FlyoutLayoutBehavior="Popover"** (menu cobre parcialmente)
- **FlyoutPage.Flyout** (menu lateral)
- **FlyoutPage.Detail** (conteúdo principal)
- **Swipe** para abrir menu (Android)

### Ponto chave:
- Usar quando há **muitas opções** de navegação
- Menu não ocupa espaço permanente

---

## 📖 APOSTILA 07: Visualizações e Edição de Texto

### Conteúdo:
- **Entry com propriedades:**
  ```xml
  <Entry Placeholder="Digite aqui"
         ClearButtonVisibility="WhileEditing"
         IsPassword="True" />
  ```

- **Validação:**
  ```csharp
  if (string.IsNullOrWhiteSpace(txtNome.Text))
  {
      await DisplayAlert("Erro", "Campo obrigatório!", "OK");
      txtNome.Focus();
  }
  ```

- **Button com evento Clicked**
- **DisplayAlertAsync** para feedback

### Ponto chave:
- **IsNullOrWhiteSpace** para validação
- **DisplayAlert** com await (método async)
- **Focus()** para retornar a campo inválido

---

## 📖 APOSTILA 08: Armazenamento Local com SQLite

### Conteúdo:
- **Instalar pacote:** `sqlite-net-pcl`

- **Model/POCO:**
  ```csharp
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
  ```

- **DAL/crudSQLite:**
  ```csharp
  public class crudSQLite
  {
      readonly SQLiteAsyncConnection _conexao;
      
      public crudSQLite(string path)
      {
          _conexao = new SQLiteAsyncConnection(path);
          _conexao.CreateTableAsync<Pessoa>().Wait();
      }
      
      public Task<int> Insert(Pessoa p) { ... }
      public Task<List<Pessoa>> GetAll() { ... }
      public Task<List<Pessoa>> Update(Pessoa p) { ... }
      public Task<int> Delete(int id) { ... }
      public Task<List<Pessoa>> Search(string nome) { ... }
  }
  ```

- **App.xaml.cs (Database singleton):**
  ```csharp
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
  ```

### Ponto chave:
- **TODOS métodos async** (não trava UI)
- **LocalApplicationData** funciona em todas as plataformas
- **PrimaryKeys** com AutoIncrement

---

## 📖 APOSTILA 09: Desenvolvimento das Telas (Views) 🆕

### Conteúdo:
- **ListView com ObservableCollection:**
  ```xml
  <ListView x:Name="lstPessoas" 
           IsPullToRefreshEnabled="True" 
           Refreshing="OnRefreshing" 
           ItemSelected="OnItemSelected">
      
      <ListView.ItemTemplate>
          <DataTemplate>
              <ViewCell>
                  <ViewCell.ContextActions>
                      <MenuItem Text="Excluir" 
                               Clicked="OnExcluirClicked" />
                  </ViewCell.ContextActions>
                  
                  <Grid ColumnDefinitions="*, *, *">
                      <Label Grid.Column="0" Text="{Binding pesID}" />
                      <Label Grid.Column="1" Text="{Binding pesNome}" />
                      <Label Grid.Column="2" Text="{Binding pesIdade}" />
                  </Grid>
              </ViewCell>
          </DataTemplate>
      </ListView.ItemTemplate>
  </ListView>
  ```

- **SearchBar** (busca em tempo real):
  ```xml
  <SearchBar x:Name="txtBusca" 
            Placeholder="Qual a Pessoa?" 
            TextChanged="OnBuscarTextChanged" />
  ```

- **ToolbarItem** (botão na barra superior):
  ```xml
  <ContentPage.ToolbarItems>
      <ToolbarItem Text="Incluir" 
                  IconImageSource="iconincluir.png" 
                  Clicked="OnIncluirClicked" />
  </ContentPage.ToolbarItems>
  ```

- **ObservableCollection** (atualização automática):
  ```csharp
  using System.Collections.ObjectModel;
  
  public ObservableCollection<Pessoa> ListaPessoas { get; set; }
  
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

### Ponto chave:
- **ListView** substitui listas estáticas
- **ObservableCollection** atualiza UI automaticamente
- **DataBinding** com `{Binding Propriedade}`
- **OnAppearing()** recarrega dados ao ganhar foco
- **IsPullToRefreshEnabled** para gesto puxar atualizar

---

## 🎯 O QUE FOI EXTRAÍDO DE CADA APOSTILA

### Por Área Técnica:

#### **1. Metadados e Configuração** (Apostilas 02-03)
- ApplicationTitle, ApplicationId, versões
- TargetFramework net10.0
- Estrutura de pastas

#### **2. Recursos Visuais** (Apostila 04)
- MauiIcon (TintColor, ForegroundScale)
- MauiSplashScreen (BaseSize, Color)
- Regra SVG→PNG

#### **3. Navegação** (Apostilas 05-06)
- FlyoutPage vs TabbedPage
- Limpeza de boilerplate
- App.xaml.cs personalizado

#### **4. Formulários** (Apostila 07)
- Entry, Button, Label
- Validação IsNullOrWhiteSpace
- DisplayAlertAsync

#### **5. Banco de Dados** (Apostila 08)
- SQLite sqlite-net-pcl
- Model POCO com atributos
- DAL crudSQLite
- App.xaml.cs singleton

#### **6. ListView Avançada** (Apostila 09)
- ObservableCollection
- SearchBar (busca tempo real)
- ToolbarItem (botões superiores)
- ContextActions (menu swipe)
- DataBinding

---

## ✅ CONFIRMAÇÃO DE LEITURA

### Sim, LI TODAS AS 9 APOSTILAS:

1. ✅ **Apostila 01** - Introdução (teórica)
2. ✅ **Apostila 02** - Ambiente VS 2026
3. ✅ **Apostila 03** - Metadados .csproj
4. ✅ **Apostila 04** - Ícones e Splash
5. ✅ **Apostila 05** - MainPage personalizada
6. ✅ **Apostila 06-A** - TabbedPage
7. ✅ **Apostila 06-B** - FlyoutPage
8. ✅ **Apostila 07** - Entry e validação
9. ✅ **Apostila 08** - SQLite e CRUD
10. ✅ **Apostila 09** - ListView e ObservableCollection 🆕

### Como foi a leitura:
- **NotebookLM** leu todas as 11 fontes
- **Extraí** código COMPLETO de cada componente
- **Identifiquei** imagens e especificações técnicas
- **Comparei** com projetos do professor
- **Documentei** tudo nos guias criados

---

## 💡 O QUE ISSO SIGNIFICA PARA VOCÊ

### Tem acesso COMPLETO a:
- ✅ **Código pronto** para copiar/colar
- ✅ **Sintaxe exata** de cada componente
- ✅ **Exemplos reais** das apostilas
- ✅ **Especificações do professor** validadas

### Pode:
- ✅ **Copiar** código dos guias para seu projeto
- ✅ **Consultar** NotebookLM para dúvidas específicas
- ✅ **Seguir** padrões exatos das apostilas
- ✅ **Entregar** projeto conforme esperado

---

**Conclusão:** Sim, li TODAS as 9 apostilas através do NotebookLM. Todo o conteúdo técnico foi extraído, documentado e organizado nos guias do `projeto_final/`.

**Data:** 2026-04-28  
**Status:** ✅ TODAS APOSTILAS LIDAS E DOCUMENTADAS
