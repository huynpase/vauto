## Loops Support ##
> Framework takes into account, to bring minimal coding complexity for the script writers. However, the same time, framework do realizes that there can be scenarios where script writer has to go beyond the plain logic. To help scripting of more complex logic, the framework provides all the basic looping blocks.
  * ### For Loop ###
> > When you are sure of the count of the iterations, you can use 'for' loop.
> > > <b>Syntax</b>:
```
      <for count="{count goes here}">
        <body>
           {All instruction in this block will be iterated for given count}
        </body>
      </for>
```
<br />
> > > <b><a href='http://code.google.com/p/vauto/wiki/ExampleImageCollection'>Example</a></b>
  * ### While Loop ###

> > When you are not sure of the count of the iterations, or you want to make the iteration until certain condition fails, you will be using 'while' loop.
> > > <b>Syntax</b>:
```
       <while>
        <condition>
          {check condition}
        </condition>
        <body>
           {All instruction in this block will be iterated until the condition becomes false}
        </body>
      </while>
```
<br />
> > > <b>Example</b>
  * ### Do-While Loop ###

> > When you are not sure of the count of the iterations, or you want to make the iteration until certain condition fails, you can also use 'dowhile' loop. However the major difference in _while_ and _dowhile_ is: unlike while, dowhile first executes the body section and then checks the condition. i.e. In any case the body section of dowhile will get executed once even though the condition fails initially.
> > > <b>Syntax</b>:
```
       <dowhile>
        <body>
          {All instruction in this block will be iterated until the condition becomes false}
        </body>
        <condition>
          {check condition}
        </condition>
      </dowhile>
```
<br />
> > > <b>Example</b>