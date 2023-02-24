pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  stages
  {
    stage("BUILD")
    {
      steps
      {
        sh "dotnet restore"
        sh "dotnet build CineMoviesWeb.csproj"
        echo "BUILD STAGE HAS BEEN COMPLETED"
      }
    }
    stage("TEST")
    {
      steps
      {
        Echo "Test started."
      }
    }
    stage("DEPLOY")
    {
      steps
      {
        echo "Deployment started."
      }
    }
  }
}
