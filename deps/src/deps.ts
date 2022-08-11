import {targets,compilationOptions,libraries,runtimeTarget,runtimes} from "../artifacts/win-x64/deps.deps.json"
import {Dependency,DependencyList} from "./types"

const Targets=targets
const CompilationOptions=compilationOptions
const Libraries=libraries
const RuntimeTarget=runtimeTarget
const Runtimes=runtimes

const NetCoreTarget  = Targets[".NETCoreApp,Version=v6.0"]
const WinX64Target = Targets[".NETCoreApp,Version=v6.0/win-x64"]
const WinX64DepsRoot = WinX64Target["deps/1.0.0"]
const WinX64Deps = WinX64DepsRoot.dependencies



