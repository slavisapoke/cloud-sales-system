param (
    [switch]$build
)

$command = "docker-compose up -d"

if ($build) {
    $command += " --build"
}


Write-Host "Starting Cloud Sales System..."
Invoke-Expression $command