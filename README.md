# Net Extensions
![nuget downloads](https://img.shields.io/nuget/dt/NetExtensions-core.svg?color=green&label=downloads&logo=nuget)
![Last Commit](https://img.shields.io/github/last-commit/tamerfahmy/NetExtensions.svg?logo=github)
![Code Quality](https://img.shields.io/codacy/grade/aeba1b94ef69464882823804668d40a9.svg?logo=Codacy)
![Build](https://img.shields.io/azure-devops/build/tamerfahmy/NetExtensions/4/master.svg?label=build)
![Tests](https://img.shields.io/azure-devops/tests/tamerfahmy/NetExtensions/4.svg)

NetExtensions an open-source cross platform set of commonly used extensions methods that is mostly needed at any project. This library is built with .Net Standard 1.0 which supports many .Net frameworks such as .Net Core, .Net Framework, Xamarin and others.

The library uses the same namespace for all extensions methods where it will be much easier to use it simply explorer it by the IDE Intellisense for example Visual Studio. So no need to search or include extra namespaces at your project.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. This solutions will contain many diffrent projects One core project for primitive .Net data types and a separate project for other .Net namespaces or frameworks.

## Installation
Each project will have a separate NuGet package which allows to install only the required packages based on the requirments. NetExtensions-Core libaray will be the base which might be a prerequisite in other extension projects.

You can use these set of extension methods by installing it via the below Nuget command. 
```sh
PM> Install-Package NetExtensions-Core
```

## Projects
### NetExtensions-Core
This project will contain the core extension methods for Primitive .Net Data Types.

