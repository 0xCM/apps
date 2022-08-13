export {}

import {rmdir} from "./rmdir"
import {_7z} from "./7z"
import {robocopy} from "./robocopy"

export type ToolName = 
    | _7z
    | robocopy
    | rmdir

