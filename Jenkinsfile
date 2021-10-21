pipeline {
	agent any
	
	environment {
		BuildConfiguration="Debug"
	}
	
	parameters {
		gitParameter branchFilter: 'origin/(.*)', defaultValue: 'master', name: 'BRANCH', type: 'PT_BRANCH'
	}

	stages {
		stage('Build') {
			steps {
				sh "dotnet build"
			}
		}
		
		stage('Pack') {
			steps {
				sh  'dotnet pack ServiceUtility/ServiceUtility.csproj -c $BuildConfiguration --no-build --no-restore'
			}
		}
		
		stage('Push Nuget') {   
			steps {
				sh  'dotnet nuget push ServiceUtility/bin/$BuildConfiguration/*.nupkg -s "raypro-baget" -k admin --skip-duplicate'
			}
		}	
	}
}