EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)

VAR QuestTestId = "QuestTest"
VAR QuestTestState = "REQUIREMENTS_NOT_MET"

-> test_knot.requirementsNotMet
=== test_knot ===

{QuestTestState :
   - "REQUIREMENTS_NOT_MET": -> requirementsNotMet
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }
   
 = requirementsNotMet
 Youre not meow meow enough yet
 -> END
 
 
 = canStart
 
 Meow? Start quest?
* [Yes]
~ StartQuest("QuestTest")
Yay!

*[No]
 okie nw
- -> END
 
 
 = inProgress
 You're meowing 
 -> END
 
 = canFinish
 You can end the meow
 -> END
 
 = finished
 Meow meow done
 -> END
 
=== PotionStep1 ===


#Belladona 
"Alright, now normally a soul would appear and stare at you with those devoid eyes expecting you to know everything."

#Belladona
"But since you're a baby witch, I'll pretend to be one to get you used to the ropes."

#Belladona 
"So here I am, tragic lost soul, without a voice and desperate - starting to sound like someone I know."

#Belladona
"Uhm, so you see that deck on the counter? DONT TOUCH IT YET."

#Belladona 
"Uhm, let me explain first - that's how we 'talk' to them."

#Belladona 
"The souls can't actually speak - some messy drama behind why they had to remove that ability from them."

#Belladona
"Anyways, we use a 3 tarot spread, flip them over and you get your reading."

#Belladona
"Go on and give it a try."

-> END