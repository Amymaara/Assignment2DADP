
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
  
  #Belladona
  "You managed to survive orientation, so i'm at least a little bit hopeful you'll do better than your predecessor."
  
  #Belladona
  "But don't get too cocky, Today is the real work."
  
  #Belladona
  "Remember if you mess up, don't bother asking me for help. I like watching my underlings learn the harrd way."
  
  #Belladona
  
 "Alright, let's get this going."
  
  ~ StartQuest("CatStartDay1")
 
  -> END
  
  = inProgress
  
   #Belladona
  "Places, apprentice. They're about to arrive."
  
  #Belladona
  "The veils are thinning, which means our customers will soon be here."
  
  #Belladona
  "Remember - always start with a tarot reading."
  
  ~FinishQuest("CatStartDay1")
  -> END
  
  = finished
  #Belladona
  "Meet me in the bedroom once you're done, we have much to discuss."
  
  #Belladona
  "Now let's open for business."
  
   ~ TeleportCat2("End")
   ~ StartDay()
  -> END