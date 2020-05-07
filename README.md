# .NET Native UWP Samples
This repo contains use-at-your-own-risk samples on using UWP 6.2.X builds in various C++/C# interoperability configurations. 

Note that .NET Native has two special configurations that are controlled with the Application Minimum version in the app config. 
App Min Ver settings:
-<= RS2 (15063) - Debug Configuration uses .NET Core 1.1, Release Congiruation uses .NET Native 1.7.  Supports x86/x64/arm32.
->= RS3 (16299)-  Debug Configuration uses .NET Core 2.0, Release Congiruation uses .NET Native 2.2.  Supports x86/x64/arm32/arm64. Note that we only support .NET native on ARM64. 

A C++ or Javascript UWP app hosting a C# WinMD is a special case.  In that scenario, app min config works as follows:
-<= RS2 (15063) - Debug Configuration uses .NET Core 1.1, Release Congiruation uses .NET Native 1.4.  Supports x86/x64/arm32.
->= RS3 (16299)-  Not a currently supported configuration.

This repo is intended to provide the following workarounds:
- C++/JS UWP -> C# WinMD - demonstrate App Min Ver targeting <= RS2 and running against .NET Core 1.1/.NET Native 1.4. Supports x86/x64/arm32.
- C++/JS UWP -> C# WinMD - demonstrate App Min Ver targeting >= RS3 and running against .NET Core 2.0/.NET Native 2.2. Supports x86/x64/arm32/arm64.
- C# UWP targeting <= RS2 and overriding the default .NET Core 1.1 runtime and executing against .NET Core 2.0 (Debug scenario only). Supports x86/x64/arm32.
