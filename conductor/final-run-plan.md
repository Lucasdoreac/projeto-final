# Plano de Execução e Validação Final

Este plano descreve os passos para compilar e executar o aplicativo MAUI, garantindo que as correções de contraste e legibilidade sejam validadas no ambiente Windows.

## Objetivo
Validar as melhorias de UI (fundos translúcidos e AppThemeBinding) e garantir que o aplicativo inicie sem erros de recursos.

## Contexto
O projeto enfrentou problemas de:
1. Conflito entre SDKs (Scoop vs Oficial).
2. Travamento de processo (PID 880).
3. Erro de recurso XAML ausente (App.xaml).

## Passos de Implementação
1. **Limpeza de Ambiente:**
   - Encerrar qualquer processo `appClassePessoaBD` ativo para evitar erros de escrita no executável.
2. **Configuração de SDK:**
   - Definir explicitamente `DOTNET_MSBUILD_SDK_RESOLVER_CLI_DIR` e `MSBuildSDKsPath` para o .NET 8 oficial.
3. **Build e Run:**
   - Executar `dotnet build` e `dotnet run` para o framework `net8.0-windows10.0.19041.0`.

## Verificação
- O aplicativo deve abrir uma janela Windows.
- Ao navegar para "Configurações" e "Sobre", o texto deve estar legível sobre a imagem de fundo, com uma caixa translúcida de fundo.
- O tema (Claro/Escuro) deve ser respeitado pelos containers.
