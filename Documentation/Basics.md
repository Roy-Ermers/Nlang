# N Scripting language

------
<!-- TOC -->

- [N Scripting language](#n-scripting-language)
    - [Namespaces](#namespaces)
    - [Classes](#classes)
        - [Constructors](#constructors)
    - [Basic types](#basic-types)
    - [functions](#functions)
    - [Variables](#variables)

<!-- /TOC -->

## Namespaces

the namespaces are simple folders, and these folders contain `*.n` files which are the classes.

## Classes

The classes are the files inside the folders of the project root, the class name is the filename.

### Constructors

class constructors are defined as ``func Init()`` this function contains all the logic for class initializing.

## Basic types

------
These are the basic types standard implemented in this language
| Types | Possible values             | Example                                   |
| ------| :---------------------------|-------------------------------------------|
| Bool  | True/False                  | `Bool example = true`|
| Number| Either an Integer or Decimal| `Num example = 1` or `Num example = 1.5`|
| String| A list of UTF-8 Characters  | `Str example = "test"`                   |

## functions

functions are defined in a class file, like

```csharp
func MyExampleFunction()
    //function body
```In

functions can return values:

```csharp
func GetNumber() : Num
    Num result = 5;
    return 5;
```

and functions can have arguments:

```csharp
func Multiply(Num number1, Num number2) : Num
    return number1 * number2
```

## Variables

Variables is the way to store a value temporary.
you can declare a variable this way:

```csharp
Type identifier = value
```