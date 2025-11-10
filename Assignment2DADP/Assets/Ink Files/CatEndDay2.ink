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
  "Well...you've done it."
  
  #Belladona
  "Two days in Limbo, and somehow you're still breathing and mostly...intact."
  
  #Belladona
  "I'll have to admit, I wasn't sure you'd last this long."
  
  #Belladona
  "Most indiviudals crumble or turn to insanity with on their first brush with eternity."
  
  #Belladona
  "But, not you."
  
  #Belladona
  "You adapted, you learnt and you overcame every obstacle in your way."
  
  
  #Belladona
  "This earns you something rare down here, my respect."
  
 
 ~StartQuest("CatEndDay2")
  -> END
  
  = inProgress
 
 #Belladona
 "Don't look so shocked. I don't hand out compliments lightly...or at all."
 
 #Belladona
 "You've proven yourself capable... maybe too capable."
 
 
 #Belladona
 "You remember the rival shop across the street?"
 
 #Belladona
 "They don't like competition and definetly not competence."
 
 
 #Belladona
 "The owner lurks - always watching those who might out do them."
 
 #Belladona
 "Your comptence is a double edged sword, baby witch."
 
 #Belladona
 "When people see you can do things they can't - they either worship you or curse you."
 
 #Belladona
 "Sometimes maybe both... speaking from experience."
 
 #Belladona
 "That's how I ended up here. Not everyone gets close to you for the right reasons."
 
 #Belladona
 "Never let your guard down. Brilliance invites attention and with attention comes danger."
 
 #Belladona
 "Now now, don't look that horrified. You've earned your place here but stay sharp."
 
  -> END
  
  = canFinish
 #Belladona
 "So, here's how this is going to work."
 
 #Belladona
 "You stay if you choose to. The shop will be yours to help me run."
 
 #Belladona
 "Of course, there's no going back now. You did sign a contract of eternity."
 
 #Belladona
 "But for what it's worth - you're not trapped, rather anchored down into a steady career."
 
 #Belladona
 "Congratulations apprenctice. You've officially survived my evaluation."
 
 ~FinishQuest("CatEndDay2")
 
  
  -> END
  
  = finished
  
  #Belladona
  "End of trial, start of something new."
  
  #Belladona
  "I suppose this means we're stuck with each other."
  
  #Belladona
  "Don't make me regret it."
  
  
  #Belladona
  "And keep an eye open."
  
  #Belladona
  "Welcome to Limbo, baby witch. For better or worse - you belong here now."
  -> END