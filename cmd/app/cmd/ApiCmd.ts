export {}

import { CmdSpec } from "../core";

export type ApiCmd = 
    | "api/emit/tables"
    | "api/emit/cmddefs"
    | "api/emit/deps"
    | "api/emit/impls"
    | "api/emit/pdb-index"
    | "api/emit/pdb-info"
    | "api/emit/pdb/methods/symbols"
    | "api/emit/pdbinfo"
    | "api/emit/symbols"
    | "api/emit/tokens"
    | "api/emit/types"

type CmdGroup = "api"

const group:CmdGroup = "api"


export interface ApiCmdSpec extends CmdSpec<ApiCmd,CmdGroup> {

}

export const CmdSpecs:Array<ApiCmdSpec> = [
    {
        Name:"api/emit/cmddefs",
        Divison:group,
    },
    {
        Name:"api/emit/deps",
        Divison:group,
    }
]
