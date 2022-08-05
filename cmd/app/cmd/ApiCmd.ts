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

export type ApiCmdGroup = "api"

const group:ApiCmdGroup = "api";


export interface ApiCmdSpec extends CmdSpec<ApiCmd,ApiCmdGroup> {

}

export const CmdSpecs:Array<ApiCmdSpec> = [
    {
        Name:"api/emit/cmddefs",
        Group:group,
    },
    {
        Name:"api/emit/deps",
        Group:group,
    }
]
