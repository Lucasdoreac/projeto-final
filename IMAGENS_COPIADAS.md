# 🖼️ IMAGENS DO PROFESSOR - COPIADAS PARA PROJETO FINAL

**Data:** 2026-04-28  
**Origem:** `/Users/lucascardoso/projects/dotnet-maui/appsdoprofessor/`  
**Destino:** `/Users/lucascardoso/projects/dotnet-maui/projeto_final/Resources/`

---

## 📋 IMAGENS COPIADAS

### 📁 Resources/Images/ (5 imagens)

#### 1. **fundo.png** (574.1K)
- **Finalidade:** BackgroundImageSource de telas
- **Uso:** `<ContentPage BackgroundImageSource="fundo.png">`
- **Descrição:** Imagem de fundo para as telas do app

#### 2. **iconexcluirpessoa.png** (1.2K)
- **Finalidade:** Ícone do botão Excluir (ContextActions)
- **Uso:** `<MenuItem IconImageSource="iconexcluirpessoa.png">`
- **Descrição:** Ícone para menu swipe (excluir registro)

#### 3. **iconincluirpessoa.png** (462B)
- **Finalidade:** Ícone do botão Incluir (ToolbarItem)
- **Uso:** `<ToolbarItem IconImageSource="iconincluirpessoa.png">`
- **Descrição:** Ícone para botão superior (novo registro)

#### 4. **salvarpessoa.png** (5.1K)
- **Finalidade:** Ícone de botão Salvar
- **Uso:** Button com ImageSource ou ToolbarItem
- **Descrição:** Ícone para ação de salvar/confirmar

#### 5. **splash.png** (1.4M) ⚠️ DUPLICADO
- **Finalidade:** Splash Screen do app (tela de carregamento)
- **Uso:** `<MauiSplashScreen Include="Resources\Splash\splash.png">`
- **Descrição:** Imagem mostrada durante carregamento do app
- **Nota:** Também copiado para Resources/Splash/

---

### 📁 Resources/AppIcon/ (1 ícone)

#### 1. **iconpessoa.svg** (5.7K)
- **Finalidade:** Ícone principal do aplicativo
- **Uso:** `<MauiIcon ForegroundFile="Resources\AppIcon\iconpessoa.svg">`
- **Descrição:** Ícone que representa pessoa/usuario
- **Formato:** SVG (vetorial) para escalabilidade

---

### 📁 Resources/Splash/ (1 imagem)

#### 1. **splash.png** (1.4M)
- **Finalidade:** Splash Screen (tela de carregamento)
- **Uso:** `<MauiSplashScreen Include="Resources\Splash\splash.png">`
- **Descrição:** Imagem de fundo da tela de carregamento
- **Configuração típica:** BaseSize="800,600"

---

## 🎯 USO DAS IMAGENS NO PROJETO

### Exemplo de uso em XAML:

#### 1. **Background (fundo.png):**
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             BackgroundImageSource="fundo.png"
             Title="Minha Tela">
    <!-- Conteúdo da página -->
</ContentPage>
```

#### 2. **ToolbarItem (iconincluirpessoa.png):**
```xml
<ContentPage.ToolbarItems>
    <ToolbarItem Text="Incluir" 
                IconImageSource="iconincluirpessoa.png" 
                Clicked="OnIncluirClicked" />
</ContentPage.ToolbarItems>
```

#### 3. **MenuItem (iconexcluirpessoa.png):**
```xml
<ViewCell.ContextActions>
    <MenuItem Text="Excluir" 
             IconImageSource="iconexcluirpessoa.png" 
             Clicked="OnExcluirClicked" />
</ViewCell.ContextActions>
```

#### 4. **Splash Screen (splash.png):**
```xml
<MauiSplashScreen Include="Resources\Splash\splash.png" 
                     Color="#FFFFFF" 
                     BaseSize="800,600" />
```

#### 5. **App Icon (iconpessoa.svg):**
```xml
<MauiIcon Include="Resources\AppIcon\appicon.svg" 
           ForegroundFile="Resources\AppIcon\iconpessoa.svg" 
           ForegroundScale="0.5" 
           TintColor="#FFFFFF" />
```

---

## 📊 ESTRUTURA FINAL DE RECURSOS

```
projeto_final/Resources/
├── AppIcon/
│   ├── appicon.svg (padrão MAUI)
│   └── iconpessoa.svg (ícone personalizado)
├── Images/
│   ├── fundo.png (background)
│   ├── iconexcluirpessoa.png (excluir)
│   ├── iconincluirpessoa.png (incluir)
│   ├── salvarpessoa.png (salvar)
│   └── splash.png (splash screen)
├── Splash/
│   └── splash.png (splash screen)
└── Fonts/
    └── (fontes do projeto)
```

---

## 🎨 ESPECIFICAÇÕES DAS IMAGENS

### Por tipo de uso:

#### **Ícones de Ação:**
- `iconincluirpessoa.png` - Adicionar novo registro
- `iconexcluirpessoa.png` - Remover registro
- `salvarpessoa.png` - Confirmar/Salvar alterações

#### **Ícones de Identidade:**
- `iconpessoa.svg` - Ícone principal do app
- `fundo.png` - Background visual

#### **Splash Screen:**
- `splash.png` - Tela de carregamento (1.4MB)

---

## ⚠️ OBSERVAÇÕES IMPORTANTES

### 1. Formato e Nomenclatura:
- ✅ **PNG** para fotos e ícones de ação
- ✅ **SVG** para ícones vetoriais (app icon)
- ✅ **Minúsculas** (regra MAUI obrigatória)
- ✅ **Sem acentos** (compatibilidade Android)

### 2. Tamanhos:
- **Menor:** `iconincluirpessoa.png` (462B)
- **Médio:** `iconexcluirpessoa.png` (1.2K), `iconpessoa.svg` (5.7K)
- **Maior:** `splash.png` (1.4MB)

### 3. Uso correto:
- **SVG referenciado como .png** no XAML (regra MAUI)
- **Splash PNG** em Resources/Splash/ (não na raiz)
- **Ícones de ação** em Resources/Images/

---

## 🔧 COMO USAR NO PROJETO

### Passo 1: Configurar .csproj
```xml
<ItemGroup>
  <!-- App Icon -->
  <MauiIcon Include="Resources\AppIcon\appicon.svg" 
             ForegroundFile="Resources\AppIcon\iconpessoa.svg" 
             ForegroundScale="0.5" />
  
  <!-- Splash Screen -->
  <MauiSplashScreen Include="Resources\Splash\splash.png" 
                       Color="#FFFFFF" 
                       BaseSize="800,600" />
  
  <!-- Images -->
  <MauiImage Include="Resources\Images\*" />
</ItemGroup>
```

### Passo 2: Usar no XAML
```xml
<!-- Tela com background -->
<ContentPage BackgroundImageSource="fundo.png">

<!-- Botão incluir -->
<ToolbarItem IconImageSource="iconincluirpessoa.png" />

<!-- Menu excluir -->
<MenuItem IconImageSource="iconexcluirpessoa.png" />
```

---

## 📋 CHECKLIST DE IMAGENS

### ✅ Copiadas e prontas para uso:
- [x] fundo.png - Background de telas
- [x] iconexcluirpessoa.png - Menu swipe Excluir
- [x] iconincluirpessoa.png - ToolbarItem Incluir
- [x] salvarpessoa.png - Botão Salvar
- [x] splash.png - Splash Screen (2 cópias)
- [x] iconpessoa.svg - Ícone do app

### ⏳ Ainda não implementadas:
- [ ] Referência em XAML das telas
- [ ] Configuração no .csproj
- [ ] Teste em emulador/dispositivo

---

## 💡 DICAS FINAIS

### Para o projeto final:
1. **USAR** estas imagens como referência visual
2. **PERSONALIZAR** com suas próprias imagens se quiser
3. **MANTER** nomenclatura em minúsculas
4. **TESTAR** splash.png (1.4MB pode ser muito grande)

### Para criar suas próprias imagens:
1. **Formato:** PNG para fotos, SVG para ícones
2. **Tamanho:** Ícones pequenos (<50KB ideal)
3. **Splash:** <500KB recomendado (1.4MB está grande)
4. **Nome:** minúsculas, sem acentos

---

## 🎯 PRÓXIMOS PASSOS

1. ✅ **Copiar** estrutura para seu projeto
2. ⏳ **Configurar** .csproj com MauiIcon/MauiSplashScreen
3. ⏳ **Implementar** XAML das telas com as imagens
4. ⏳ **Testar** em emulador como aparecem

---

**Data cópia:** 2026-04-28  
**Total imagens:** 7 arquivos (6 únicas + 1 duplicada)  
**Tamanho total:** ~3MB  
**Status:** ✅ IMAGENS COPADAS E PRONTAS PARA USO
