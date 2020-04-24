# Develop and distribute Azure Functions using K8s and CI/CD

This is the public repository used in the demo of the "Develop and distribute Azure Functions using K8s and CI/CD" session presented during the "Global Azure Milan 2020 - Online" event. 

## Setup

There are few things into the repository:
- NewsFunction: it's the Azure Function that can be deployed
- azure-pipelines.yml and azure-pipelines-k8s.yml: those are the Azure DevOps YAML pipelines to deploy into Azure Function or AKS

The resources required in Azure are:
- AKS cluster
- Azure Container Registry
- Azure Function
