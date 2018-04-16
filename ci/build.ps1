# Set the target folder where all artifacts will be stored
$ArtifactsPath = "$(pwd)" + "\artifacts"

function release-build {
      dotnet clean -c Release
      dotnet build -c Release
  }

@( "release-build" ) | ForEach-Object {
    echo ""
    echo "***** $_ *****"
    echo ""
  
    # Invoke function and exit on error
    &$_ 
    if ($LastExitCode -ne 0) { Exit $LastExitCode }
  }
  