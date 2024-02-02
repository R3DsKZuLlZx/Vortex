@echo off
pushd ConsoleApp
dotnet tool restore
set /p name="Migration Name: "
dotnet ef migrations add %name%  -p ../VortexDb -o Migrations -c VortexDbContext
popd
pause
