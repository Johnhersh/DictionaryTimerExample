# DictionaryTimerExample
This example fails quietly

In TaskingManager.StartTimer() it calls FinishUpgradeTask.Execute() with "Upgrade2" which doesn't exist in the dictionary and it just hangs forever.

If that input is changed to "Upgrade1" which does exist, then the console will output the Upgrade1 message on a loop.
