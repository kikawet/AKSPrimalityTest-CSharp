# 🆕 AKSPrimalityTest - C#

## ❓ What is My Project?

Proof of concept programming AKS primality test in c# using vscode with remote code using a docker container

the solution is split in multiple projects:

  - AKSBuild: console program that reads number from console then outputs if is prime
  - AKSService: library that contains the tests
  - AKSService.Tests: Xunit tests of the service


## ⚡ Getting Started

1. clone the code
2. open the folder with vscode and set it to build a docker container with the cloned project

Should be ready to start

## 🔧 Building and Running

```
$ dotnet run -p AKSBuild -- <NUMBER_TO_TEST>
```

### 🔨 Build the Project

```
$ dotnet build
```
### ▶ Running and Settings
Run the built dll
```
$ AKSBuild/bin/AKSBuild.dll <NUMBER_TO_TEST>
```

## 🤝 Collaborate with My Project

This is a proof of concept but if you want to help feel free to create a Pull Request or Issue
