## Scheduling Automation Script ##
### Need for scheduling ###
After you have automated your process, you have to invoke the process by clicking on run button or through command line execution. If this is a periodic task you may need to schedule the execution, in order to completely remove any human interference.
### Scheduling mechanism through Vibz framework ###
The framework has gone a step ahead to provide a facility to schedule your script execution at some regular interval or on some criteria fulfillment. This is useful in case of running a bot to crawl a site or starting a test process when a new build arrives. Further you may want to mask the execution of your script to some period of day, week etc. Similarly there can be various business requirement for scheduling your execution. Vibz Scheduler is designed keeping in view of extending the scheduling mere by adding a new scheduling plug-in to the framework. This is yet another open end where the framework can be extended to provide your own custom scheduling. One can have as many scheduled event running in parallel.

http://vauto.googlecode.com/files/SchedulerSettings.JPG

_Note: Vibz Scheduler is not just confined to Vibz Script but can be used to schedule any executable like **.exe,**.bat or applications that can be invoked using command prompt._
### How to schedule a script ###
Vibz Automation Studio and Vibz automation framework both comes with Automation scheduler. On installing either of these software you will see scheduler under **Start -> All Programs -> Vibzworld -> Automate Scheduler**. There are three ways by which you can schedule your script.
  1. **Using Automation Scheduler**
    1. Open Automation Scheduler from Desktop Start menu.
    1. On the scheduler window you will see three tabs. Go to **Schedule Settings** tab.
    1. In the lower panel you will have new task option. Click on the **browse** button.
    1. In the **Open** file dialog box navigate to your compiled script (vacs) file.
    1. Click on **Add Task** button. This will add the schedule task in the Running task list.
    1. In the right panel, update the schedule settings.
    1. Vibz utility ideally comes with three types of Schedule mechanism.
      * **Periodic:** Select this option when you want to execute the script periodically after regularly interval of time.
      * **PeriodicMask:** Select this option when you have periodic execution but to some part of duration you do not want to the execution to happen. Example: For Stock Market Crawler you may not want to execute your script during Weekends.
      * **OneTime:** Select this option when you need your script to be executed only once on a particular date-time. After the execution the task will automatically get removed from the task list.
    1. On selecting a Schedule type settings specific to the selected type will be available. Change the settings as per the requirement.
_Note: Scheduling can be extended to include additional schedule type by writing a new [plug-in](SchedulePlugin.md)._
  1. **Using Automation Studio**
    1. Open Automation studio. **Start -> All Programs -> Vibzworld -> Automate**.
    1. From the **file** menu (top) of the Studio click on **Open Project** option.
    1. Navigate to Solution folder of the script that is to be scheduled and select the project file to open.
    1. In the Solution explorer, right click on the suite file. This will open the context menu.
    1. Click on **Schedule** option in the context menu. This will open up the Automation Schedule window with selected task already being added.
    1. Follow the steps as discussed above to edit the settings for the added schedule task.
  1. **From windows explorer**
    1. Open Windows explorer window and navigate to Compiled script (VACS) file that is to be scheduled.
    1. Right click on the VACS file. This will open the context menu.
    1. Click on **Schedule** option in the context menu. This will open up the Automation Schedule window with selected task already being added.
    1. Follow the steps as discussed above to edit the settings for the added schedule task.
### Suspending scheduler process ###
The execution of task is being controlled be Windows scheduler service. One can start and stop the service from Vibz Scheduler window. To start or suspend the service do following step:
  1. Open the Vibz scheduler window.
  1. Navigate to Service Settings.
  1. At the top you will have the option to start and stop the service.