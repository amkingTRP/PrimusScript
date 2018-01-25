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

### LocalFlagSet
Returns true if the named local flag is true.   
Operands:
```
flag - the number of the flag to check.

```
Example- Is local flag 1 set?
``` xml
 <localflagset flag="1" />
```
### GlobalFlagSet
Returns true if the named global flag is true.   
Operands:
```
flag - the number of the flag to check.

```
Example- Is global flag 1 set?
``` xml
 <globalflagset flag="1" />
```

### AND
Returns true only if both sub-conditions are true.   
Operands:
```
none
```
Requires two nested conditions.  AND, OR, and NOT can be nested.   
Example- Is both global flag 1 set and global flag 2 set?
``` xml
<and>
 <globalflagset flag="1" />
 <globalflagset flag="2" />
</and>
```
### OR
Returns true if either sub-condition is true.   
Operands:
```
none
```
Requires two nested conditions.  AND, OR, and NOT can be nested.   
Example- Is either global flag 1 set or global flag 2 set?
``` xml
<or>
 <globalflagset flag="1" />
 <globalflagset flag="2" />
</or>
```
### NOT
Inverts the result of the single nested condition.    
Operands:
```
none
```
Requires one nested condition.  AND, OR, and NOT can be nested.   
Example- Is global flag 1 *not* set?
``` xml
<not>
 <globalflagset flag="1" />
</not>
```

## Basic Commands
### GetGlobalVar
Takes the value of a global variable and copies into a local variable   
Operands:
```
src  = number of the global variable to copy from
dest = number of the local variable to copy into
```
   
Example- Copy global variable 1 into local variable 2
``` xml
<getglobalvar src="1" dest="1" />
```
### PutGlobalVar
Takes the value of a local variable and copies into a global variable   
Operands:
```
src  = number of the local variable to copy from
dest = number of the global variable to copy into
```
   
Example- Copy local variable 1 into global variable 2
``` xml
<putglobalvar src="1" dest="1" />
```

### SetGlobalFlag
Set a global flag to true   
Operands:
```
flag = number of the global flag to set as true

```
   
Example- Set global flag 1 to true;
``` xml
<setglobalflag flag="1"  />
```
### UnsetGlobalFlag
Set a global flag to false   
Operands:
```
flag = number of the global flag to set as false

```
   
Example- Set global flag 1 to false;
``` xml
<unsetglobalflag flag="1"  />
```

### SetLocalFlag
Set a local flag to true   
Operands:
```
flag = number of the local flag to set as true

```
   
Example- Set local flag 1 to true;
``` xml
<setlocalflag flag="1"  />
```
### UnsetLocalFlag
Set a local flag to false   
Operands:
```
flag = number of the local flag to set as false

```
   
Example- Set local flag 1 to false;
``` xml
<unsetlocalflag flag="1"  />
```

### SetVar
Copy a local variable to another local variable   
Operands:
```
src  = number of the local variable to copy from
dest = number of the local variable to copy to
```
   
Example- Copy local variable 1 to local variable 2.
``` xml
<setvar src="1" dest="2" />
```

### SetVal
Assign a value to a local variable   
Operands:
```
val  = numeric value to assign to the variable
dest = number of the local variable 
```
   
Example- Assign value 128 to local variable 2.
``` xml
<setval val="128" dest="2" />
```

### AddVar
Add two local variables together and store in a named variable   
Operands:
```
A    = number of the local variable
B    = number of the local variable 
dest = number of the local variable to store the result in
```
   
Example- Add variables 1 & 2 and store in 3.
``` xml
<addvar A="1" B="2" dest="3" />
```
### MinusVar
Subtract two local variables and store in a named variable   
Operands:
```
A    = number of the local variable
B    = number of the local variable 
dest = number of the local variable to store the result in
```
   
Example- A - B -> dest.
``` xml
<addvar A="1" B="2" dest="3" />
```
### MultVar
Multiply two local variables and store in a named variable   
Operands:
```
A    = number of the local variable
B    = number of the local variable 
dest = number of the local variable to store the result in
```
   
Example- A * B -> dest.
``` xml
<multvar A="1" B="2" dest="3" />
```
### DivVar
Divide two local variables and store in a named variable   
Operands:
```
A    = number of the local variable
B    = number of the local variable 
dest = number of the local variable to store the result in
```
   
Example- A / B -> dest.
``` xml
<divvar A="1" B="2" dest="3" />
```

## Advanced Commands
### Condition Block
The condition block has a condition embedded in it.  If the condition passes then it will trigger the commands stored in its "then" block, otherwise it runs the commands in the "else" block.   
Operands:
```
none
```
   
Example- If variables 1 and 2 are equal, then add variables 1 & 2 together and store in 3.  Otherwise multiply variables 1 & 2 and store in 3..
``` xml
   <conditionblock>
      <condition>     
       <equalsvar A="1" B="2"/>       
      </condition>
      <then>
        <addvar A="1" B="2" dest="3"/>
      </then>
      <else>
        <multvar A="1" B="2" dest="3" />
      </else>
    </conditionblock>
 ```
### Return
Ends the currently executing event.  Pops all commands off the execution stack until it pops an EventStart.
Operands:
```
none
```
   
Example- 
``` xml
  <return />
```

### ResumeOnLocalFlagSet
Breaks out of current Event Manager execution cycle unless the specified local flag is set.
Operands:
```
flag - number of the local flag to check
```
   
Example- 
``` xml
  <resumeonlocalflagset flag="1" />
```
### ResumeOnGlobalFlagSet
Breaks out of current Event Manager execution cycle unless the specified global flag is set.
Operands:
```
flag - number of the global flag to check
```
   
Example- 
``` xml
  <resumeonglobalflagset flag="1" />
```
