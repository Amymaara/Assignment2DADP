=== CatStartDay2 ===

{CatStartDay2State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS" : -> inProgress
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  
#Belladona
"Morning, baby witch. Or whatever passes for morning here."

#Belladona
"You really do sleep like a corpse."

#Belladona
"Yesterday was about surviving, today is about being competent."

#Belladona
"Impress me and you might just earn a permanent position here."

#Belladona
"What benefits do we have?"

#Belladona
"Where do you think we are? Dental? Vacation days?"

#Belladona
"You're lucky i'm keeping your soul intact."

#Bellaodna
"I'll be watching you more earnestly today."

#Belladona
"Try and not disappoint me."

  
  ~ StartQuest("CatStartDay2")
 
  -> END
  
  = inProgress
  
#Belladona
"Look alive, the veil is changing."

#Bellaodna
"You'll have a greater workload today."

#Belladona
"You already know the drill by now - do the tarot, get the order and make it."

#Bellaodna
"Well, i'll be leaving you to it apprentice."
  
  ~FinishQuest("CatStartDay2")
  -> END
  
  = finished
  #Belladona
"Let's see if you've got what it takes to survive eternity in my service."

   ~ TeleportCat2("End")
   ~ StartDay()
  -> END