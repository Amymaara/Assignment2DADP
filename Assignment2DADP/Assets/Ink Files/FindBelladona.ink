
EXTERNAL LockLook()
EXTERNAL LockMove()
EXTERNAL UnlockLook()
EXTERNAL UnlockMove()
EXTERNAL ShowPopup(type)
EXTERNAL ClosePopup(type)

=== introduction ===

~ LockLook()
~ LockMove()

#???
"Well, well, look who finally decided to wake up."

#???
"Yeah, yeah, you're probably wondering where you are and what you're doing here."

#???
"This is Limbo, lost souls end up here."

#???
"And I have the exclusive pleasure of babysitting or should I say training you."

#???
"Apparently, you're 'useful' and that's why you're here - don't get cocky."


#???
"Now listen up, this place doesn't work like your old world."

#???
"For starters you have to 'will' everything you do."

#???
 "Let's start with something a bit easier, try and 'will' yourself to see."
~ ShowPopup("look")
~ UnlockLook()
#???
"I'm asking you to look around you, how hard is that to get?"
~ ClosePopup("look")

#???
"I'm impressed, you actually managed to do it. How about something a bit more challenging, let's try and moving without your fancy little legs."
~ ShowPopup("movement")
~ UnlockMove()

#???
"Well go on try it."

~ ClosePopup("movement")

#???
"Wonderful you can see my cozy little space surrounded by the vast nothingness I get to enjoy everyday."

#???
"Listen carefully, your willpower is all you got around here. Don't forget it."

#???
"Now why don't you come over here so we can get to work, I ain't wasting one of my lives waiting for you to gawk at everything."


-> END
