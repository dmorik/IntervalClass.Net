# Testing IsPoint function

The tests guarantees the following behavior:

|Argument|Result|
|-:|:-|
|`Empty`|`False`|
|`[0, +Inf]`|`False`|
|`[-Inf, 0]`|`False`|
|`[-Inf, +Inf]`|`False`|
|`[<number1>, <number2>]`|`False`|
|`[<number>, <number>]`|`True`|
