# 🚀 PROJETO FINAL - TEMA LIVRE - GUIA COMPLETO

**Disciplina:** Programação Para Dispositivos Móveis 2026  
**NotebookLM ID:** d7c17a87-6c17-4953-aa67-9cacd31e7a35  
**Período:** Maio-Junho 2026 (Encontros 25-30)  
**Cronograma:** 19/05, 26/05, 02/06 (3 sessões duplas)

---

## ✅ SIM! PODE CRIAR PROJETO TOTALMENTE LIVRE

### O que é permitido:
- ✅ **Tema 100% livre:** Jogos, finanças, saúde, educação, qualquer área
- ✅ **Imagens próprias:** Pode usar SVGs personalizados ( Creative Commons)
- ✅ **Identidade visual própria:** Ícone, splash screen, cores customizadas
- ✅ **Funcionalidades criativas:** Desde que siga os requisitos técnicos

### Requisitos TÉCNICOS OBRIGATÓRIOS:

#### 1. Estrutura de Código (OBRIGATÓRIO)
```
SeuProjetoFinal/
├── Model/              # Classes POCO (dados)
├── DAL/                # Data Access Layer (SQLite)
├── Views/              # Páginas XAML
├── Resources/          # Imagens, ícones, fontes
├── App.xaml            # Inicialização
└── SeuProjetoFinal.csproj
```

#### 2. Componentes MAUI OBRIGATÓRIOS
- ✅ **Entry:** Entrada de texto/senhas
- ✅ **Button:** Botões com eventos Clicked
- ✅ **Label:** Exibição de texto
- ✅ **FlyoutPage OU TabbedPage:** Navegação principal
- ✅ **SQLite:** Banco de dados local

#### 3. Funcionalidades MÍNIMAS
- ✅ **CRUD Completo:**
  - **C**reate (Inserir dados)
  - **R**ead (Listar/Pesquisar)
  - **U**pdate (Alterar)
  - **D**elete (Excluir)

- ✅ **Validação de Campos:**
  - `string.IsNullOrWhiteSpace()`
  - `DisplayAlertAsync()` para feedback

- ✅ **Navegação Funcional:**
  - Mínimo 3 telas/páginas
  - Menu ou abas funcionais

#### 4. Metadados OBRIGATÓRIOS (.csproj)
```xml
<ApplicationTitle>Seu App Criativo</ApplicationTitle>
<ApplicationId>br.edu.udf.seuapp</ApplicationId>
<ApplicationDisplayVersion>1.0.0</ApplicationDisplayVersion>
<ApplicationVersion>100</ApplicationVersion>
```

---

## 🎮 IDEIAS DE TEMAS LIVRES

### Área: Jogos
- **Quiz App:** Perguntas e respostas com pontuação
- **Memory Game:** Jogo da memória com tempos
- **Tic-Tac-Toe:** Jogo da velha multiplayer local
- **Word Search:** Caça-palavras customizável

### Área: Finanças
- **Controle Financeiro:** Receitas/Despesas com gráficos
- **Meta de Economia:** Acompanhamento de objetivos
- **Conversor de Moedas:** Cotação em tempo real
- **Calculadora de Gorjetas:** Divisão de contas

### Área: Saúde
- **Contador de Água:** Hidratação diária
- **Tracker de Exercícios:** Academia/corrida
- **Calculadora IMC:** Índice de massa corporal
- **Lembrete de Remédios:** Alarmes para medicamentos

### Área: Educação
- **Flashcards:** Estudo com cartões de memória
- **Lista de Tarefas:** Todo list com prioridades
- **Gerenciador de Provas:** Cronograma de estudos
- **Tradutor Rápido:** Múltiplas línguas

### Área: Produtividade
- **Password Manager:** Senhas seguras localmente
- **Notes App:** Anotações com categorias
- **Habit Tracker:** Hábitos diários
- **Pomodoro Timer:** Técnica de foco

---

## 🛠️ ESTRUTURA TÉCNICA OBRIGATÓRIA

### 1. Model - Classe POCO (Exemplo)
```csharp
using SQLite;

namespace SeuAppFinal.Model
{
    [Table("SeuItem")]
    public class SeuItem
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Nome { get; set; }

        [MaxLength(500)]
        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
```

### 2. DAL - crudSQLite (Exemplo)
```csharp
using SQLite;
using SeuAppFinal.Model;

namespace SeuAppFinal.DAL
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _conexao;

        public crudSQLite(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            _conexao.CreateTableAsync<SeuItem>().Wait();
        }

        // CREATE
        public Task<int> Insert(SeuItem item)
        {
            return _conexao.InsertAsync(item);
        }

        // READ ALL
        public Task<List<SeuItem>> GetAll()
        {
            return _conexao.Table<SeuItem>().ToListAsync();
        }

        // UPDATE
        public Task<List<SeuItem>> Update(SeuItem item)
        {
            string sql = "UPDATE SeuItem SET Nome=?, Descricao=? WHERE Id=?";
            return _conexao.QueryAsync<SeuItem>(sql, 
                item.Nome, item.Descricao, item.Id);
        }

        // DELETE
        public Task<int> Delete(int id)
        {
            return _conexao.Table<SeuItem>().DeleteAsync(i => i.Id == id);
        }

        // SEARCH
        public Task<List<SeuItem>> Search(string nome)
        {
            return _conexao.Table<SeuItem>()
                .Where(i => i.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
```

### 3. App.xaml.cs - Database Singleton
```csharp
using SeuAppFinal.DAL;
using SeuAppFinal.Views;

namespace SeuAppFinal
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
                        "seuapp.db3"
                    );
                    database = new crudSQLite(path);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SeuFlyoutPage());
        }
    }
}
```

### 4. Views - FlyoutPage (Exemplo)
```xml
<FlyoutPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
            xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
            x:Class="SeuAppFinal.Views.SeuFlyoutPage"
            FlyoutLayoutBehavior="Popover">

    <FlyoutPage.Flyout>
        <ContentPage Title="Menu">
            <StackLayout Padding="20" Spacing="10">
                <Label Text="Seu App" 
                       FontSize="24" 
                       HorizontalOptions="Center"/>
                <Button Text="🏠 Início" 
                        Clicked="OnHomeClicked"/>
                <Button Text="➕ Adicionar" 
                        Clicked="OnAddClicked"/>
                <Button Text="📋 Listar" 
                        Clicked="OnListClicked"/>
                <Button Text="⚙️ Configurações" 
                        Clicked="OnSettingsClicked"/>
            </StackLayout>
        </ContentPage>
    </FlyoutPage.Flyout>

    <FlyoutPage.Detail>
        <NavigationPage>
            <x:Arguments>
                <ContentPage Title="Bem-vindo">
                    <Label Text="Seu App Criativo!"
                           VerticalOptions="Center"
                           HorizontalOptions="Center"/>
                </ContentPage>
            </x:Arguments>
        </NavigationPage>
    </FlyoutPage.Detail>

</FlyoutPage>
```

### 5. Views - Cadastro (Exemplo)
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="SeuAppFinal.Views.CadastroPage"
             Title="Adicionar Item">

    <StackLayout Padding="20" Spacing="15">
        
        <Label Text="Nome:" 
               FontSize="16"
               FontAttributes="Bold"/>
        <Entry x:Name="txtNome"
               Placeholder="Digite o nome..."
               ClearButtonVisibility="WhileEditing"/>

        <Label Text="Descrição:" 
               FontSize="16"
               FontAttributes="Bold"/>
        <Entry x:Name="txtDescricao"
               Placeholder="Digite a descrição..."
               ClearButtonVisibility="WhileEditing"/>

        <Button Text="💾 Salvar"
                Clicked="OnSalvarClicked"
                BackgroundColor="#512BD4"
                TextColor="White"
                Margin="0,20,0,0"/>

        <Button Text="❌ Cancelar"
                Clicked="OnCancelarClicked"
                BackgroundColor="#FF0000"
                TextColor="White"/>

    </StackLayout>

</ContentPage>
```

### 6. Code-behind - Validação (Exemplo)
```csharp
private async void OnSalvarClicked(object sender, EventArgs e)
{
    // Validação OBRIGATÓRIA
    if (string.IsNullOrWhiteSpace(txtNome.Text))
    {
        await DisplayAlert("Erro", 
                          "Campo nome é obrigatório!", 
                          "OK");
        txtNome.Focus();
        return;
    }

    if (string.IsNullOrWhiteSpace(txtDescricao.Text))
    {
        await DisplayAlert("Erro", 
                          "Campo descrição é obrigatório!", 
                          "OK");
        txtDescricao.Focus();
        return;
    }

    // Criar objeto
    var item = new SeuItem
    {
        Nome = txtNome.Text,
        Descricao = txtDescricao.Text,
        DataCriacao = DateTime.Now
    };

    // Salvar no banco
    await App.Database.Insert(item);

    await DisplayAlert("Sucesso!", 
                      "Item salvo com sucesso!", 
                      "OK");

    // Limpar campos
    txtNome.Text = string.Empty;
    txtDescricao.Text = string.Empty;
}
```

---

## 🎨 IDENTIDADE VISUAL PRÓPRIA

### 1. Ícone Personalizado (.csproj)
```xml
<MauiIcon Include="Resources\AppIcon\seuicone.svg"
          ForegroundScale="0.5"
          TintColor="#FFFFFF"
          Color="#SUA_COR" />
```

### 2. Splash Screen Personalizada (.csproj)
```xml
<MauiSplashScreen Include="Resources\Splash\seusplash.svg"
                  Color="#SUA_COR"
                  BaseSize="800,600" />
```

### 3. Imagens Próprias
- ✅ Usar formato **SVG** (preferencial)
- ✅ Nomes em **minúsculas**, sem acentos
- ✅ Licença **Creative Commons** (se usar da internet)
- ✅ Referenciar no XAML como **.png** (mesmo sendo .svg)

---

## 📋 CHECKLIST DE ENTREGA

### Estrutura de Pastas
- [ ] Model/ criada com classe POCO
- [ ] DAL/ criada com crudSQLite
- [ ] Views/ criada com páginas XAML
- [ ] Resources/ com imagens personalizadas

### Funcionalidades CRUD
- [ ] **CREATE:** Botão/formulário para inserir
- [ ] **READ:** Tela/lista para mostrar dados
- [ ] **UPDATE:** Botão/editar para alterar
- [ ] **DELETE:** Botão/excluir para remover

### Validação e UX
- [ ] `string.IsNullOrWhiteSpace()` em campos obrigatórios
- [ ] `DisplayAlertAsync()` para feedback ao usuário
- [ ] Foco automático em campos inválidos

### Navegação
- [ ] FlyoutPage OU TabbedPage funcionando
- [ ] Mínimo 3 telas/páginas navegáveis
- [ ] Menu ou abas com ícones/textos claros

### Identidade Visual
- [ ] Ícone personalizado (não é o padrão MAUI)
- [ ] Splash screen personalizada
- [ ] Cores/theme consistentes
- [ ] ApplicationTitle criativo
- [ ] ApplicationId: br.edu.udf.seuapp

### Código Limpo
- [ ] Nomes de variáveis significativos
- [ ] Comentários em código complexo
- [ ] Organização lógica de arquivos
- [ ] GitHub com commits descritivos

---

## 🎯 CRITÉRIOS DE AVALIAÇÃO

### Design de Interfaces (Peso alto)
- Uso de técnicas de design e prototipagem
- Interface intuitiva e responsiva
- Identidade visual coesa

### Funcionalidades Especiais (Peso alto)
- Recursos avançados além do básico
- Criatividade na solução de problemas
- Inovação no tema escolhido

### Qualidade Técnica (Peso alto)
- Implementação correta das ferramentas
- Código limpo e organizado
- Persistência de dados eficiente
- Validação robusta

### Critérios Bonus
- [ ] Animações/transições
- [ ] Gráficos/relatórios
- [ ] Busca/filtros avançados
- [ ] Export/import de dados
- [ ] Tema escuro/claro
- [ ] Multi-idiomas

---

## 🚀 COMEÇAR AGORA - ROTEIRO SUGERIDO

### Semana 1 (19/05): Setup e Estrutura
1. Criar projeto .NET MAUI no VS 2026
2. Configurar metadados (.csproj)
3. Criar estrutura Model/DAL/Views
4. Implementar classe POCO
5. Implementar crudSQLite

### Semana 2 (26/05): Interface e CRUD
1. Criar FlyoutPage/TabbedPage
2. Implementar tela de cadastro (CREATE)
3. Implementar tela de listagem (READ)
4. Adicionar validação de campos
5. Testar INSERT e SELECT

### Semana 3 (02/06): Refinamento e Deploy
1. Implementar UPDATE (edição)
2. Implementar DELETE (exclusão)
3. Adicionar SEARCH/Pesquisa
4. Personalizar ícone/splash
5. Testar em emulador/dispositivo
6. Fazer deploy e documentar

---

## 💡 DICAS PARA SUCESSO

### Tema Escolhido
- ✅ Escolha algo que você GOSTA
- ✅ Pense em um problema REAL para resolver
- ✅ Mantenha escopo gerenciável (não faça algo gigante)

### Implementação
- ✅ Comece SIMPLES, evolua depois
- ✅ Teste CADA funcionalidade antes de avançar
- ✅ Use commits descritivos no GitHub
- ✅ Backup frequentemente

### Avaliação
- ✅ Interface conta MUITO (capriche no UX)
- ✅ Validação é OBRIGATÓRIA (não esqueça)
- ✅ CRUD completo é essencial
- ✅ Código limpo impressiona o professor

---

## 📚 RECURSOS NOTEBOOKLM

### Especificações por Apostila:
- **Apostila 02:** Setup VS 2026, workloads
- **Apostila 03:** Metadados .csproj, ApplicationId
- **Apostila 04:** Ícones, splash screen, SVG→PNG
- **Apostila 05:** Estrutura Views, limpar boilerplate
- **Apostila 06-A:** TabbedPage (abas)
- **Apostila 06-B:** FlyoutPage (menu lateral)
- **Apostila 07:** Entry, Button, validação
- **Apostila 08:** SQLite, Model, DAL, CRUD

### NotebookLM ID:
`d7c17a87-6c17-4953-aa67-9cacd31e7a35`

---

**Conclusão:** Você tem LIBERDADE CRIATIVA TOTAL para o tema, mas deve seguir os REQUISITOS TÉCNICOS OBRIGATÓRIOS. O importante é demonstrar domínio das ferramentas .NET MAUI, SQLite, validação e UX, aplicadas a um tema que você se identifique.

**Data criação:** 2026-04-28  
**Status:** Pronto para projeto final com tema livre  
**Próximos passos:** Escolher tema → Criar estrutura → Implementar CRUD → Personalizar visual → Testar e entregar
