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
