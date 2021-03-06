function dotnet-test{
  Get-ChildItem -Path "test\**\*.Tests.csproj" | ForEach-Object {
    dotnet test $_ -c Release --no-build
    if ($LastExitCode -ne 0) { Exit $LastExitCode }
  }
}

@( "dotnet-test" ) | ForEach-Object {
  echo ""
  echo "***** $_ *****"
  echo ""

  # Invoke function and exit on error
  &$_ 
  if ($LastExitCode -ne 0) { Exit $LastExitCode }
}
