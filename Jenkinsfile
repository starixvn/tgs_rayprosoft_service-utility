pipeline {
	agent any
	
	environment {
		Registry = "registry.gitlab.com/rayprosoft/service-utility/"
	}
	
	parameters {
		gitParameter branchFilter: 'origin/(.*)', defaultValue: 'master', name: 'BRANCH', type: 'PT_BRANCH'
	}

	stages {
		stage('Clone') {
			steps {
				git branch: "${params.BRANCH}", url: 'https://gitlab.com/rayprosoft/service-utility.git' , credentialsId: 'gitlab-user-pwd'
			}
		}
	
		stage('Build') {
			steps {
				sh "dotnet build service-utility.sln"
			}
		}
		
		stage('Pre Nuget') {   
			steps {
				timeout(time:1, unit: 'MINUTES') {
				   input message: "Push to nuget ?"
				}
			}
		}
		
		stage('Push Nuget') {   
			steps {
				sh  'dotnet pack ServiceUtility/ServiceUtility.csproj'
				sh  'dotnet nuget push **/*.nupkg --source "gitlab" --skip-duplicate'
			}
		}	
	}
}