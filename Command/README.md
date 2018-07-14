##personal notes

The command pattern executes a method.

Its good for implementing undoable actions.

Because the client class does not pass arguments to the command method, the command executed must have all the context necessary to execute de command.

This makes the command method more broad, but less customizable than, lets say, the strategy pattern.
