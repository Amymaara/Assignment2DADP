

=== TarotCatNPC ===

{TarotCatNPCState :
   - "CAN_START" : -> canStart
   - "IN_PROGRESS": -> inProgress
   - "CAN_FINISH": -> canFinish
   - "FINISHED": -> finished
   - else: -> END
   }

= canStart
#Belladona
"Took you long enough."

#???
"Stop gawking will you."

#???
"Sigh, fine - let's get this over with."

#???
"Yes, I'm a cat."

#???
"No I wasn't born this way."

#???
"No, I will not explain further."


#???
"Well I guess introductions are important to mortals, so i shall oblige."

#Belladona
"The name's Belladona, owner of this quaint little shop and the only reason your soul isn't disintegrating right now."

#Belladona
"Let's get straight to business shall we?"

#Belladona
"Right, first lesson - the Tarot Service. Try not to embarrass yourself."

#Belladona 
"Alright, now normally a soul would appear and stare at you with those devoid eyes expecting you to know everything."

#Belladona
"But since you're a baby witch, I'll pretend to be one to get you used to the ropes."

#Belladona 
"So here I am, tragic lost soul, without a voice and desperate - starting to sound like someone I know."

#Belladona
"Uhm, so you see that deck on the counter?"

#Belladona 
"Yeah that one, click it - that's how we 'talk' to them."

#Belladona 
"The souls can't actually speak - some messy drama behind why they had to remove that ability from them."

#Belladona
"You’ll pull three cards. Each tells part of a story - who they were, what they want, and how they ended up here."

#Belladona
"And no, it’s not fortune telling -  we prefer the term spiritual customer service."

#Belladona
"Once you’ve done your little reading, you'll get a recipe for what you need to make.

#Belladona
"It's quite easy, follow the recipe and hand it in to the customer."

#Belladona
"Hairball and hexes, it is NOT like a fast food restuarant how dare you say that."

#Belladona
"Sigh, go on and give it a try before you dissapoint me further."

~ StartQuest("TarotCatNPC")

-> END
= inProgress

#Belladona
"Go on then, flip the cards and use what little intuition you’ve got. It’s not that hard."

-> END
= canFinish

#Belladona
"Not too shabby, maybe you are 'useful'."
~ FinishQuest("TarotCatNPC")
-> END
= finished

#Belladona
"Don't celebrate yet baby witch, let's try actually making something first."

#Belladona
"Meet me in the potion room and we'll give you a go at that."
~ TeleportCat("Potion")

-> END
