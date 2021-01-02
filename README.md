# ForcedPerspective
Recreating a forced perspective technique

I got interested in recreating a similar feature from the game Superliminal. The feature allowed object sizes to change without changing the users perspective of the game object.

Now of course there is a mathematical explaination for this which is commonly known as "Angular Diameter".
![Alt Text](https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/Angular_dia_formula.JPG/400px-Angular_dia_formula.JPG)

We can see its dependent on both distance and diameter. 

In short, Angular Diameter is a way of describing how an object is viewed at different points of view. Relating back to this little demo, to achieve our goal we need to maintain the angular diameter given a change to the distance and size. 

In reality, we just need to proportionally scale the size of the object relative to the distance. 

Creating a weird perspective change. 

The final product can be seen in the gif below.

![Alt Text](https://media.giphy.com/media/VSdNTbp0xcHatNb4BO/giphy.gif)
