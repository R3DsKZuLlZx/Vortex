@echo off
pushd ConsoleApp
dotnet tool restore
dotnet ef database update -c VortexDbContext
popd
pause
