# 🔍 LOGGING PARA DEBUG - MVVM Implementation

**Data:** 2026-05-11  
**Status:** Logging configurado para investigar erro de inicialização

---

## 📋 LOGGING ADICIONADO

### Arquivos com Logging:
1. **MauiProgram.cs** - Logging do DI Container e inicialização
2. **App.xaml.cs** - Logging do construtor do App
3. **BaseViewModel.cs** - Logging base para todos ViewModels
4. **ListaPessoasViewModel.cs** - Logging da tela principal

### Níveis de Log:
- **LogInformation** - Eventos importantes de inicialização
- **LogWarning** - Situações anormais não-críticas
- **LogError** - Exceções e erros
- **LogDebug** - Mudanças de propriedade

---

## 🚀 COMO EXECUTAR COM LOGGING

### Opção 1: Via PowerShell (Captura completa)
```powershell
cd "C:\Users\lucas\source\repos\projeto-final"
dotnet run --framework net8.0-windows10.0.19041.0 --configuration Debug > app_debug.log 2>&1
```

### Opção 2: Via Bash (Background)
```bash
cd "C:/Users/lucas/source/repos/projeto-final"
dotnet run --framework net8.0-windows10.0.19041.0 --configuration Debug 2>&1 | tee app_debug.log
```

### Opção 3: Direto do exe (Se build falhar)
```bash
cd "C:/Users/lucas/source/repos/projeto-final"
"bin/Debug/net8.0-windows10.0.19041.0/win10-x64/appClassePessoaBD.exe" > app_debug.log 2>&1
```

---

## 📖 COMO LER OS LOGS

### Ver log completo:
```bash
cat "C:/Users/lucas/source/repos/projeto-final/app_debug.log"
```

### Filtrar por erros:
```bash
grep -i "error\|exception\|erro" app_debug.log
```

### Filtrar por信息的:
```bash
grep -i "ViewModel criado\.*INICIADO\|COMPLETADO" app_debug.log
```

### Ver últimas 50 linhas:
```bash
tail -50 "C:/Users/lucas/source/repos/projeto-final/app_debug.log"
```

---

## 🎯 O QUE PROCURAR NOS LOGS

### 1. Inicialização bem-sucedida:
```
========== CreateMauiApp INICIADO ==========
...
ServiceProvider criado: NÃO NULL
MauiApp criado: NÃO NULL
App.Services configurado
========== CreateMauiApp COMPLETADO ==========
```

### 2. Inicialização do App:
```
========== APP CONSTRUTOR INICIADO ==========
ServiceProvider: NÃO NULL
InitializeComponent completado
Services atribuído
ListaPessoasViewModel criado: NÃO NULL
TelaListaPessoa criada: NÃO NULL
NavigationPage criada e definida como MainPage
========== APP CONSTRUTOR COMPLETADO ==========
```

### 3. ViewModel criado:
```
BaseViewModel criado: ListaPessoasViewModel
ListaPessoasViewModel construtor INICIADO
ListaPessoasViewModel construtor COMPLETADO
```

### 4. Erros possíveis:
```
ERRO NO CONSTRUTOR DO APP
System.Exception: ...
```

---

## 🔍 POSSÍVEIS PROBLEMAS

### Problema 1: ServiceProvider NULL
**Sintoma:** App.Services = NULL  
**Causa:** DI Container não configurado  
**Log:** "ServiceProvider: NULL"

### Problema 2: ViewModel NULL
**Sintoma:** ViewModel não cria  
**Causa:** Service não registrado no DI  
**Log:** "ViewModel criado: NULL"

### Problema 3: Exceção no construtor
**Sintoma:** App crasha  
**Causa:** Exceção durante criação de objetos  
**Log:** "ERRO NO CONSTRUTOR DO APP"

---

## 🛠️ PRÓXIMOS PASSOS

1. **Executar app com logging**
2. **Capturar log completo**
3. **Identificar onde falha**
4. **Corrigir problema**
5. **Repetir até funcionar**

---

## 📝 ARQUIVOS CRIADOS

- `App.xaml.cs` - Logging do construtor
- `MauiProgram.cs` - Logging do DI
- `BaseViewModel.cs` - Logging base
- `ListaPessoasViewModel.cs` - Logging da tela principal

**Tudo está pronto para debug!**
