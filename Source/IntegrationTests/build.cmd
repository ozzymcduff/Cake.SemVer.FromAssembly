@echo off
:: Execute the PS1 file with the same name as this batch file.
set filename=%~d0%~p0%~n0.ps1

if exist "%filename%" (
  PowerShell.exe -NoProfile -NonInteractive -File "%filename%" %*
 
  :: Collect the exit code from the PowerShell script.
  set err=%errorlevel%
) else (
  echo File not found.
  echo %filename%
 
  :: Set our exit code.
  set err=1
)

:: Exit and pass along our exit code.
exit /B %err%