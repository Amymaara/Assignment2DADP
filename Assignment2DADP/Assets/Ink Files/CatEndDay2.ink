=== CatEndDay2 ===

{CatEndDay2State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  #Belladona
  can start
  -> END
  
  = inProgress
  in progress
  -> END
  
  = canFinish
  can finish 
  
  -> END
  
  = finished
  finished
  -> END