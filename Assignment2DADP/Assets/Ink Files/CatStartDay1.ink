
=== CatStartDay1 ===

{CatStartDay1State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  
  -> END
  
  = inProgress
  
  -> END
  
  = canFinish
  
  -> END
  
  = finished
  
  -> END