export {}

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

export type CliCmd =
    | "cli/emit/blobs"
    | "cli/emit/fields"
    | "cli/emit/headers"
    | "cli/emit/hex"
    | "cli/emit/ildat"
    | "cli/emit/literals"
    | "cli/emit/msil"
    | "cli/emit/refs"
    | "cli/emit/stats"
    | "cli/emit/strings"

export type EtlCmd =
    | "xed/etl"
    | "llvm/etl"
    | "sde/etl"
    | "sdm/etl"
    | "project/etl"
    | "intel/etl"

export type CheckCmd =
    | "asm/check/bitstrings"
    | "asm/check/exec"
    | "asm/check/jmp"
    | "asm/check/sigs"
    | "asm/check/specs"


export type AsmCmd=
    | "asm/docs/emit"
    | "asm/emit/tokens"
    | "asm/nasm/import"