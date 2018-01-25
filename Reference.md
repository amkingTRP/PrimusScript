# Primus Script - Base Reference

## Event Manager
The Event Manager object contains one or more events in a list.  
It holds an execution stack of the current command to execute, with a special placeholder command called EventStart to show where
the current event started. 

## Global and Local variables and flags
The PrimusScript environment holds some global variables (integers) and flags (booleans).  These are accessible to all Event Managers.  
Event Managers also have their own set of local variables and flags, accessible to only their internal events and triggers.  
All variables and flags are indexed by an integer value

## Structure of the Script file
Each file contains the script(s) for an Event Manager

``` xml
<primusscript name="event manager name">
  <alias word="alias word" value="numeric value" />
  <event priority = "1"> x 1 or more
    <trigger>
      <condition /> x 1 - see later
    </trigger>
    <commands>
      <command /> x 1 or more - see later
    </commands>
  </event>
</primusscript>
```

## Triggers
Events are triggered in order of descending priority.  
Each update cycle, the PrimusScript environment checks each event manager, which in turn checks its internal event list (from high priority to low).  Each event checks its trigger condition and if true then that event is pushed onto the execution stack for that event manager.  This pushes the EventStart "command" onto the stack and then pushes the first command of that event.  
If an event is in the middle of being executed (e.g. it's waiting on a flag or variable), it's possible for a higher priority event to interupt it and be executed first.

## Conditions
Conditions are boolean operations that can be nested.   

### GreaterVal
Returns true if the named local variable is greater than the provided value.   
Operands:
```
A   - the number of the variable.
val - the value to compare against.
```
Example- Is local variable 1 greater than the numeric value 12?
``` xml
 <greaterval A="1" val="12"/>
```
### LessVal
Returns true if the named local variable is less than the provided value.   
Operands:
```
A   - the number of the variable.
val - the value to compare against.
```
Example- Is local variable 1 less than the numeric value 12?
``` xml
 <lessval A="1" val="12"/>
```
### EqualsVal
Returns true if the named local variable is equal to the provided value.   
Operands:
```
A   - the number of the variable.
val - the value to compare against.
```
Example- Is local variable 1 equals to the numeric value 12?
``` xml
 <equalsval A="1" val="12"/>
```
### GlobalGreaterVal
Returns true if the named global variable is greater than the provided value.   
Operands:
```
A   - the number of the variable.
val - the value to compare against.
```
Example- Is global variable 1 greater than the numeric value 12?
``` xml
 <globalgreaterval A="1" val="12"/>
```
### GlobalLessVal
Returns true if the named global variable is less than the provided value.   
Operands:
```
A   - the number of the variable.
val - the value to compare against.
```
Example- Is global variable 1 less than the numeric value 12?
``` xml
 <globallessval A="1" val="12"/>
```
### GlobalEqualsVal
Returns true if the named global variable is equal to the provided value.   
Operands:
```
A   - the number of the variable.
val - the value to compare against.
```
Example- Is global variable 1 equals to the numeric value 12?
``` xml
 <globalequalsval A="1" val="12"/>
```
### GreaterVar
Returns true if the named local variable A is greater than the named local variable B.   
Operands:
```
A   - the number of the first variable.
B   - the number of the second variable.
```
Example- Is local variable 1 greater than local variable 2?
``` xml
 <greaterval A="1" B="2"/>
```
### LessVar
Returns true if the named local variable A is less than the named local variable B.   
Operands:
```
A   - the number of the first variable.
B   - the number of the second variable.
```
Example- Is local variable 1 less than local variable 2?
``` xml
 <lessvar A="1" B="2"/>
```
### EqualsVar
Returns true if the named local variable A is equal to the named local variable B.   
Operands:
```
A   - the number of the first variable.
B   - the number of the second variable.
```
Example- Is local variable 1 equal to local variable 2?
``` xml
 <equalsvar A="1" B="2"/>
```


