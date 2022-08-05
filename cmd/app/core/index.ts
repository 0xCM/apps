export {}

export interface CmdSpec<N,G> {
    Name:N
    Group:G
    Intent?:string
}



// export interface CmdName<N>{
//     Name:N
// }

// export interface CmdKind<K>{
//     Kind?:K
// }

// export interface CmdGroup<G>{
//     Group?:G
// }

// export interface CmdSpec<N,G> extends CmdName<N>, CmdGroup<G> {
//     /**The command intent */
//     Intent?:string
// }
