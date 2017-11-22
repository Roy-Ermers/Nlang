<!-- TOC -->

- [Compiler logic](#compiler-logic)
	- [Different Code Blocks](#different-code-blocks)
	- [References](#references)
	- [Detecting blocks](#detecting-blocks)

<!-- /TOC -->
# Compiler logic

This page is meant to write my toughts about the compiler.

## Different Code Blocks

With my knowledge of coding there are  several types of codeblocks, codeblocks are a block of code typical between `{ }`.

so, which types are available?

```lua
func Init()
//this is a codeblock, it can be run apart an contain local variables.
    if(number<number2)
        //this is also a codeblock. because it can hold local variables.
    while (true)
        //this is also a codeblock
}
```

## References

A standard programming language has references, references are a link to a variable or constant value, so in fact it is a variable, but its not:

```lua
//this argument is a reference to an existing variable or value
func Init(Str arg)
    //this is variable
    Num Number = 4
    arg = "this now becomes a variable and overwrites the reference of the argument"
```

A variable and a reference have two things in common, they both contain a value and a type.

## Detecting blocks

In programming languages codeblocks can be merged, this means a function can contain an if/while or for loop.

```lua
func Init(Str argument)
    if(argument=="TEST")
        Console.WriteLine(argument)
```

In N the blocks are defined with tabs or 4 spaces, the block ends if the indentation goes back to the original before the function.