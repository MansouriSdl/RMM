pipeline {
    agent any
    environment {
        // Define registry and credentials
        DOCKER_REGISTRY_URL = 'https://registry-1.docker.io/'
        DOCKER_CREDENTIALS_ID = '1996'
    }
    stages {
        stage('Build') {
            steps {
                script {
                    // Build Docker image
                    def appImage = docker.build("myapp:${env.BUILD_ID}")
                }
            }
        }
        stage('Test') {
            steps {
                // Add your testing commands here
                sh 'echo "Running tests"'
            }
        }
        stage('Deploy') {
            steps {
                script {
                    docker.withRegistry("${env.DOCKER_REGISTRY_URL}", "${env.DOCKER_CREDENTIALS_ID}") {
                        // Push image to Docker registry
                        def appImage = docker.image("myapp:${env.BUILD_ID}")
                        appImage.push("latest")
                        appImage.push("${env.BUILD_ID}")
                    }
                }
            }
        }
    }
}
