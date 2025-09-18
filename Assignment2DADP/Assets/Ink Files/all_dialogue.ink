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
 
