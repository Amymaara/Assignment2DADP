=== CatStartDay2 ===

{CatStartDay2State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS" : -> inProgress
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  
can start
  
  ~ StartQuest("CatStartDay2")
 
  -> END
  
  = inProgress
  
in progress
  
  ~FinishQuest("CatStartDay2")
  -> END
  
  = finished
  #Belladona
finished
   ~ TeleportCat2("End")
   ~ StartDay()
  -> END