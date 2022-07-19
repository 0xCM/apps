 InstallBase:$InstallBase
echo ExePath:$ExePath
echo Argist:$ArgList
Start-Process -WorkingDirectory $InstallBase -UseNewEnvironment -FilePath $ExePath -ArgumentList $ArgList