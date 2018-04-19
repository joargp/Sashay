$VersionSuffix = "preview"
# Set the target folder where all artifacts will be stored
$ArtifactsPath = "$(pwd)" + "\artifacts"



function release-build {
      dotnet clean -c Release
      dotnet build -c Release --version-suffix $VersionSuffix
  }

  function release-pack{
    Get-ChildItem -Path src/** | ForEach-Object {
      dotnet pack $_ -c Release --no-build -o $ArtifactsPath --version-suffix $VersionSuffix
    }
  }

@( "release-build", "release-pack" ) | ForEach-Object {
    echo ""
    echo "***** $_ *****"
    echo ""
  
    # Invoke function and exit on error
    &$_ 
    if ($LastExitCode -ne 0) { Exit $LastExitCode }
  }
  