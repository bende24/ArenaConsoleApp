# Whats the app about

## Description
N number of heroes are fighting in an arena. The heroes can be Archers, Knights and Swordsmen.<br/> 
Every hero has an ID and Health points as well as they can attack and defend as described below.<br/> 

Archer attacks
  - Knight: 40% chance the knight dies, 60% chance it blocks
  - Swordsman: Swordsman dies
  - Archer: Defender dies

Swordsman attacks:
  - Knight: Nothing happens
  - Swordsman: Defender dies
  - Archer: Archer dies

Knight attacks:
  - Knight: Defender dies
  - Swordsman: Knight dies
  - Archer: Archer dies

The combat is turn based. In every round an attacker and a defender are randomly selected.
Everyone else rests and their health will increase by 10, but it cant go over their max health.<br/> 

The combat participants (attacker, defender) health will be halved. If its smaller than the quarter of ther starting health they die.<br/> 
Starting healths: Archer 100, Knight 150, Swordsman 120.<br/> 

Before the fight in the arena starts you have to generate N number of random heroes. You will get this number as an input parameter.<br/> 
The combat ends when there is a maximum of 1 hero standing.<br/> 

After every round you also have to log who attacked who and how their healths changed.

# Design choices

## Combat
The reason the combat system was designed in a functional way <code>Fight(archer, knight)</code>, 
instead of using a more object oriented approach like <code>archer.Fight(knight)</code>.
Is because this part of the application is very volatile / prone to change.
New heroes can be added and with that all of the existing heroes must be updated as well.  <br/>
For example if a new Viking hero would be added, then not only **it must be able to attack every other hero, but also every other hero must attack it as well.** <br/>
And with <code>archer.Fight(knight)</code> these combat rules wont be separated into one place, which can result in forgetting to update a combination (human error).
<br/>
<br/>
However separating every attack combination into one place, like the solution, 
will result in that ***developers won't forget to update all of the existing heroes as well.***<br/>
This way ***the data and complex domain behaviour remains separated as well***, and <code>Hero</code> classes won't have to depend on anything.
