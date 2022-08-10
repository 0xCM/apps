export {}

import { AppCmdSpec, IKinded, ApiGroupName } from "../core";

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

class Xyx implements IKinded<CmdGroup>{
    Kind = group;
}

export type ApiCmdSpec = AppCmdSpec<ApiCmd>

export type ApiCmdSpecs = Array<ApiCmdSpec>

export const CmdSpecs:ApiCmdSpecs = [
    {
        Kind:"app",
        Name:"api/emit/tables",
        Group:group,
    },
    {
        Kind:"app",
        Name:"api/emit/cmddefs",
        Group:group,
    }
]
