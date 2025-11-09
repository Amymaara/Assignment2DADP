

=== CatEndDay1 ===

{CatEndDay1State :
   - "REQUIREMENTS_NOT_MET" : -> requirementsNotMet
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = requirementsNotMet
   
   -> END
  = canStart
  
  -> END
  
  = inProgress
  
  -> END
  
  = canFinish
  
  
  -> END
  
  = finished
  
  -> END