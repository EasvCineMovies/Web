pipeline {
  agent any
  triggers {
    pollSCM('H/5 * * * *')
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
        sh 'docker-compose build'
        echo "BUILD STAGE HAS BEEN COMPLETED"
      }
    }
    stage("TEST")
    {
      steps
      {
        dir("Tests")
        { 
          sh "dotnet add package coverlet.collector"
          sh "dotnet test --collect:'XPlat Code Coverage'"
          sh "dotnet restore"
          sh "dotnet test Tests.csproj"
          sh 'docker-compose run --rm app Tests'
          echo "TEST STAGE HAS BEEN COMPLETED"
        }
      }
      post
      {
        success
        {
          archiveArtifacts "Tests/TestResults/*/coverage.cobertura.xml"
          publishCoverage adapters: [istanbulCoberturaAdapter(path: 'Tests/TestResults/*/coverage.cobertura.xml', thresholds:
          [[failUnhealthy: true, thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], checksName: '',
          sourceFileResolver: sourceFiles('NEVER_STORE')
        }
      }
    }
    stage("DEPLOY")
    {
      steps
      {
        sh 'docker-compose up -d'
        echo "HELLO DEPLOY :DDDD"
      }
    }
  }
  post {
    always {
      sh 'docker-compose down'
    }
  }
}
