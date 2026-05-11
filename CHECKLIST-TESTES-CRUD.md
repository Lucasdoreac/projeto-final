# 🧪 CHECKLIST DE TESTES - appClassePessoaBD v1.0

**Data:** 2026-05-11  
**Objetivo:** Testar 100% das funcionalidades CRUD antes da entrega A1  
**Status:** Em andamento...

---

## ✅ TESTE 1: CRIAÇÃO DE REGISTROS

**Objetivo:** Validar inserção de pessoas no banco de dados

**Cenários de Teste:**

### [ ] Teste 1.1: Criar Pessoa Válida
- [ ] Abrir aplicação
- [ ] Clicar em botão "Incluir" (ToolbarItem)
- [ ] Preencher Nome: "Lucas Silva"
- [ ] Preencher Idade: "25"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Pessoa LUCAS SILVA cadastrada com sucesso!"
- [ ] **Esperado:** Retorno automático para TelaListaPessoa
- [ ] **Esperado:** Pessoa aparece na lista

### [ ] Teste 1.2: Criar Pessoa com Nome Vazio
- [ ] Clicar em "Incluir"
- [ ] Deixar Nome vazio
- [ ] Preencher Idade: "30"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Validação: O campo Nome é obrigatório"
- [ ] **Esperado:** Foco no campo Nome
- [ ] **Resultado:** ❌ Não salvou

### [ ] Teste 1.3: Criar Pessoa com Nome Curto
- [ ] Nome: "Jo" (menos de 3 caracteres)
- [ ] Idade: "20"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Validação: O nome deve ter pelo menos 3 caracteres"
- [ ] **Resultado:** ❌ Não salvou

### [ ] Teste 1.4: Criar Pessoa com Idade Vazia
- [ ] Nome: "Maria Santos"
- [ ] Idade: vazio
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Validação: O campo Idade é obrigatório"
- [ ] **Esperado:** Foco no campo Idade
- [ ] **Resultado:** ❌ Não salvou

### [ ] Teste 1.5: Criar Pessoa com Idade Inválida (Negativa)
- [ ] Nome: "Pedro Oliveira"
- [ ] Idade: "-5"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Validação: A idade deve estar entre 0 e 150 anos"
- [ ] **Resultado:** ❌ Não salvou

### [ ] Teste 1.6: Criar Pessoa com Idade Inválida (Alta)
- [ ] Nome: "Ana Costa"
- [ ] Idade: "200"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Validação: A idade deve estar entre 0 e 150 anos"
- [ ] **Resultado:** ❌ Não salvou

### [ ] Teste 1.7: TextTransform em Maiúsculas
- [ ] Nome: "carlos eduardo" (minúsculas)
- [ ] Idade: "35"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Pessoa CARLOS EDUARDO cadastrada!" (em maiúsculas)
- [ ] **Esperado:** No banco: "CARLOS EDUARDO" (maiúsculas)

### [ ] Teste 1.8: ClearButtonVisibility
- [ ] Digitar texto no campo Nome
- [ ] **Esperado:** Aparecer "X" para limpar
- [ ] Clicar no "X"
- [ ] **Esperado:** Campo limpo

**Status Teste 1:** _____/8 testes passaram

---

## ✅ TESTE 2: LISTAGEM E CARREGAMENTO

**Objetivo:** Validar leitura e exibição de dados

### [ ] Teste 2.1: Carregamento Inicial
- [ ] Abrir aplicação
- [ ] **Esperado:** TelaListaPessoa abre
- [ ] **Esperado:** ListView com cabeçalhos (ID, Nome, Idade)
- [ ] **Esperado:** ToolbarItem "Incluir" visível
- [ ] **Esperado:** SearchBar "Qual a Pessoa?" visível

### [ ] Teste 2.2: OnAppearing Automático
- [ ] Navegar para TelaIncluir
- [ ] Voltar para TelaLista (Navigation.PopAsync)
- [ ] **Esperado:** Lista recarrega automaticamente
- [ ] **Esperado:** Todas as pessoas aparecem

### [ ] Teste 2.3: Dados na ListView
- [ ] Verificar se 5 pessoas criadas aparecem
- [ ] **Esperado:** Colunas alinhadas (Grid 3 colunas)
- [ ] **Esperado:** Texto centralizado
- [ ] **Esperado:** Fonte em negrito

**Status Teste 2:** _____/3 testes passaram

---

## ✅ TESTE 3: BUSCA E FILTRO

**Objetivo:** Validar SearchBar com SQL LIKE

### [ ] Teste 3.1: Busca por Nome Completo
- [ ] Digitar "Lucas" na SearchBar
- [ ] **Esperado:** ListView filtra mostrando só "LUCAS SILVA"
- [ ] **Esperado:** Outros registros somem

### [ ] Teste 3.2: Busca Parcial
- [ ] Digitar "Silva" na SearchBar
- [ ] **Esperado:** ListView mostra todos com "Silva" no nome

### [ ] Teste 3.3: Busca Case Insensitive
- [ ] Digitar "lucas" (minúsculo)
- [ ] **Esperado:** Encontra "LUCAS SILVA" (maiúsculas)

### [ ] Teste 3.4: Busca Vazia
- [ ] Limpar SearchBar
- [ ] **Esperado:** ListView mostra todos os registros novamente

### [ ] Teste 3.5: Busca Inexistente
- [ ] Digitar "Zebra" na SearchBar
- [ ] **Esperado:** ListView vazia
- [ ] **Esperado:** Nenhum registro aparece

**Status Teste 3:** _____/5 testes passaram

---

## ✅ TESTE 4: ALTERAÇÃO DE REGISTROS

**Objetivo:** Validar UPDATE com BindingContext

### [ ] Teste 4.1: Abrir Tela de Alteração
- [ ] Clicar em uma pessoa na ListView
- [ ] **Esperado:** Abre TelaAlterarPessoa
- [ ] **Esperado:** Campos preenchidos com dados atuais
- [ ] **Esperado:** BindingContext funcionando

### [ ] Teste 4.2: Alterar Nome
- [ ] Modificar nome de "LUCAS SILVA" para "LUCAS SILVA JR"
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** DisplayAlert "Pessoa LUCAS SILVA JR alterada com sucesso!"
- [ ] **Esperado:** Retorno para TelaListaPessoa
- [ ] **Esperado:** Nome atualizado na lista

### [ ] Teste 4.3: Alterar Idade
- [ ] Selecionar pessoa
- [ ] Modificar idade de 25 para 26
- [ ] Clicar em "Salvar"
- [ ] **Esperado:** Idade atualizada

### [ ] Teste 4.4: Validações na Alteração
- [ ] Tentar deixar nome vazio
- [ ] **Esperado:** Mesma validação da inclusão
- [ ] **Esperado:** Campo obrigatório funcionando

**Status Teste 4:** _____/4 testes passaram

---

## ✅ TESTE 5: EXCLUSÃO COM CONFIRMAÇÃO

**Objetivo:** Validar DELETE com alerta de confirmação

### [ ] Teste 5.1: ContextActions Aparece
- [ ] Clicar e segurar em uma pessoa da ListView
- [ ] **Esperado:** Menu "Excluir Pessoa" aparece
- [ ] **Esperado:** Ícone de exclusão visível

### [ ] Teste 5.2: Confirmação de Exclusão
- [ ] Clicar em "Excluir Pessoa"
- [ ] **Esperado:** DisplayAlert "Tem Certeza que quer excluir a Pessoa?"
- [ ] **Esperado:** Mostra nome da pessoa
- [ ] **Esperado:** Botões "Sim" e "Não"

### [ ] Teste 5.3: Confirmar Exclusão (Sim)
- [ ] Clicar em "Sim"
- [ ] **Esperado:** Pessoa desaparece da ListView
- [ ] **Esperado:** Banco atualizado

### [ ] Teste 5.4: Cancelar Exclusão (Não)
- [ ] Clicar em outra pessoa
- [ ] Clicar em "Excluir Pessoa"
- [ ] Clicar em "Não"
- [ ] **Esperado:** Pessoa permanece na lista
- [ ] **Esperado:** Nada foi deletado

**Status Teste 5:** _____/4 testes passaram

---

## ✅ TESTE 6: NAVEGAÇÃO ENTRE TELAS

**Objetivo:** Validar NavigationPage e PushAsync/PopAsync

### [ ] Teste 6.1: Navegação para Incluir
- [ ] TelaLista → Clicar "Incluir"
- [ ] **Esperado:** TelaIncluirPessoa abre
- [ ] **Esperado:** Barra de volta (←) aparece

### [ ] Teste 6.2: Retorno com PopAsync
- [ ] Em TelaIncluir → Salvar pessoa
- [ ] **Esperado:** Volta automaticamente para TelaLista
- [ ] **Esperado:** NÃO cria nova instância

### [ ] Teste 6.3: Navegação para Alterar
- [ ] Clicar em pessoa na lista
- [ ] **Esperado:** TelaAlterarPessoa abre
- [ ] **Esperado:** Dados carregados corretamente

### [ ] Teste 6.4: Barra de Títulos
- [ ] Verificar título em TelaLista: "Lista de Pessoas"
- [ ] Verificar título em TelaIncluir: "Incluir Pessoa"
- [ ] Verificar título em TelaAlterar: "Alterar Pessoa"

**Status Teste 6:** _____/4 testes passaram

---

## ✅ TESTE 7: PULL TO REFRESH

**Objetivo:** Validar IsPullToRefreshEnabled

### [ ] Teste 7.1: Refresh Funciona
- [ ] Clicar e segurar na ListView
- [ ] Arrastar para baixo
- [ ] **Esperado:** Indicador de carregamento aparece
- [ ] **Esperado:** Soltar: recarrega lista

**Status Teste 7:** _____/1 teste passou

---

## 📊 RESULTADOS FINAIS

**Total de Testes:** 30  
**Testes Passaram:** _____/30  
**Testes Falharam:** _____/30  
**Bugs Encontrados:**

### Bugs Críticos (Bloqueadores para Entrega):
- [ ] Listar bugs aqui...

### Bugs Moderados (Não bloqueiam):
- [ ] Listar bugs aqui...

### Bugs Leves (Melhorias futuras):
- [ ] Listar bugs aqui...

---

## ✅ CONCLUSÃO

**Status do Projeto:** [ ] APROVADO / [ ] REPROVADO  
**Pode Ser Entregue:** [ ] SIM / [ ] NÃO  
**Nota Esperada:** _____/10  

**Observações Finais:**
- 
- 

---

**Teste executado por:** Claude (Agente Autônomo)  
**Data:** 2026-05-11  
**Hora de Início:** Em andamento...
