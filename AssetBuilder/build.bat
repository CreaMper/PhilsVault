@echo off
SET config=%1

if %config%==Debug (
COPY /y "AssetBuilder.exe" "..\..\..\PhilsLab\bin\Debug" 
) ELSE (
if %config%==Release /y COPY "bin\Release\AssetBuilder.exe" "..\PhilsLab\bin\Release"

)

