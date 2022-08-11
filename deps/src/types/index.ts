export {}

export type Dependency=[name:string,version:string]


export interface DependencyList {
    dependencies:Array<Dependency>
}

export interface RuntimeTarget {
    name:string
    signature:string
}

export interface ComponentVersion {
    assemblyVersion:string
    fileVersion:string
}



/*
{
  "runtimeTarget": {
    "name": ".NETCoreApp,Version=v6.0/win-x64",
    "signature": ""
  },
  "compilationOptions": {},
  "targets": {
    ".NETCoreApp,Version=v6.0": {},
    ".NETCoreApp,Version=v6.0/win-x64": {
      "deps/1.0.0": {
        "dependencies": {
          "MSBuild.StructuredLogger": "2.1.669",
          "Microsoft.Build.Runtime": "17.2.0",
          "Microsoft.CodeAnalysis": "4.3.0-2.final",

*/