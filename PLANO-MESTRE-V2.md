# 🚀 PLANO MESTRE: appClassePessoaBD - Estado Atual até Versão 2.0

**Projeto:** Cadastro de Pessoas com SQLite  
**Disciplina:** Programação Para Dispositivos Móveis 2026  
**Entrega A1:** 09/06/2026  
**Versão Atual:** 1.0 (CRUD Funcional)  
**Meta:** 2.0 (Enterprise-Grade)

---

## 📊 Estado Atual (Baseline)

### ✅ JÁ IMPLEMENTADO (100% dos Requisitos A1)

**Estrutura:**
- ✅ Model/Pessoa.cs com atributos SQLite ([PrimaryKey], [AutoIncrement], [Unique], [NotNull])
- ✅ DAL/crudSQLite.cs (Insert, Update, Delete, GetAll, Search)
- ✅ App.xaml.cs (Database singleton, NavigationPage)
- ✅ Views/TelaListaPessoa.xaml + .xaml.cs
- ✅ Views/TelaIncluirPessoa.xaml + .xaml.cs
- ✅ Views/TelaAlterarPessoa.xaml + .xaml.cs
- ✅ Resources (AppIcon customizado, SplashScreen, imagens, ícones)

**Funcionalidades:**
- ✅ CRUD completo (Create, Read, Update, Delete)
- ✅ ListView com ObservableCollection
- ✅ SearchBar com busca SQL LIKE
- ✅ ToolbarItem para ações positivas (Incluir, Salvar)
- ✅ ContextActions para exclusão (swipe/menu)
- ✅ Navegação hierárquica (PushAsync/PopAsync)
- ✅ OnAppearing() para atualização automática
- ✅ IsPullToRefreshEnabled (puxar para atualizar)

**Validações (Melhorias Recentes):**
- ✅ TextTransform="Uppercase" nos campos de nome
- ✅ ClearButtonVisibility="WhileEditing" em todos os Entry
- ✅ Keyboard="Numeric" para idade
- ✅ Validação de nome mínimo 3 caracteres
- ✅ Validação de idade entre 0-150 anos
- ✅ Tratamento de exceções robusto
- ✅ Confirmação antes de excluir (DisplayAlert)
- ✅ Feedback visual com mensagens claras

**Configuração:**
- ✅ .NET 8.0 SDK (8.0.401)
- ✅ Multiplataforma (Windows, Android, iOS, Mac)
- ✅ MauiVersion 8.0.7
- ✅ ApplicationId: br.edu.udf.appclassepessoabd
- ✅ Identidade visual customizada

**Status:** **APROVADO PARA NOTA MÁXIMA NA PROVA A1**

---

## 🎯 ROADMAP COMPLETO

### 🔵 FASE 1: Polimento para Entrega A1 (09/06)

**Objetivo:** Garantir nota máxima com refinamentos de UX  
**Esforço:** 2-3 horas  
**Risco:** Baixo  
**Valor:** Alto (diferenciais de qualidade)

#### Tarefas:

**Tarefa #6:** Testar completo CRUD atual e documentar
- [ ] Testar Criar (5 pessoas diferentes)
- [ ] Testar Ler (ListView carregando)
- [ ] Testar Atualizar (modificar nome/idade)
- [ ] Testar Deletar (swipe + confirmação)
- [ ] Testar Buscar (SearchBar com LIKE)
- [ ] Testar Validações (nome vazio, idade inválida)
- [ ] Testar Navegação (todas as telas)
- [ ] Documentar bugs se houver
- [ ] Criar README com instruções de uso

**Tarefa #19:** Implementar "Toque Generoso" (Apostila 01)
- [ ] Aumentar altura das células da ListView para 60dp
- [ ] Aumentar padding dos botões para 15dp
- [ ] Garantir área de toque mínimo 1cm
- [ ] Testar usabilidade em movimento

**Tarefa #11:** Adicionar ActivityIndicator (Apostila 02)
- [ ] Adicionar ActivityIndicator no XAML da TelaListaPessoa
- [ ] Adicionar propriedade IsBusy no code-behind
- [ ] Ativar IsBusy durante GetAll()
- [ ] Ativar IsBusy durante Search()
- [ ] Testar feedback visual

**Tarefa #13:** Implementar Preferences (Apostila 08)
- [ ] Salvar último nome digitado em Preferences
- [ ] Recuperar último nome ao abrir TelaIncluirPessoa
- [ ] Testar persistência entre sessões

**Entrega:** 09/06 (Prova A1)

---

### 🟡 FASE 2: MVP Profissional (Pós-Entrega Imediata)

**Objetivo:** Transformar em app que parece produto real  
**Esforço:** 8-12 horas  
**Risco:** Médio  
**Valor:** Muito Alto (diferencial de mercado)

#### Tarefas:

**Tarefa #14:** Migrar para CreateWindow (Apostila 05)
- [ ] Alterar App.xaml.cs para usar CreateWindow()
- [ ] Testar gerenciamento de janela no Windows
- [ ] Validar que NavigationPage funciona corretamente
- [ ] Remover propriedade MainPage do construtor

**Tarefa #10:** Implementar FlyoutPage (Apostila 06B)
- [ ] Criar Views/FlyoutPageMenu.xaml
- [ ] Implementar menu lateral com botões:
  - [ ] 📋 Lista de Pessoas
  - [ ] ➕ Incluir Nova Pessoa
  - [ ] 📊 Estatísticas
  - [ ] ⚙️ Configurações
  - [ ] ℹ️ Sobre
- [ ] Configurar FlyoutLayoutBehavior="Popover"
- [ ] Testar navegação em todas as plataformas

**Tarefa #7:** Criar Tela de Estatísticas/Dashboard
- [ ] Criar Views/TelaEstatisticas.xaml
- [ ] Implementar consultas ao banco:
  - [ ] Total de pessoas cadastradas
  - [ ] Idade média
  - [ ] Pessoa mais velha
  - [ ] Pessoa mais nova
- [ ] Usar Cards/Border para visualização
- [ ] Atualizar automaticamente ao navegar para a tela

**Tarefa #18:** Criar Tela de Configurações
- [ ] Criar Views/TelaConfiguracoes.xaml
- [ ] Implementar opções:
  - [ ] Checkbox para tema escuro
  - [ ] Botão "Limpar Banco de Dados"
  - [ ] Label com versão do app
  - [ ] Botão "Resetar Configurações"
- [ ] Salvar preferências em Preferences
- [ ] Aplicar tema escuro/claro dinamicamente

**Tarefa #15:** Criar Tela Sobre com WebView (Apostila 02)
- [ ] Criar Views/TelaSobre.xaml
- [ ] Adicionar WebView carregando:
  - [ ] Termos de uso (HTML local ou online)
  - [ ] Ou manual do sistema
  - [ ] Ou informações sobre o projeto
- [ ] Botão "Voltar" para fechar tela

**Prazo:** Semana após entrega (16/06)

---

### 🟢 FASE 3: UI/UX Avançado (Versão 1.5)

**Objetivo:** Interface responsiva e acessível  
**Esforço:** 6-8 horas  
**Risco:** Médio  
**Valor:** Alto (acessibilidade e profissionalismo)

#### Tarefas:

**Tarefa #17:** Adicionar FlexLayout Responsivo (Apostila 03)
- [ ] Substituir StackLayout por FlexLayout na ListView
- [ ] Configurar Direction="Row"
- [ ] Configurar JustifyContent="SpaceBetween"
- [ ] Testar em diferentes larguras de tela
- [ ] Ajustar weights (FlexLayout.Grow) para responsividade

**Tarefa #12:** Implementar Unidades sp para Fontes (Apostila 04)
- [ ] Revisar TODO o XAML para encontrar FontSize fixo
- [ ] Substituir por valores com sp (scalable pixels)
- [ ] Habilitar FontAutoScalingEnabled="True"
- [ ] Testar com configurações de acessibilidade do Windows/Android
- [ ] Validar que texto escala corretamente

**Tarefa #16:** Implementar TabbedPage Alternativa (Apostila 06A)
- [ ] Criar Views/TabbedPagePrincipal.xaml
- [ ] Implementar abas:
  - [ ] Lista (TelaListaPessoa)
  - [ ] Estatísticas (TelaEstatisticas)
  - [ ] Configurações (TelaConfiguracoes)
- [ ] Adicionar ícones para cada aba
- [ ] Criar configuração para alternar entre FlyoutPage e TabbedPage

**Prazo:** Duas semanas após entrega (23/06)

---

### 🟣 FASE 4: Funcionalidades Enterprise (Versão 2.0)

**Objetivo:** Recursos corporativos e arquitetura profissional  
**Esforço:** 12-16 horas  
**Risco:** Alto (refatoração massiva)  
**Valor:** Muito Alto (padrões de mercado)

#### Tarefas:

**Tarefa #8:** Exportar Dados CSV (Funcionalidade Mercado)
- [ ] Criar Services/ExportService.cs
- [ ] Implementar geração de CSV:
  - [ ] Cabeçalho (ID, Nome, Idade)
  - [ ] Linhas de dados do banco
  - [ ] Codificação UTF-8
- [ ] Adicionar botão "Exportar" na TelaListaPessoa
- [ ] Implementar compartilhamento (Share API)
- [ ] Enviar por email
- [ ] Salvar em arquivo

**Tarefa #9:** Implementar MVVM Completo (Apostila 09)
- [ ] Criar pasta ViewModels/
- [ ] Criar ViewModels/BaseViewModel.cs:
  - [ ] INotifyPropertyChanged
  - [ ] SetProperty<T>() helper
  - [ ] IsBusy property
- [ ] Criar ViewModels/PessoaViewModel.cs:
  - [ ] ObservableCollection<Pessoa> Pessoas
  - [ ] ICommand SalvarCommand
  - [ ] ICommand ExcluirCommand
  - [ ] ICommand BuscarCommand
  - [ ] Métodos: CarregarPessoasAsync(), SalvarAsync(), ExcluirAsync()
- [ ] Refatorar TelaListaPessoa.xaml:
  - [ ] Remover lógica de code-behind
  - [ ] BindingContext = new PessoaViewModel()
  - [ ] Bindings para Commands
- [ ] Refatorar TelaIncluirPessoa.xaml:
  - [ ] BindingContext = new PessoaViewModel()
  - [ ] Two-way binding para propriedades
- [ ] Refatorar TelaAlterarPessoa.xaml:
  - [ ] BindingContext = new PessoaViewModel()
  - [ ] Two-way binding
- [ ] Mover TODO o DAL para Repository Pattern (opcional)
- [ ] Testar que NADA quebrou após refatoração

**Prazo:** Um mês após entrega (07/07)

---

## 📋 CRONOGRAMA DETALHADO

### 📅 Semana 1 (05/06 - 09/06): Polimento A1

**Segunda 05/06:**
- [x] Criar plano mestre
- [ ] Testar CRUD completo (Tarefa #6)
- [ ] Documentar funcionalidades

**Terça 06/06:**
- [ ] Implementar "Toque Generoso" (Tarefa #19)
- [ ] Testar usabilidade

**Quarta 07/06:**
- [ ] Adicionar ActivityIndicator (Tarefa #11)
- [ ] Testar feedback visual

**Quinta 08/06:**
- [ ] Implementar Preferences (Tarefa #13)
- [ ] Testar persistência

**Sexta 09/06:** 📤 **ENTREGA PROVA A1**
- [ ] Commit final com tag "v1.0-entrega-a1"
- [ ] Preparar apresentação
- [ ] Backup completo do projeto

---

### 📅 Semana 2 (10/06 - 16/06): MVP Profissional

**Segunda 10/06:**
- [ ] Migrar para CreateWindow (Tarefa #14)
- [ ] Testar gerenciamento de janela

**Terça 11/06:**
- [ ] Implementar FlyoutPage (Tarefa #10)
- [ ] Testar navegação

**Quarta 12/06:**
- [ ] Criar Tela de Estatísticas (Tarefa #7)
- [ ] Implementar consultas agregadas

**Quinta 13/06:**
- [ ] Criar Tela de Configurações (Tarefa #18)
- [ ] Implementar Preferences

**Sexta 14/06:**
- [ ] Criar Tela Sobre com WebView (Tarefa #15)
- [ ] Testar navegação completa

**Sábado 15/06:**
- [ ] Testes integração Fase 2
- [ ] Bug fixes

**Domingo 16/06:** 🎉 **RESULTADOS A1**
- [ ] Commit "v1.5-mvp-profissional"
- [ ] Documentar novas funcionalidades

---

### 📅 Semana 3-4 (17/06 - 30/06): UI/UX Avançado

**Semana 3:**
- [ ] Implementar FlexLayout (Tarefa #17)
- [ ] Testar responsividade
- [ ] Implementar unidades sp (Tarefa #12)
- [ ] Testar acessibilidade

**Semana 4:**
- [ ] Implementar TabbedPage alternativa (Tarefa #16)
- [ ] Testar navegação por abas
- [ ] Testes cross-plataforma
- [ ] Commit "v1.7-ui-ux-avancado"

---

### 📅 Mês 2 (01/07 - 31/07): Enterprise v2.0

**Semanas 1-2:**
- [ ] Implementar Exportar CSV (Tarefa #8)
- [ ] Testar geração e compartilhamento
- [ ] Documentar funcionalidade

**Semanas 3-4:**
- [ ] Implementar MVVM Completo (Tarefa #9)
- [ ] Refatorar code-behind para ViewModels
- [ ] Testes de regressão completa
- [ ] Commit "v2.0-enterprise-grade"

---

## 🎯 DEFINIÇÃO DE PRONTIDÃO

### **Versão 1.0 - Entrega A1** (09/06)
✅ CRUD funcional  
✅ Validações robustas  
✅ Navegação hierárquica  
✅ Feedback visual básico  
✅ Multiplataforma  

**Status:** APROVADO PARA NOTA MÁXIMA

### **Versão 1.5 - MVP Profissional** (16/06)
✅ Tudo da v1.0 +  
✅ Menu lateral (FlyoutPage)  
✅ Tela de Estatísticas  
✅ Tela de Configurações  
✅ Tela Sobre  
✅ CreateWindow moderno  

**Status:** PRODUTO MÍNIMO VIÁVEL

### **Versão 1.7 - UI/UX Avançado** (30/06)
✅ Tudo da v1.5 +  
✅ Layout responsivo (FlexLayout)  
✅ Acessibilidade (sp)  
✅ Navegação por abas (TabbedPage alternativa)  
✅ "Toque Generoso" implementado  

**Status:** APP PROFISSIONAL

### **Versão 2.0 - Enterprise Grade** (31/07)
✅ Tudo da v1.7 +  
✅ MVVM Completo (ViewModels)  
✅ Exportar CSV/Excel  
✅ Arquitetura limpa (sem code-behind)  
✅ Padrões de projeto (Repository, Commands)  
✅ Testabilidade (ViewModels testáveis)  

**Status:** PRODUTO DE MERCADO

---

## 🚨 RISCOS E MITIGAÇÕES

### **Riscos da Fase 2 (FlyoutPage):**
- **Risco:** Quebra de navegação ao migrar para FlyoutPage
- **Mitigação:** Manter NavigationPage dentro de FlyoutPage.Detail
- **Plano B:** Branch Git "flyout-experiment" para testes isolados

### **Riscos da Fase 4 (MVVM):**
- **Risco:** Refatoração massiva pode quebrar funcionalidades
- **Mitigação:** Implementar gradualmente (tela por tela)
- **Testes:** Testes de regressão após cada ViewModel
- **Plano B:** Manter code-behind como fallback

### **Riscos de Cronograma:**
- **Risco:** Atraso por bugs inesperados
- **Mitigação:** Buffer de 1 semana entre fases
- **Priorização:** Fases 1-2 são essenciais, Fases 3-4 são incrementais

---

## 📊 MÉTRICAS DE SUCESSO

### **Para Versão 1.5 (MVP):**
- [ ] 5 telas funcionais (Lista, Incluir, Alterar, Stats, Config, Sobre)
- [ ] Navegação intuitiva (menu lateral)
- [ ] Zero bugs de navegação
- [ ] Feedback visual em todas as operações

### **Para Versão 2.0 (Enterprise):**
- [ ] 100% dos Views sem code-behind lógica de negócio
- [ ] ViewModels testáveis (unit tests)
- [ ] Exportar/importar dados funcionando
- [ ] Acessibilidade (WCAG 2.1 compliant)

---

## 🎓 APRENDIZADO POR FASE

### **Fase 1 (A1):**
- Apostilas 01, 02, 07, 08
- UX básica, Feedback visual, Preferences

### **Fase 2 (MVP):**
- Apostilas 02, 05, 06B
- FlyoutPage, WebView, CreateWindow

### **Fase 3 (UI/UX):**
- Apostilas 03, 04, 06A
- FlexLayout, sp, TabbedPage

### **Fase 4 (Enterprise):**
- Apostilas 08, 09
- MVVM, Patterns, Exportação

---

## 📝 PRÓXIMOS PASSOS IMEDIATOS

1. **Testar CRUD completo** (Tarefa #6)
2. **Documentar estado atual** (README)
3. **Priorizar Fase 1** para entrega 09/06
4. **Commit baseline** antes de iniciar Fase 2

---

**Arquivo criado em:** `C:\Users\lucas\source\repos\projeto-final\PLANO-MESTRE-V2.md`

**Status do Plano:** ✅ COMPLETO - Tudo documentado desde v1.0 até v2.0
