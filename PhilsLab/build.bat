echo off
set config=%1

if %config%==Debug echo "debug"

if %config%==Release echo "release"