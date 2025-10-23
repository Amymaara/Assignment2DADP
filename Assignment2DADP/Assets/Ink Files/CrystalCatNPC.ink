

=== CrystalCatNPC ===

{CrystalCatNPCState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }

= canStart

#Belladona
"Ah finally, crystals."

#Belladona
"What? You like them because they're shiny?"

#Belladona
"...Are you part crow?"

#Belladona
"I swear if they accidentally send me another familiar turned human...oh? You're not part crow?"

#Belladona
"Intersting... I question you then."

#Belladona
"Anyways, crystals store memories and recharges you. Think of them like emotional batteries."

#Belladona
"Well, there's not much to say - it's pretty self explanatory."

#Belladona
"You still want the steps? Never heard of learning on the job?"

#Belladona
"Fine, here we go."

#Belladona
"Step 1: place the tumble crystals on the ouside pillars and the tower in the middle."

#Belladona
"Step 2: Attune the crystals."

#Belladona
"Well you can probably guess what to do next."

#Belladona
"Correct - do a reading and make the order."
~ StartQuest("CrystalCatNPC")

-> END

= inProgress

#Belladona
"Do you lose focus that quickly? Stop bothering me and get me my Cleansing Crystal."

-> END

= canFinish

#Belladona
"I'll give it to you witchling - not half bad."
~ FinishQuest("CrystalCatNPC")
-> END

= finished

#Belladona
"(Yawwn) Well look at that - it's time for my nap."

#Belladona
"You'll find me where we first met."
~TeleportCat("Table")

-> END