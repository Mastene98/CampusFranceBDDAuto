pipeline {
    agent any

    stages {
        stage('1 - Verification de .NET') {
            steps {
                echo 'Verification de la version .NET installee'
                bat 'dotnet --version'
            }
        }

        stage('2 - Recuperation des dependances') {
            steps {
                echo 'Recuperation des dependances NuGet du projet'
                bat 'dotnet restore'
            }
        }

        stage('3 - Compilation du projet') {
            steps {
                echo 'Compilation du projet Campus France'
                bat 'dotnet build --configuration Release'
            }
        }

        stage('4 - Execution des tests') {
            steps {
                echo 'Execution des tests automatises'
                bat 'dotnet test --configuration Release'
            }
        }
    }

    post {
        success {
            echo 'SUCCES : le projet a ete compile et les tests ont ete executes correctement.'
        }

        failure {
            echo 'ECHEC : une erreur est survenue pendant la compilation ou l execution des tests.'
        }

        always {
            echo 'Fin de la pipeline Jenkins.'
        }
    }
}