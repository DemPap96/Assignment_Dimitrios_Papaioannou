# Assignment_Dimitrios_Papaioannou
Unity Dev Challenge - TrueMyth Games

Main Scene:

  This is the starting scene of the app. I 've used a canvas with a panel to display everything the player will see. With the help of the build-in UI tools like Text Mesh Pro and the ui buttons I show all the relevant information on the screen. The top score is saved under a PlayerPref named TopScore and it is checked every time this scene is loaded which is when the app starts or when a game ends. 
  The start game button moves the player to the next scene where the game is played. I used simple code because there are not many scenes in this project so I moved between scenes using the buildIndex value. 

Game Scene:

  Once the game scene is loaded the first thing that runs is the LoadData script which reads the DataConfiguration.txt file and splits the file into colours and points. The program does some minor checks like to see if the points are Integers or that the colour value starts with lowercase. If any of the data is wrong the program stops and displays on console the correct format that should be used in the .txt file. The data of the .txt file are loaded in two different public lists and can be accessed by the other objects on the scene.
  
 For the floor and the walls, I used simple 3D cubes that I stretched out in the size that seemed appropriate and activate the isTrigger value for the walls in the Box Collider component. 
 
 The SnakeHead is the most important part of the project. Attached to it is the MoveHead script which is the brains of the whole game. The first thing you will see is that the sphere collider of the head is smaller than the radius of the sphere. I did this because I wanted to give the "snake" more of a caterpillar appearance and that needed the tail parts to be closer together. If the collider was the same size as the sphere the game will instantly game over because the head would touch the tail. On the other hand, to counter the smaller collider I set up a bigger collider for the food components that appear on the screen so that the player will not see the difference.
 
 Also I created two new prefabs one for the foods and one for the tail parts. The food prefab when is created serchees the scene for the LoadGame Object that is attached to the LoadData script and accuires a random colour and its points. Afterwards I change the material colour of the food. You will also see in the Update function there is a rotation change. I did this because I wanted some movement in the other parts of the map where the snake is heading to, my goal was to make the game a little less monotone. 
 For the tail part prefab there is no specific script because all the calculations are happening in the MoveHead script which I will explain below.
 
 As I said above the MoveHead script is the brain of the game. It takes a lot of inputs that are explained in the script itself and its whole purpose is to move all the snake parts, head and tail, change the points and call when a new food should be spawned. The whole idea of the snake movement is for the snake to move always forward and never stops until it loses. What it is changing is the rotation of the head and that is what gives the snake direction. Using The LeftArrow and RightArrow keys the player can change the rotation of the head and make the snake turn where the player wants. Additionally, every position that the head passed it is saved in a list of vector3, the program will then use this list to make every tail part to move to the next position so that there is smooth movement between head and tail parts.
 
 When the head of the snake collides with something the tag is checked. If it collided with a food then the program checks the colour of the food and compares it with the colour of the previous food that was hit. If it is the same then the current streak will go up by one and the correct number of points will be added to the total. If the colour was different the streak ends and it is set up to 1 and again the correct points are added to the total. Afterward the food that was hit it is destroyed; a new tail part and a new food are spawned.

If it collided with a wall or a tail part the there is a game over popup that appears. Again, with the use of a panel and a canvas the game shows the player the information they need to know. That the game is over and how many points they have scored. After clicking the ok button, they are redirected to the Main Scene and the game checks if the achieved score is the new high score. If it is the player prefs are changed and the new high score will now be displayed on the main scene. 

Video Link: 
https://drive.google.com/file/d/1e-x-HoVRmbLHSeHx3T6VJ6kjMFBax1Tw/view?usp=sharing
This is the game; it was a very fun project and I enjoy my time making it.
