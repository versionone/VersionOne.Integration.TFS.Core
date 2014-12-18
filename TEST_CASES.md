## VersionOne Integration for TFS Test Cases

> add intro text here

### Test Case 1: Verify documentation

Step 1. Open documentation at http://versionone.github.io/VersionOne.Integration.VSTFS/    
Step 2. Verify that system requirements are accurate.  
>Expected result: Documentation contains all pertinent system requirements.  
  
Step 3. Verify installation steps.    
Step 4. Verify screenshots.   
> Expected result: Screenshots should match what user will see during installation and completing workflow tasks.
 
Step 5. Verify usage workflows.
> Expected result: VersionOne and Visual Studio workflows produce desired work item tracking and visibility within VersionOne.    


### Test Case 2: Verify TFS Listener Installation

Step 1. Install TFS Listener per documnentation.  
Step 2. To verify proper installation, type URL into browser: http://[machine]:[port]/Service.svc  
> Expected result: Should see webpage that displays 
> 
> "Service Service
>   You have created a service.
>   To test this service, you will need to create a client and use it to call the service.  You can do this using the svcutil.exe tool from the command line with the following syntax:  
>   svcutil.exe http://[machine]:[port]/Service.svc?wsdl
>   etc.

### Test Case 3: Verify  TFS Listener Configuration

Step 1. Open the TFS Listener via Start Menu -> Programs -> VersionOne TFS Listener.
> Expected Result: A dialog box appears labeled "VersionOne TFS Listener Configuration" and it has three tabs 1) "VersionOne Server", 2) "TFS Server", 3) "Advanced".

Step 2. Select the "VersionOne Server" tab and fill in the required parameters.  
Step 3. Click on the "Test Connection" button.
> Expected result: The green dialog box appears with message : "[(local time)] Successfully connected to [VersionOne Server URL]

Step 4. Select the "TFS Server" tab and fill in the required parameters.  
Step 5. Click on the "Connect" button.
>Expected result: Message should appear below Connect button: Connected to [TFS Server URL]  

  
Step 6. Click the "Subscribe" button.
> Expected result: The CheckinEvent and BuildCompletionEvent events should appear in the "Current Subscritptions" box.

Step 7. Select the "Advanced" tab.
> Expected result: the "VersionOne Workflow Regular Expression" should be populated with [A-Z]{1,2}-[0-9]+.  
> Reference match explanation should be below that box:   
> To Match S-01001 (Matches "S-01001"):                [A-Z]{1,2}-[0-9]+  
To match #Reference (matches only "Reference"):      (?<=#)[a-zA-Z]+\b  
To match "V1:Reference"  (matches only "Reference"): (?<=V1:)[a-zA-Z]+\b    

Step 8. Click the "Save All Settings" button
>Expected result: Message should appear in green dialog box [(local time)] Save successful.  

Step 9. Close the VersionOne TFS Listener Configuration tool.
>Expected result: Tool closes without error.


### Test Case 4: Verify VersionOne Policy Installation

Step 1. Install the VersionOne.TFSPolicy.Installer.vsix by double-clicking the file.   
>Expected result: Installer pops up and requests verify the product(s) to install the extension to. Should see Microsoft Visual Studio [Edition] 2013 is defined and checkbox is checked.  

Step 2. Click the "Install" button.  
>Expected result: Quick install and installation complete verification message appears.  

Step 3. Click the "Close" button.
>Expected result: Installer closes without error.  


### Test Case 5: Enable VersionOne Check-in Policy for TFS Project

Step 1. Open Visual Studio [Edition] 2013.  
Step 2. Open the Team Explorer.  
Step 3. Right-click on the desired project, connect to that project then select "Settings".  
Step 4. Select "Source Control" under the Team Project list.  
>Expected result: Source Control Settings - [Project Name] box pops up.  

Step 5. select the "Check-in Policy" tab.  
Step 6. Click the "Add" button on the left.  
>Expected result: "Add Check-in Policy" box appears.  

Step 7. Find and select the "VersionOne Policy for Visual Studio 2013".  
Step 8. Click "OK".  
>Expected result: "VersionOne Policy for Visual Studion 2013" is displayed in the "Source Control Settings - [Project Name]" box.  

Step 9. Click "OK".  
>Expected result: The "Add Check-in Policy" dialog box closes; the "Source Control Settings - [Project Name] box is still visible and active.  
Step 10. Click "OK" to close the "Add Check-in Policy" dialog box.  
>Expected result: The "Add Check-in Policy" dialog box closes.

### Test Case 6: Verify VersionOne Build Integration

Step 1. Log into VersionOne application as an administrator.  
Step 2. Navigate to Administration -> Configuration -> System page.  
Step 3. Under "Enable Features", click the checkbox for "Build Integration" and click the "Apply" button.  
>Expected result: Build Integration feature is enabled and can be added to a project.  
>Able to navigate to Administration -> Projects -> Build Projects page.  

Step 4. Navigate to Administration -> Projects -> Build Projects page.  
Step 5. Click the "Add" button to add a new Build Project.
>Expected result: Build Project pop-up window appears with a form to complete.  

Step 6. Specify a Title in the Build Project window.  
Step 7. Specify a Reference in the Build Project window.  
Step 8. Click "OK" button to save the new Build Project and close this window.  
>Expected result: The title and reference just specified should now appear as a row in the Build Project window.  

Step 9. Navigate to Administration -> Projects -> Projects page.  
Step 10. Click "Edit" for the project row you want to associate to the new Build Project. 
>Expected result: An editable Project window opens.  

Step 11. In the editable Project window, find the "Build Projects" dropdown list and select the new Build Project that was just created to be associated to this project.  
Step 12. Click "OK" to save changes and close this window.  
>Expected result: Open project details page and click on Show Relationships; scroll down to "Build Projects" and your new build project should be visible there.  

Step 13. Logout of VersionOne.


### Test Case 7: Verify TFS Code Check-in Workflow

Step 1. Open a project in Visual Studio that has the VersionOne check-in policy enabled.  
Step 2. Make a change to the project and save the change.  
Step 3. Click on Team Explorer and navigate to Pending Changes.  
>Expected result: "Associate checkin with VersionOne work items" window should appear.  

Step 4. Select the VersionOne work item(s) (click the checkbox) to associate to this checkin.  
Step 5. Click "Ok".  
>Expected result: The VersionOne work item Id(s) should appear in the Visual Studio Team Explorer - Pending changes window in the Comment box.  

Step 6. Check-in the change with the VersionOne work item Id(s).
Step 7. Login to VersionOne and view details of the work item that was referenced in the TFS checkin.  
>Expected result: In the detail view of the VersionOne work item, the Changesets grid, Last Affected Build Runs grid, and Affected Build Runs grid should show the TFS changes.  


### Test Case 8: Verify Integration Log Files
Step 1. On the machine with the VersionOne TFS Listener installed, navigate to C:\ProgramData.  
Step 2. A log file named V1Debug should have been created and will contain a log of the check-in and build events that VersionOne has received.
>Expected result: For a successful check-in and build run, the V1Debug log file should
>contain the following key lines:  
>CheckIn Event  
>Process CheckIn Event for [changeset number] from [TFS Project Name]  
>Saved Changeset for [changeset number]  
>Begin Notification Message  
>End Notification Message  
>Build Event  
>Process Build Number [Build Run identifier] from [TFS Project Name]  
>Number of ChangeSets: [count of changesets for this checkin]  
>BuildRun Save Successful  





