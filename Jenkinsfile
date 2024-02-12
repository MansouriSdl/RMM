pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                script {
                    docker.build("RMM:${env.BUILD_ID}").inside {
                        sh 'dotnet restore'
                        sh 'dotnet build --configuration Release'
                    }
                }
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }
        stage('Deploy') {
            steps {
                script {
                    docker.withRegistry('https://registry-1.docker.io/', '1996') {
                        docker.image("RMM:${env.BUILD_ID}").push("latest")
                        docker.image("RMM:${env.BUILD_ID}").push("${env.BUILD_ID}")
                    }
                }
            }
        }
    }
}
