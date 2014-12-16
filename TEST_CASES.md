## VersionOne Integration for TFS Test Cases

> add intro text here

### Test Case 1: Verify documentation

1. Open documentation at http://versionone.github.io/VersionOne.Integration.VSTFS/
2. Verify that system requirements are accurate
3. Verify installation steps
4. Verify screenshots
5. Verify usage workflows


### Test Case 2: Verify TFS Listener Installation

Step 1.  Type URL into browser: http://[machine]:port/Service.svc
> Expected result: Should see webpage that displays.

### Test Case 3: Verify  TFS Listener Configuration

Step 1. Open the TFS Listener via Start Menu -> Programs -> VersionOne TFS Listener.
> Expected Result: A dialog box appears labeled "VersionOne TFS Listener Configuration" and it has three tabs 1) "VersionOne Server", 2) "TFS Server", 3) "Advanced".

Step 2. Select the "VersionOne Server" tab and fill in the required parameters.
Step 3. Click on the "Test Connection" button.
> Expected result: Dialog box appears with message : "Test connection successful!"

Step 4. Select the "TFS Server" tab and fill in the required parameters.
Step 5. Click on the "Connect" button.
> Expected result: The X and X events should appear in the "Current Subscritptions" box.

Step 6. Select the "Advanced" tab.
> Expected result: the "VersionOne Workflow Regular Expression" should be populated with xxx.


### Test Case 4: Verify TFS Policy Installation

- install policy according to documentation
- enable for a TFS project (if unable to complete steps to enable, install failure?)
- configure V1 build integration 

### Test Case 5: Verify TFS Policy Configuration

- install policy according to documentation
- enable for a TFS project (if unable to complete steps to enable, install failure?)
- configure V1 build integration 

### Test Case 6: Verify TFS Code Check-in Workflow

- Open project in Visual Studio that has policy enabled
- make a change to the project and check-in that change
- check tfs log files are being accessed and written to
- navigate to V1 and verify the build and changeset grids for that work item 

### Test Case 7: Verify Integration Log Files





