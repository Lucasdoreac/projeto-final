# 🚀 Build - appClassePessoaBD

## Windows (Recomendado)

### Pré-requisitos
- Windows 10 1809+ (build 17763)
- [.NET 10.0 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)
- Ou Visual Studio 2022 17.8+ com workload .NET MAUI

### Método 1 - PowerShell Script (Automático)
```powershell
.\build-windows.ps1
```

### Método 2 - Manual (Command Line)
```powershell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

### Saída
- **Local:** `./publish/appClassePessoaBD.exe`
- **Tamanho:** ~80-120 MB (self-contained)
- **Runtime:** .NET 10.0 embutido (não precisa instalar .NET)

### Distribuição
1. Copiar pasta `publish/` completa
2. Executar `appClassePessoaBD.exe` em qualquer Windows 10+

## Linux / macOS

**⚠️ AVISO:** Este projeto está configurado apenas para Windows.

Para desenvolvimento cross-platform, edite `appClassePessoaBD.csproj`:
```xml
<!-- Descomente para cross-platform -->
<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">net10.0-windows10.0.19041.0</TargetFrameworks>
<TargetFrameworks Condition="!$([MSBuild]::IsOSPlatform('windows'))">net10.0-android;net10.0-ios;net10.0-maccatalyst</TargetFrameworks>
```

## Troubleshooting

### Erro "EnableWindowsTargeting"
No macOS/Linux, use:
```bash
dotnet build -p:EnableWindowsTargeting=true
```

### Erro "Android SDK not found"
Ignore - projeto configurado para Windows-only.

### Erro "Xcode version mismatch"
Ignore - projeto configurado para Windows-only.
