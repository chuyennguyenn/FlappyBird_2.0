# FlappyBird_2.0

A replication of one of the most well-known hyper-casual games: Flappy Bird.

# What's news

1. There are 3 single-gap pipes: Easy, Mid, and Hard. The difference between them is the width of the gap between the upper and lower pipe.
  
   Additionally, there is a Special pipe type with 2 gaps instead of 1.
   
2. Difficulty: The game becomes more difficult over time, reaching maximum difficulty after 2 minutes:

   ### Pipes spawn chance

   When a pipe spawns, there is a 25% chance it will be Special, and a 75% chance it will be a Common pipe.

   For Common pipes, the spawn chances are as follows:

   - Easy: 65% -> 0%, combine with 75% chance to spawn a Common, result in 48.75% -> 0%
   
   - Mid: 25% -> 50%, combine with 75% chance to spawn a Common, result in 18.75% -> 37.5%  

   - Hard: 10% -> 50%, combine with 75% chance to spawn a Common, result in	7.5% -> 37.5%

   ### Gravity and Fly-Height

   Both Fly Height (how high the bird jumps on tap) and gravity (how fast the bird falls) increase over time, reaching their maximum values after 2 minutes.

   # How to run

   Download the zip file, extract to desired folder and run the .exe file

   # Todo

   - Add collectible (shield - give immunity, star - give extra point...)
   - Add ability(really???) to the bird + more playable character

   
