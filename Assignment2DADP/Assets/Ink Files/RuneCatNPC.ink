

=== RuneCatNPC ===

{RuneCatNPCState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }

= canStart

#Belladona
"Now that you've somewhat mastered the art of not blowing yourself up, let's look at something more refined - rune carving."

#Belladona
"Runes are from the old days, magic almost as old as Limbo itself."

#Belladona
"Runes have the ability to repair, seal and channel energy - something all souls crave."

#Belladona
"Alright i'll tell you the steps, listen carefully"

#Belladona
"Step 1: choose the correct material and bring it to the workstation."

#Belladona
"Step 2: choose the correct shape."

#Belladona
"Step 3: carve it."

#Belladona
"It take some precision but isn't anything too difficult."

#Belladona
"Well go on, do a reading and bring me a rune."

~ StartQuest("RuneCatNPC")

-> END

= inProgress

#Belladona
"What? Are you expecting encouragement. Just hand me my Protection Rune already."

-> END

= canFinish

#Belladona
"Your linework isn't as dreadful as I thought, I guess this could be considered a pass."
~ FinishQuest ("RuneCatNPC")
-> END

= finished

"Well come on now, we have 1 station left - meet me at the crystal room."
~ TeleportCat("Crystal")
-> END