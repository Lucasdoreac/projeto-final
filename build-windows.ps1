# Build Script - Windows Executable
# Execute no Windows (PowerShell)

Write-Host "🔨 Building appClassePessoaBD for Windows..." -ForegroundColor Cyan

# Clean previous builds
Write-Host "🧹 Cleaning..." -ForegroundColor Yellow
dotnet clean

# Restore dependencies
Write-Host "📦 Restoring packages..." -ForegroundColor Yellow
dotnet restore

# Publish self-contained executable
Write-Host "🚀 Publishing Windows executable..." -ForegroundColor Yellow
dotnet publish -c Release `
    -r win-x64 `
    --self-contained true `
    -p:PublishSingleFile=true `
    -p:PublishReadyToRun=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -o ./publish

Write-Host "✅ Build completo!" -ForegroundColor Green
Write-Host "📁 Executável: ./publish/appClassePessoaBD.exe" -ForegroundColor Green
Write-Host "" -ForegroundColor White
Write-Host "Para distribuir:" -ForegroundColor Cyan
Write-Host "1. Copiar toda a pasta 'publish/'" -ForegroundColor White
Write-Host "2. Executar appClassePessoaBD.exe no Windows 10+ (1809+)" -ForegroundColor White
