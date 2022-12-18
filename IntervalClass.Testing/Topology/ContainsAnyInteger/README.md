# Testing 'ContainsAnyInteger' function

## Designations

|Designation|Meaning|
|-|-|
|`-Inf`|`double.NegativeInfinity`|
|`+Inf`|`double.PositiveInfinity`|
|`NaN`|`double.NaN`|
|`<number>`|common number|
|`<number1>, <number2>`|common numbers & `number1` is less or equal than `number2`|

## The tests guaranteed behavior

|Argument|Result|
|-|-|
|`Empty`|`False`|
|`[0, +Inf]`|`True`|
|`[-Inf, 0]`|`True`|
|`[-Inf, +Inf]`|`True`|
|`[<number1>, <number2>]`|`True` if there is the integer between `<number1>` and `<number2>`, `False` - otherwise|
|`[<number>, <number>]`|`True` if the number is integer, `False` - otherwise|
