
=== PotionCatNPC ===
{PotionCatNPCState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED" : -> finished
   - else: -> END
   }
 
 = canStart
 #Belladona
 "How did I get here?"
 
 #Belladona
 "Hmph, I can do at least this much magically even with my ...condition."
 
 #Belladona
 "Enough chit chat, let's get straight into business."
 
 #Belladona
 "Now this is one of the services we offer, our most complex and skill heavy task."
 
 #Belladona
 "Potion making."
 
 #Belladona
"Every potion we make here is a service - think of it as ... emotional trauma cocktails."

#Belladona
"Why are you staring at me like? Did you not get the joke?"

#Belladona
"Whatever, potion making is a 3 step process."

#Belladona
"Step 1: Find the ingredients and fill the cauldron."

#Belladona
"Step 2: Mix everything."

#Belladona
"Step 3: Bottle."

#Belladona
"Quite simple no? Try making me a knowledge potion."

#Belladona
"Use the tarot deck next to me to get the recipe ... just don't be nosy about my readings."
~ StartQuest("PotionCatNPC")

  -> END
 
 = inProgress
 #Belladone
 "The potion won't brew itself you know? Get started for heavens sake, it's just a Knowledge Potion."
 
 #Belladona
 "Well get on, and find me once you're done - I don't like sitting around in one place."
 
  -> END
 
 =canFinish
 #Belladona
"Well, you managed to do it. That's progress."
~ FinishQuest("PotionCatNPC")
 -> END
 
 = finished 
 
 #Belladona
 "Meet me at the next station - the rune room."
 ~ TeleportCat("Rune")
 
 -> END