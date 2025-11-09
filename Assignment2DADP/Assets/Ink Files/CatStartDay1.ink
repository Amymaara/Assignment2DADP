
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
  
  #Belladona
  "Places, apprentice. They're about to arrive."
  
  ~ StartDay()
  -> END
  
  = inProgress
  
  -> END
  
  = canFinish
  
  -> END
  
  = finished
  
  -> END