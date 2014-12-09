## VersionOne Integration for TFS Test Cases

> add intro text here

### Test Case 1: Verify documentation

1. Open documentation at http://versionone.github.io/VersionOne.Integration.VSTFS/
2. Verify that system requirements are accurate
3. Verify installation steps
4. Verify screenshots
5. Verify usage workflows


### Test Case 2: Verify TFS Listener Installation

- install tfs listener according to documentation
- type URL into browser: http://[machine]:port/Service.svc
- recommend install to port 9090 but should test with other port assignments

### Test Case 3: Verify  TFS Listener Configuration

- configure listener according to documentation (documentation not very clear on this)
- test with ports other than 9090 (need some port numbers)

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





