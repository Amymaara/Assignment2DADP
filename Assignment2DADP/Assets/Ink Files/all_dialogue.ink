EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)
EXTERNAL ShowPopup(type)
EXTERNAL ClosePopup(type)
EXTERNAL TeleportCat(target)
EXTERNAL TeleportCat2(target)
EXTERNAL StartDay()


INCLUDE FindBelladona.ink
INCLUDE RuneCatNPC.ink
INCLUDE CrystalCatNPC.ink
INCLUDE TarotCatNPC.ink
INCLUDE PotionCatNPC.ink
INCLUDE CatStartDay1.ink
INCLUDE CatEndDay1.ink
INCLUDE Day1Wakeup.ink
INCLUDE Day2Wakeup.ink
INCLUDE CatStartDay2.ink
INCLUDE CatEndDay2.ink


VAR QuestTestId = "QuestTest"
VAR QuestTestState = "REQUIREMENTS_NOT_MET"

VAR ExploreQuestId = "ExporeQuest"
VAR ExploreQuestState = "CAN_START"

// tutorial quests
VAR RuneCatNPCId = "RuneCatNPC"
VAR RuneCatNPCState = "REQUIREMENTS_NOT_MET"
VAR CrystalCatNPCId = "CrystalCatNPC"
VAR CrystalCatNPCState = "REQUIREMENTS_NOT_MET"
VAR TarotCatNPCId = "TarotCatNPC"
VAR TarotCatNPCState = "CAN_START"
VAR PotionCatNPCId = "PotionCatNPC"
VAR PotionCatNPCState = "REQUIREMENTS_NOT_MET"

// day 1 quests
VAR CatStartDay1State = "CAN_START"
VAR CatStartDay1Id = "CatStartDay1"
VAR CatEndDay1State = "CAN_START"
VAR CatEndDay1Id = "CatEndDay1"
VAR CatStartDay2State = "CAN_START"
VAR CatStartDay2Id = "CatStartDay2"
VAR CatEndDay2State = "CAN_START"
VAR CatEndDay2Id = "CatEndDay2"

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
 


=== ExploreQuest ===
{ExploreQuestState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
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
"We have other recipes if you want to figure them out on your own."

#Belladona
"Help you? Sweetheart this isn't magic school anymore - learn it for yourself."

#Belladona
"Go on then, go try things out - I need my naptime, i've been ever so tired since becoming...this."

-> END

= canFinish

#Belladona
"Explore around now, come on."
~ FinishQuest("ExploreQuest")
-> END
= finished

#Belladona
"We'll start our first real day tomorrow, be prepared."

-> END