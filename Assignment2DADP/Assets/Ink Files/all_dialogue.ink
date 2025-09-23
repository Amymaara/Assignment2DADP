EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)

VAR QuestTestId = "QuestTest"
VAR QuestTestState = "REQUIREMENTS_NOT_MET"
VAR TarotQuestId = "TarotQuest"
VAR TarotQuestState = "CAN_START"
VAR PotionQuestId = "PotionQuest"
VAR PotionQuestState = "CAN_START"
VAR ExploreQuestId = "ExporeQuest"
VAR ExploreQuestState = "CAN_START"

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
{TarotQuestState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - else: -> END
   }

= canStart
#Belladona
"There's no time for explanations, we need to get you trained, and quickly at that."

#Belladona 
"Alright, now normally a soul would appear and stare at you with those devoid eyes expecting you to know everything."

#Belladona
"But since you're a baby witch, I'll pretend to be one to get you used to the ropes."

#Belladona 
"So here I am, a tragic lost soul, without a voice and desperate - starting to sound like someone I know."

#Belladona
"Uhm, so you see that deck on the counter? DONT TOUCH IT YET."

#Belladona 
"Let me explain first - that's how we 'talk' to them."

#Belladona 
"The souls can't actually speak - some messy drama behind why they had to remove that ability from them."

#Belladona
"Anyways, we use a 3 tarot spread, flip them over and you get your reading."

#Belladona
"Go on and give it a try."
~StartQuest("TarotQuest")

-> END

= inProgress
#Belladona
"Just use the deck on the counter to get a reading, I'll meet you at our next station once you've got it."
-> END

= canFinish
#Belladona
"Come find me after you're done"
-> END

=== PotionQuest ===
{PotionQuestState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - else: -> END
   }
 
 = canStart
 #Belladona
 "Where did I go?"
 
 #Belladona
 "Hmph, I can do at least this much magically even with my ...condition."
 
 #Belladona
 "Enough chit chat, let's get straight into business."
 
 #Belladona
 "Now this is one of the services we offer, our most complex and skill heavy task."
 
 #Belladona
 "Potion making."
 
 #Belladona
 "I believe in learning on the job, use your senses to make a potion."
 
 #Belladona
 "Hmm, a knowledge potion would do, just follow the recipe - it's easy enough."
 
 #Belladona
 "Also...don't be alarmed at any "paranormal" activity - the spirits are 
mischievous here"
 
 ~StartQuest("PotionQuest")
  -> END
 
 = inProgress
 #Belladone
 "I said serve me a KNOWLEDGE potion. Honestly... what did I expect?"
 
 #Belladona
 "Well get on, and find me once you're done - I don't like sitting around in one place."
 
  -> END
 
 =canFinish
 #Belladona
 "I guess this passes..."
 -> END

=== ExploreQuest ===
{ExploreQuestState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - else: -> END
   }

= canStart

#Belladona
"Hmm, your attempt is satisfactory at best."

#Belladona
"Look, I'm gonna be honest with you."

#Belladona
"Life in Limbo is precious and fleeting - our job here is to service the souls who come."

#Belladona
"Help them move on, find peace."

#Belladona
"Anything less than perfect will not be tolerated, we don't accept mistakes and neither do they."

#Belladona
"So focus up and try to learn the ropes around here."
~ StartQuest("ExploreQuest")

-> END

= inProgress

#Belladona
"Don't stand there idly - find something to do."

#Belladona
"We have other stations if you want to figure them out on your own."

#Belladona
"Help you? Sweetheart this isn't magic school anymore - learn it for yourself."

#Belladona
"Go on then, go try things out - I need my naptime, i've been ever so tired since becoming...this."

-> END

= canFinish

#Belladona
"Explore around now, come on."

-> END