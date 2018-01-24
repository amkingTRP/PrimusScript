# Primus Script - Base Reference

## Event Manager
The Event Manager object contains one or more events in a list.  
It holds an execution stack of the current command to execute, with a special placeholder command called EventStart to show where
the current event started. 

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
  
