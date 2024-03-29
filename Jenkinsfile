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
        }
        echo "STARTUP STAGE HAS BEEN COMPLETED"
      }
    }
    stage("BUILD")
    {
      steps
      {
        sh "dotnet restore"
        sh "dotnet build CineMoviesWeb/CineMoviesWeb.csproj"
        sh 'docker-compose build'
        sh "npm install testcafe testcafe-reporter-xunit"
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
          /*sh 'docker-compose run --rm cinemoviesweb Tests'*/
          /*sh "node_modules/.bin/testcafe chrome CineMoviesWeb/starstar/star -r xunit:res.xml"*/
        }
        
        sh 'sudo chmod +x setup_k6.sh'
        sh 'sudo ./setup_k6.sh'
        sh "k6 run -e HOSTING=easvcinemovies.azurewebsites.net k6Tests.js"
        
        echo "TEST STAGE HAS BEEN COMPLETED"
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
        /*sh 'docker-compose up -d --remove-orphans'*/
        echo "DEPLOY STAGE HAS BEEN COMPLETED"
      }
    }
  }
  post {
    always {
      /*sh 'docker-compose down'*/
      echo "POST HAS BEEN COMPLETED"
    }
  }
}
