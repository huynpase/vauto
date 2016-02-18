## Data driven architecture ##

### Distributed Test Components ###
To improve the scalability and reduce the maintenance cost, the Vibzworld Automation framework supports distributed data layer architecture. This means the actual logic, the input data, and the application identifiers can stay segregated during the whole development phase of automation. This approach brings inherent advantage.
<br />
Consider your web application goes into a minor change with control repositioning or just id change. To reflect this in your automation script, your just need to open up the corresponding identifier file and make the appropriate changes. The logic part remains untouched. On a contrary note, if there is a major change in functional aspect of the test flow, you will update the logic portion. The point of consideration is that there is less chance of errors that could have come when you change the script that has intermixed layers.<br /><br />
You may be interested in knowing the [components of a test script](http://code.google.com/p/vauto/wiki/ComponentsOfTestscript).
### Modular approach for scripting ###
The test scripts can be maintained into smallest functional unit and there after can be invoked from any other test case that defines similar functionality within it.
In case of a minor change in one test functionality, the script writer has to change at one place and the same will be reflected else where. <br /> With this framework facilitates <b>re-usability</b> of code and <b>easy of maintenance</b>.<br />
Further with modular structure it becomes easy enough to control the flow of a big scenario. The framework provides the feasibility of controlling the fate of functional flow by defining whether the script should continue to flow or break with failure message.