pipeline {
    agent any
    environment {
        DOCKERHUB_CREDENTIALS = credentials('dockerhub-creds')
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build & Test') {
            steps {
                sh 'dotnet build'
                sh 'dotnet test tests/SouravNetApp.Tests/SouravNetApp.Tests.csproj'
            }
        }
        stage('Docker Build') {
            steps {
                script {
                    dockerImage = docker.build("souravdutta06/souravnetapp:latest")
                }
            }
        }
        stage('Docker Push') {
            steps {
                sh "echo \$DOCKERHUB_CREDENTIALS_PSW | docker login -u \$DOCKERHUB_CREDENTIALS_USR --password-stdin"
                sh "docker push souravdutta06/souravnetapp:latest"
            }
        }
        stage('Deploy to AppServer') {
            steps {
                sshagent(credentials: ['appserver-ssh']) {
                    sh "ssh -o StrictHostKeyChecking=no azureuser@<ApplicationServer_IP> 'docker pull souravdutta06/souravnetapp:latest'"
                    sh "ssh azureuser@<ApplicationServer_IP> 'docker run -d -p 80:80 souravdutta06/souravnetapp:latest'"
                }
            }
        }
    }
}
