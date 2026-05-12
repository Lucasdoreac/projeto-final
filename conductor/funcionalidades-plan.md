# Plano de Execução: Implementação de Funcionalidades e Menu (Apostilas 02, 06B, 07)

## Objetivo
Implementar o submenu (FlyoutPage), modo de tema e persistência de configurações para demonstrar capacidades profissionais.

## Passos
1. **Menu (Flyout):** Criar `Views/MainFlyoutPage.xaml` para gerenciar a navegação.
2. **Persistência:** Atualizar `ViewModels/ConfiguracoesViewModel.cs` para salvar `ativar_sons` e `tema_escolhido`.
3. **Temas:** Adicionar botões em `Views/TelaConfiguracoes.xaml` para alternar entre `AppTheme.Light` e `AppTheme.Dark`.
4. **Aplicação:** Ajustar `App.xaml.cs` para ler `Preferences` no carregamento e aplicar tema salvo.

## Validação
- O submenu deve aparecer ao deslizar da esquerda ou via ícone de menu.
- Ao mudar o tema em Configurações, o app deve trocar as cores imediatamente.
- Ao reiniciar o app, as configurações devem estar salvas.
