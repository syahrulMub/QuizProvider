@echo off

setlocal enabledelayedexpansion

start cmd.exe /k "cd QuizWeb && dotnet watch run"
start cmd.exe /k "cd WebClient && npm install && npm run dev"
