pipeline {
  agent any
  triggers {
    pollSCM("@daily")
  }
  stages
  {
    stage("STARTUP")
    {
      steps
      {
        dir("Tests")
        {
          sh "rm -rf TestResults"
          echo "STARTUP STAGE HAS BEEN COMPLETED"
        }
      }
    }
    stage("BUILD")
    {
      steps
      {
        sh "dotnet restore"
        sh "dotnet build CineMoviesWeb/CineMoviesWeb.csproj"
        echo "BUILD STAGE HAS BEEN COMPLETED"
      }
    }
    stage("TEST")
    {
      steps
      {
        dir("Tests")
        { 
          echo "TEST PROJECT SHOULD BE RAN HERE"
          echo "TEST STAGE HAS BEEN COMPLETED"
        }
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
