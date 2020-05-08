# .NET Native UWP Samples
This repo contains use-at-your-own-risk samples on using UWP 6.2.X builds in various C++/C# interoperability configurations. 

This repo is intended to provide samples for not-so-common .NET Native scenarios:
- **ManagedNativeInterop**: This is a C# UWP -> C++ WinMD sample demonstrating a C# app hosting a C++ component.  The sample supports app min ver <= RS2 (.Net Core 1.1/.NET native 1.7) as well as min ver >= RS3 (.NET core 2.0/.NET native 2.2). Supports x86/x64/arm32/arm64.  
- **CPP-CSharp-V1**: This is a C++ UWP -> C# WinMD sample demonstrating the default hybrid UWP scenario.  The App Min Version is RS and will run against .NET Core 1.1 (debug mode) / .NET Native 1.4 (release mode). Supports x86/x64/arm32.  
- **CPP-CSharp-V2**: This is another C++/JS UWP -> C# WinMD sample but with App Min Ver targeting RS3, and therefore runs against .NET Core 2.0 (debug mode) / .NET Native 2.2 (release mode). Supports x86/x64/arm32/arm64.
- **CSTarget11RunCore2**: C# UWP app targeting RS2 and overriding the default .NET Core 1.1 runtime. Executes the app against .NET Core 2.0 on the Debug configuration, though builds agianst the RS2-based reference assemblies. Release mode will target .NET native 1.7 (which is the default). Supports x86/x64/arm32.

Note that .NET Native has two special configurations that are controlled with the Application Minimum version in the app config:
- <= RS2 (15063) - Debug Configuration uses .NET Core 1.1, Release configuration uses .NET Native 1.7.  Supports x86/x64/arm32.
- \>= RS3 (16299)-  Debug Configuration uses .NET Core 2.0, Release configuration uses .NET Native 2.2.  Supports x86/x64/arm32/arm64. .NET native is used for both Debug and Release configurations on ARM64. 

A C++ or Javascript UWP app hosting a C# WinMD is a special case.  In that scenario, app min config works as follows:
- <= RS2 (15063) - Debug Configuration uses .NET Core 1.1, Release configuration uses .NET Native 1.4.  Supports x86/x64/arm32.
- \>= RS3 (16299)-  Not a currently supported configuration.

I hope that these samples are useful to people.
