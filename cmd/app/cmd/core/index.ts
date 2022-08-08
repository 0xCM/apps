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


export interface Tool<E> extends Actor<E>
{

}

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