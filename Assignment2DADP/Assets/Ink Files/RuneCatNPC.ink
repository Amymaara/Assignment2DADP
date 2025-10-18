

=== RuneCatNPC ===

{RuneCatNPCState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }

= canStart
You can make a rune
~StartQuest("RuneCatNPC")

-> END

= inProgress
I believe
-> END

= canFinish
Oh look a rune
-> END

= finished
Nice
-> END