# MultiPluginProjects

This repo shows how to add multiple plugin projects deployed via a single spkl command.

If you have multiple Plugin Assemblies, you can install spkl to each project and deploy separately using `deploy-plugins.bat`. 
However, if you wanted to deploy all the plugin assemblies using a single spkl command this project shows the following:

1. A shared project that contains the `CrmPluginRegistrationAttribute.cs`. Instead of installing the spkl nuget in each Plugin Project (which would create a copy of this class) there is a single project (spkl) that has the spkl nuget package installed, and a shared proejct that contains a copy of `CrmPluginRegistrationAttribute.cs` that is referenced by each Plugin project. When you run pac plugin init, a copy of the `PluginBase.cs` class is created - you could also move this to the shared common project as well.

2. Each Plugin Project has it's own `spkl.json` (copied from the spkl project). The spkl.json that was automatically added when the spkl nuget package was added to the spkl project is deleted.

3. The deploy-plugins.bat script is moved to the spkl project root so that the path ..\.. will move one step up to the solution folder. This results in all the spkl.json configuration files being discovered and deploy plugins is run on each.

## Solution File Structure

```text
.
├── .vs
├── Common
│   ├── PluginBase.cs [1]
│   └── CrmPluginRegistrationAttribute.cs [2]
├── packages
├── PluginA [3]
│   ├── PluginA.cs
│   ├── PluginA.csproj
│   ├── PluginA.snk
│   └── spkl.json [4]
├── PluginB [2]
│   ├── PluginB.cs
│   ├── PluginB.csproj
│   ├── PluginB.snk
│   └── spkl.json [4]
├── spkl [6]
│   ├── deploy-plugins.bat [5]
│   ├── packages.config
│   └── spkl.csproj
└── MultiPluginProjects.sln
```

[1] PluginBase created using `pac plugin init` - and then moved to common project (with namespace removed)

[2] Added automatically when spkl is installed to the spkl project, then moved to the common project

[3] Created using `pac plugin init` - and then the PluginBase.cs moved and the common project referenced.

[4] Copied from spkl project

[5] Moved from the spkl batch folder to the project root so that the solution is used as the root rather than the proejct. This results in all the spkl.json files being picked up when commands are run.

[6] Class library project with the spkl nuget package added (so that the spkl.exe can be picked up by the scripts)