@echo off
setlocal

:: Clear temporary files from the user's profile
del /q /s "%temp%\*.*"
del /q /s "%userprofile%\AppData\Local\Temp\*.*"

echo Temporary files deleted successfully.

