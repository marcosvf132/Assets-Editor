# Assets-Editor
Assets Editor is an open-source editor for client 12+.

Requirements:
    Net Core 3.1
	
Features:
    Modifying objects.
    Copy flags between objects.
    Create new objects.
    Creating new sprites sheet, merging sprites, exporting and saving as lzma.
    
    **This program was created by Arch-Mina, this is my edited version of it**

Arch-Mina original repository: https://github.com/Arch-Mina/Assets-Editor

This edited version include all registered creatures that are used on systems like: Bestiary, Prey, Boosted etc.

- To-Do:

- [x]  Monsters (Add images)
- [ ]  Houses (Add images)
- [ ]  Achievments

- Preview:

1.  Main window: (Add new counter 'Monsters' and changed appareances counter (from id to the real objects amount))
![1](https://user-images.githubusercontent.com/66353315/115529402-42263c80-a269-11eb-91b5-687767c8a523.png)

2.  Dat editor window: (Add new button to open the 'Monster' window)
![2](https://user-images.githubusercontent.com/66353315/115530105-da242600-a269-11eb-8499-cb52d2028b5b.png)

3.  New 'Monster' window:
![3](https://user-images.githubusercontent.com/66353315/115530349-10fa3c00-a26a-11eb-9793-24290f438cb1.png)

- Monster window:
   Some informations on the monsters window can change colors when picked, the red highlight means that or this change wont have any effect (for example setting a addon number on a outfit that dont have addons) or if the value is confliction with another list, this last one happens on the ' ID: ' textbox, where the ID set on this place is already being used by another different creature, saving a new creature that have the ID with red colors will overwrite the old monster to the new one. 
	
