param(
    # Compile
    [Parameter()]
    [switch]
    $Compile,

    # Import
    [Parameter()]
    [switch]
    $Import
)

if($Compile) {

    Write-debug $PSScriptRoot

    $arguments = @{
        Filepath = "dotnet.exe";
        ArgumentList = "build {0} -o {0}\output" -f $PSScriptRoot
    }

    $result = Start-Process @arguments -Wait -PassThru

    Write-host "[Compile] exit code : $($result.ExitCode)"
}

if($Import) {
    Import-Module -Force -Debug -Verbose $PSScriptRoot\output\*.dll
}
