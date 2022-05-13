# Polybit

## Bitfield Specification

A *bitfield* is a blittable type B with instance data D that can be presented as partition P defined
by named segments s0,..s(N-1) of designated widths. Thus, a concrete bitfield can be completely specified
with a single enum E with N literals with values that specify the widths of the segments in P

