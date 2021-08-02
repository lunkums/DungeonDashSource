# Change Log

Includes significant additions made to the source code of Dungeon Dash
(name subject to change) and some of the software models used to build
the game.

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
