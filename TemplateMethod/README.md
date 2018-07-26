# Template Method

[From SourceMaking:](https://sourcemaking.com/design_patterns/template_method)

Define the skeleton of an algorithm in an operation, deferring some steps to client subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

Base class declares algorithm 'placeholders', and derived classes implement the placeholders.

## Personal notes

Enforce an algorithm structure(steps, order), while giving derived implementations mandatory steps but allowing them to override customizable steps.
