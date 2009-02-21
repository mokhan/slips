@echo off

cls
tools\nant\bin\NAnt.exe -buildfile:project.build -nologo -logfile:build.txt %*
echo %time%