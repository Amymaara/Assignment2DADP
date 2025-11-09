
=== CatStartDay1 ===

{CatStartDay1State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  
  #Belladona
  "I'll take it as you're ready for your first shift."
  
  ~ StartQuest("CatStartDay1")
  ~ StartDay()
  -> END
  
   #Belladona
  "Places, apprentice. They're about to arrive."
  = inProgress
  
  -> END
  
  = canFinish
  
  #Belladona
  "I guess you managed to keep up"
  
  ~FinishQuest("CatStartDay1")
  -> END
  
  = finished
  #Belladona
  "Meet me in the room, we have much to discuss."
  -> END