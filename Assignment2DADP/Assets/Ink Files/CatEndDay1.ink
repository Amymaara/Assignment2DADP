

=== CatEndDay1 ===

{CatEndDay1State :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }
   
  = canStart
  #Belladona
  "Well, well look who survived their first shift."
  
  #Belladona
  "Colour me surprised, I did expect the worst."
  
  #Belladona
  "I might have to call and cancel the spectral attorney."
  
  #Belladona
  "You're made it through your first full day in Limbo."
  
  #Belladona
  "How did you do?"
  
  #Belladona
  "I guess I could say i'm a bit proud."
  
  #Belladona
  "But don't let it get to your head
  
  #Belladona
  "There was a few mistakes you need to correct."
  
  ~StartQuest("CatEndDay1")
  
  -> END
  
  = inProgress
  
  #Belladona
  "You knowm seeing you blunder your way through this reminds me of when I first started out."
  
  #Belladona
  "I wasn't born like this, you know. I had hands - elegant, powerful and moisturised hands."
  
  #Belladona
  "You really need to take better care of your skin. You don't need to live up to the stigma's and depictions of witches..."
  
  #Belladona
  "But yeah, I got a little too good at what I was doing. Competitiors tend to get...jealous."
  
  #Belladona
  "Anyway, enough sentimentality. I've gone soft - purely your fault by the way."
 ~ AdvanceQuest("CatEndDay1")
  -> END
  
  = canFinish
 #Belladona
 "Hm, I suppose you've earned the right to see it to day two."
 
 #Belladona
 "You can practise and explore around if you want."
 
 #Belladona
 "But there's not much to do here."
 
 #Belladona
"Get to bed when you're ready and when you're up we'll start you on your second day."

#Belladona 
"I'll see you in the morning - if you ever wake up. I swear at times I think you've reached eternal rest."

~FinishQuest("CatEndDay1")
  
  -> END
  
  = finished

#Belladona
"Now shoo, get to bed or something - just don't bother me."

  -> END