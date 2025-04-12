param(
    [Parameter(Mandatory = $true)]
    [string]$Service
)

Write-Host "Building Docker service: $Service..."

docker compose build $Service

if ($LASTEXITCODE -eq 0) {
    Write-Host "Build succeeded for $Service" -ForegroundColor Green
} else {
    Write-Host "Build failed for $Service" -ForegroundColor Red
    exit $LASTEXITCODE
}