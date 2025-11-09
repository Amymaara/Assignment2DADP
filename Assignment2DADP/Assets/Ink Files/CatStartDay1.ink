
=== CatStartDay1 ===

{CatStartDay1State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS" : -> inProgress
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  
  #Belladona
  "I'll take it as you're ready for your first shift."
  
  ~ StartQuest("CatStartDay1")
 
  -> END
  
  = inProgress
  
   #Belladona
  "Places, apprentice. They're about to arrive."
  
  #Belladona
  "Your first customer is about to arrive, I'll leave you to it."
  
  ~FinishQuest("CatStartDay1")
  -> END
  
  = finished
  #Belladona
  "Meet me in the room once you're done, we have much to discuss."
   ~ TeleportCat2("End")
   ~ StartDay()
  -> END