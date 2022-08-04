$Dir="$env:DevRoot/dev/z0/libs/tools.shell"
$Target="$Dir/tools.shell.code-workspace"
Start-Process -UseNewEnvironment -FilePath $env:vscode -ArgumentList $Target -WorkingDirectory $Dir