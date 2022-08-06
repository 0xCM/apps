export {}

export interface Node<N>
{
    Name:N
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

export interface Division<G>
{
    Divison:G
}

export interface SubDivision<S,G> extends Division<G>
{
    Subgroup:S
}

export interface CmdGroup<G> extends Division<G>
{

}

export interface CmdSpec<N,G> extends Node<N>, CmdGroup<G> {
    Intent?:string
}

export interface SubCmd<N,G> extends CmdSpec<N,G>
{

}
