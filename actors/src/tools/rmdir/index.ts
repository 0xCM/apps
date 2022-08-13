export{}

import {CmdActionSpec} from "../../core"

export type rmdir = "rmdir"
export type actor = rmdir
export type flag = | "/S" | "/Q"
export type path = string

export type ToolFlags<T> = Array<T>

export type Flags = ToolFlags<flag>

// RMDIR [/S] [/Q] [drive:]path
export type usage = `${actor} ${path}`