# appClassePessoaBD

**Projeto Final - PDM 2026**  
Cadastro de Pessoas com SQLite + .NET MAUI

## 📋 Sobre

Aplicativo CRUD completo para gerenciamento de pessoas:
- ✅ Create/Read/Update/Delete
- ✅ SQLite (Model/DAL pattern)
- ✅ ListView com SearchBar
- ✅ ToolbarItem + ContextActions
- ✅ 3 telas: Lista, Incluir, Alterar

## 🚀 Como Executar

### Windows (Recomendado)
1. Clone o repositório
2. Abra `appClassePessoaBD.sln` no Visual Studio 2022+
3. Pressione F5 (Debug) ou Ctrl+F5 (Release)

### Gerar Executável
```powershell
.\build-windows.ps1
```
Ver instruções completas em [BUILD.md](BUILD.md)

## 📁 Estrutura

```
├── Model/Pessoa.cs           # POCO com atributos SQLite
├── DAL/crudSQLite.cs       # CRUD async (Insert, Update, Delete, GetAll, Search)
├── Views/
│   ├── TelaListaPessoa.xaml       # ListView + SearchBar + ToolbarItem
│   ├── TelaIncluirPessoa.xaml    # Formulário CREATE
│   └── TelaAlterarPessoa.xaml     # Formulário UPDATE
└── Resources/                    # Imagens, ícones, splash
```

## 🎓 Curso

**Disciplina:** Programação Para Dispositivos Móveis 2026  
**Entrega:** 09/06 (Prova A1) - Resultados: 16/06

## 🔧 Tecnologias

- .NET MAUI 10.0
- SQLite (sqlite-net-pcl 1.9.172)
- C# 12 + async/await
- XAML + MVVM pattern

## 📱 Configuração

**Application ID:** `br.edu.udf.appclassepessoabd`  
**Platforms:** Windows 10 1809+ (net10.0-windows10.0.19041.0)

## 📄 Licença

Projeto acadêmico - UDF 2026
