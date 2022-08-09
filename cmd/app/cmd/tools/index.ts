export {}

import {Tools, tool} from "../core"

type robocopy = "robocopy"
type _7z = "7z"

export type ToolName = 
    | _7z
    | robocopy


export const ToolNames : Tools<ToolName> = [
    tool("7z"),
    tool("robocopy")
]
