pipeline {
    agent any

    // Define environment variables
    environment {
        // Change these variables according to your project
        REPO_URL = 'https://github.com/MansouriSdl/RMM.git'
        BRANCH_NAME = 'master' // or whichever branch you use
        IMAGE_NAME = 'debian/rmm.api' // Name of the Docker image
        CONTAINER_NAME = 'debian/rmmcontainer' // Name for the running container
    }

    stages {
        stage('Checkout') {
            steps {
                // Checks out the specified branch from your repo
                git branch: "${BRANCH_NAME}", url: "${REPO_URL}"
            }
        }

        stage('Build and Publish Docker Image') {
            steps {
                script {
                    // Log in to DockerHub or your Docker registry if needed
                    // sh 'echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin'
                    
                    // Build the Docker image
                    sh 'docker build -t ${IMAGE_NAME}:latest -f RMM/Dockerfile .'
                    
                    // Push the image to a registry (optional)
                    // sh 'docker push ${IMAGE_NAME}:latest'
                }
            }
        }

        stage('Deploy Container') {
            steps {
                script {
                    // Stop and remove the previous container if it exists
                    sh 'docker stop ${CONTAINER_NAME} || true'
                    sh 'docker rm ${CONTAINER_NAME} || true'
                    
                    // Run the new container
                    sh 'docker run -d --name ${CONTAINER_NAME} -p 9988:80  ${IMAGE_NAME}:latest'
                }
            }
        }
    }

    post {
        success {
            echo 'Deployment succeeded!'
        }

        failure {
            echo 'Deployment failed.'
        }
    }
}
