# `UxEvent`

## method `On`

public function `On` (string  *`$event`*, PhpValue *`$obj`*, PhpCallable *`$action`*, array *`$args`* = null) : ***void***

| Type        | Arg Name | Default | Description             |
|:------------|:---------|:--------|:------------------------|
| string      | event    |         | name action for connect |
| PhpValue    | obj      |         | object in godot         |
| PhpCallable | action   |         | callable function       |
| array       | args     | null    | arguments for function  |

> **return**: *void*

## method `OnListener`

> adding a function or method (callable)

public Callable `OnListener`(string *`$event`*, PhpValue *`$current`*, PhpArray *`$listener`*, array *`$args`* = null): ***void***

| Type        | Arg Name | Default | Description                |
|:------------|:---------|:--------|:---------------------------|
| string      | event    |         | name action for connect    |
| PhpValue    | current  |         | object in godot            |
| PhpCallable | listener |         | array(2)\[object, method\] |
| array       | args     | null    | arguments for function     |

> **return**:  *void*

## method `OnListenerAll` (all modifier)

> adding a function or method (callable)

public Callable `OnListenerAll`(string *`$event`*, PhpValue *`$current`*, PhpArray *`$listener`*, array *`$args`* = null): void

| Type        | Arg Name | Default | Description                |
|:------------|:---------|:--------|:---------------------------|
| string      | event    |         | name action for connect    |
| PhpValue    | current  |         | object in godot            |
| PhpCallable | listener |         | array(2)\[object, method\] |
| array       | args     | null    | arguments for function     |

> **return**:  *void*


# class `UFunc`

## method `Add`

> adding a function (callable)

public static `Add`(PhpCallable *`$action`*, array *`$args`* = null): ***\Godot\Callable***

| Type        | Arg Name | Default | Description            |
|:------------|:---------|:--------|:-----------------------|
| PhpCallable | $action  |         | callable function      |
| array       | $args    | null    | arguments for function |

> **return**:  *Godot\Callable*

