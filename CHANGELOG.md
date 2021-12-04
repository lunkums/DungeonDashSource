# Change Log

Includes significant additions made to the source code of Dungeon Dash
(name subject to change) and some of the software models used to build
the game.

## [December '21 Update] : 2021/12/03

Features

  - Cleaned up the State class to correctly implement generics
  - Added a dust cloud when the player jumps
  - Added a letterbox for narrow aspect ratios
  - (Actual) pixel perfect camera
  - Added the base for projectiles
  - Added fall through for Player on floating platforms
  - Resized all sprites and changed PPU for more accurate 2D collisions (thanks Unity :D)
  - Object Pooling ( = better performance)
  - Added cached States to reduce Entity overhead
  - Began implementing procedural generation (emphasis on began...)
  - Improved grounded functionality (as well as a grounded buffer for the Player)

Models

  - GENERICS for State class
  - PARTICLE SYSTEM for dust cloud
  - QUEUE for OBJECT POOLING
  - CONTACT FILTER for grounded condition

## [September '21 Update] : 2021/09/02

Features

  - (Dev) Better multiscene editing with a dependent components scripts
  - Variable jump height
  - Smart wolf AI (jumps over pits while chasing the player)
  - Score counter (only works with distance, no points for combat yet)
  - Player sprite flickers instead of flashes during recovery phase

Models

  - RAYCASTING used for wolf AI


## [August '21 Update] : 2021/08/02

Features

  - Input including input queueing
  - Movement
  - Animated states with fluid transitions
  - Bat and Wolf enemies
  - Basic level generator
  - Health pickup
  - Basic health UI
  - Pause menu
  - Sound manager with adjustable audio levels

Models

  - STATE PATTERN used for player and enemies
  - STACK MODEL used for pause/options menu
  - C# EVENTS used to segregate behaviour between unrelated scripts such as
  health bar UI and screen shake
  - MATH used to model the movement and positioning of the Bat enemy
  - INHERITANCE and ABSTRACTION used to simplify the usability of shared
  tasks such as the Entity class which defines the basic components of an
  Entity (player and enemy).
