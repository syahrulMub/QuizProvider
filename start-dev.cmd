@echo off

setlocal enabledelayedexpansion

REM Cek apakah folder 'node_modules' ada di dalam 'QuizWeb.Client'
if exist "QuizWeb.Client\node_modules\" (
    echo "node_modules" folder exists in QuizWebClient.
    start cmd.exe /k "cd QuizWeb.Client && npm run dev"
) else (
    echo "node_modules" folder does not exist in QuizWebClient.
    echo Running 'npm install' to install dependencies...
    start cmd.exe /k "cd QuizWeb.Client && npm install && npm run dev"
)

start cmd.exe /k "cd QuizWeb && dotnet watch run"
