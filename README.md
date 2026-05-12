# appClassePessoaBD

**Projeto Final - PDM 2026 (UDF)**  
Sistema de Cadastro de Pessoas desenvolvido com .NET MAUI e SQLite.

## 📋 Sobre o Projeto

Este aplicativo é um CRUD completo para gerenciamento de registros de pessoas, utilizando o padrão MVVM e persistência local com SQLite. Foi refatorado para utilizar `NavigationPage` com uma interface moderna e intuitiva.

### Principais Funcionalidades:
- **Gerenciamento Completo (CRUD):** Inclusão, listagem, alteração e exclusão de pessoas.
- **Interface Otimizada:** Toolbar com itens primários (Incluir/Exportar) e menu secundário (Estatísticas/Configurações/Sobre).
- **Busca em Tempo Real:** Filtragem de nomes diretamente na lista.
- **Estatísticas:** Visualização de métricas dos dados cadastrados.
- **Exportação:** Suporte a exportação de dados (CSV).
- **Documentação Integrada:** Tela "Sobre" com acesso direto ao repositório via WebView.

## 🚀 Como Executar

### Pré-requisitos
- Visual Studio 2022 (v17.12+) com a carga de trabalho ".NET Multi-platform App UI development".
- .NET 10.0 SDK.

### Instalação
1. Clone o repositório:
   ```bash
   git clone https://github.com/Lucasdoreac/projeto-final.git
   ```
2. Abra a solução `appClassePessoaBD.sln` no Visual Studio.
3. Restaure os pacotes NuGet.
4. Selecione o target `Windows Machine` e pressione `F5`.

### Build via Script (Windows)
```powershell
.\build-windows.ps1
```

## 📁 Estrutura do Repositório

```text
├── DAL/                # Camada de Acesso a Dados (SQLite CRUD)
├── Model/              # Modelos de dados (Pessoa)
├── ViewModels/         # Lógica de interface (MVVM)
├── Views/              # Definições de telas (XAML)
├── Services/           # Serviços e lógica de negócio
├── Helpers/            # Utilitários e Logger
├── Resources/          # Ícones, Imagens, Fontes e Estilos
├── appClassePessoaBD.csproj  # Configurações do projeto
└── global.json         # Configuração do SDK .NET
```

## 🔧 Tecnologias Utilizadas

- **Framework:** .NET MAUI 10.0
- **Linguagem:** C# 12
- **Banco de Dados:** SQLite (via `sqlite-net-pcl`)
- **Arquitetura:** MVVM (Model-View-ViewModel)

## 🎓 Informações Acadêmicas

- **Instituição:** UDF Centro Universitário
- **Disciplina:** Programação Para Dispositivos Móveis 2026
- **Resultados:** 16/06

## 📄 Licença

Este projeto é de caráter acadêmico.
