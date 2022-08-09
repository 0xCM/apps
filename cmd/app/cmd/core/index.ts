export {}

export interface Named<N>
{
    Name:N
}

export interface Valued<V>
{
    Value:V
}

export interface Node<N> extends Named<N>
{
    
}

export interface Actor<A> extends Node<A>
{

}

export interface IKinded<K>
{
    Kind:K
}

export interface Action<K,A> extends Node<A>, IKinded<K>
{

}

export interface Group<G>
{
    Group:G
}


// export interface Tool<E> extends Actor<E>
// {

// }


export type Tool<N> = {
    Name:N
}

export type Tools<N> = Array<Tool<N>>

export interface Flow<S,T>
{
    Source:S
    Target:T
}


export interface Workflow<W,S,T> extends Flow<S,T>
{

    run:W
}


export interface SubDivision<S,G> extends Group<G>
{
    Subgroup:S
}

export interface CmdGroup<G> extends Group<G>
{

}

export type ActionKind = "app" | "tool"

export interface ToolGroup<G>  extends Group<G>
{

}

export interface CmdSpec<K,N,G> extends Action<K,N>, CmdGroup<G> {
    Intent?:string
}


export interface AppCmdSpec<N,G> extends CmdSpec<ActionKind,N,G> {
    Kind:"app"
}

export interface SubCmd<K,N,G> extends CmdSpec<K,N,G>
{

}

export type CmdSpecs<K,C,N> = Array<CmdSpec<K,C,N>>


export interface CmdActionSpec<F,N> {
    Flag:F
    Name:N
    Intent?:string
}

export interface CmdOption<N,V> extends Named<N>, Valued<V>{
    
}

export type Cmd<N> = {
    Name:N
}
    

export type CmdProvider<P,N> = {
    readonly Name: P;
    Commands: Array<Cmd<N>>;
};

export function cmd<N>(name: N) : Cmd<N>
{
    return {
        Name: name
    }
}

export function tool<N>(name: N) : Tool<N>
{
    return {
        Name: name
    }
}

export declare function commands<N>(names: Array<N>): Array<Cmd<N>>;

export declare function provider<P,T>(name: P, names: Array<Cmd<T>>): CmdProvider<P,T>;
export interface EltCmd {
    Name: "etl";
}

export type sdm = "sdm";
export type xed = "xed";
export type llvm = "llvm";
export declare const SdmEtl: EltCmd;
export declare const XedEtl: EltCmd;
export declare const SdmCmd: CmdProvider<sdm,string>;
export declare const XedCmd: CmdProvider<xed,string>;
export declare const LlvmCmd: CmdProvider<llvm,string>;
export declare const Commands: {
    Sdm: CmdProvider<"sdm", string>;
    Xed: CmdProvider<"xed", string>;
    Llvm: CmdProvider<"llvm", string>;
};
//# sourceMappingURL=Commands.d.ts.map