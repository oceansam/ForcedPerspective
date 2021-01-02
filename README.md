# ForcedPerspective
Recreating a forced perspective technique

Inspiration
--

I got interested in recreating a similar feature from the game Superliminal. The feature allowed object sizes to change without changing the users perspective of the game object.

![Alt Text](https://cdn.mos.cms.futurecdn.net/G79YhVbCCeEHxBNWLmRUVV.gif)

I took a simpler approach to this as you will see in the demo gif below.

Summary
--
Now of course there is a mathematical explaination for this which is commonly known as "Angular Diameter".
![Alt Text](https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/Angular_dia_formula.JPG/400px-Angular_dia_formula.JPG)

We can see its dependent on both distance and diameter. 


In short, Angular Diameter is a way of describing how an object is viewed at different points of view. In terms of our little demo, to achieve our goal we need to maintain the angular diameter given a change to the distance and size. 

In reality, we just need to proportionally scale the size of the object relative to the distance. 

Creating a weird perspective change. 

The final product can be seen in the gif below.

![Alt Text](https://media.giphy.com/media/VSdNTbp0xcHatNb4BO/giphy.gif)

We can see little to no change in our perspective of the object, however, the size changes drastically.


**Controls:**
--
WASD - Movement

Shift - Sprint

E - Pickup

Q - Drop

G - Activates the perspective change

**Scripts:**
--
FirstPerson_Controller.cs - Movement and Camera controls

FPC_Bob.cs - First person bobbing movement (Was experimenting)

Pickup_Controller.cs - Interactable pickup controls + angular diameter method. 
