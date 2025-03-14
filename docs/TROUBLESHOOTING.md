# SRAYSScoreboard Troubleshooting Guide

This document provides solutions for common issues you might encounter when using SRAYSScoreboard.

## Connection Issues

### No Connection to Timing System

**Symptoms:**
- "COM port not found" message
- No data appears on the scoreboard
- Application starts but doesn't display any event information

**Solutions:**
1. **Check Physical Connection**
   - Ensure the serial cable is securely connected to both the computer and the timing system
   - If using a USB-to-Serial adapter, try a different USB port
   - Try a different serial cable if available

2. **Verify COM Port Settings**
   - Right-click on the scoreboard and select "COM Port" > "Refresh List"
   - Ensure the correct COM port is selected
   - Check Windows Device Manager to confirm the COM port is properly installed

3. **Check Timing System Configuration**
   - Verify the ARES system is set to output in Venus ERTD scoreboard format
   - Check the baud rate settings on the timing system (default is 9600)
   - Ensure the timing system is actually sending data

4. **Restart Components**
   - Close and reopen SRAYSScoreboard
   - Restart the timing system
   - In some cases, restarting the computer may help

### Intermittent Connection

**Symptoms:**
- Data appears and disappears randomly
- Connection drops during events

**Solutions:**
1. **Check for Interference**
   - Move the serial cable away from power sources or other electronic equipment
   - Use a shielded serial cable if possible

2. **Verify Cable Quality**
   - Replace the serial cable with a higher quality one
   - Ensure the cable is not damaged or kinked

3. **Check USB Power Management**
   - If using a USB-to-Serial adapter, disable USB power saving in Windows:
     - Open Device Manager
     - Expand "Universal Serial Bus controllers"
     - Right-click on each USB Root Hub
     - Select "Properties" > "Power Management"
     - Uncheck "Allow the computer to turn off this device to save power"

## Display Issues

### Incorrect or Missing Data

**Symptoms:**
- Swimmer names or times not displaying correctly
- Event information missing or garbled
- Lanes showing incorrect data

**Solutions:**
1. **Check Protocol Format**
   - Ensure the timing system is using the correct protocol format (Venus ERTD)
   - Verify the header codes being sent match those expected by the application

2. **Check Character Encoding**
   - If swimmer names contain special characters, ensure the timing system is using the correct character encoding

3. **Verify Data Source**
   - Confirm that the timing system is properly configured with the correct event and swimmer information

### UI Display Problems

**Symptoms:**
- Text overlapping or cut off
- Colors not displaying correctly
- Window sizing issues

**Solutions:**
1. **Reset Color Settings**
   - Right-click on the scoreboard
   - Select "Colors" > "Reset to Default Colors"

2. **Check Display Resolution**
   - Ensure your display resolution is at least 1024x768
   - Try resizing the window if text appears cut off

3. **Font Scaling Issues**
   - If using Windows display scaling, try setting the application to override high DPI scaling:
     - Right-click on the SRAYSScoreboard.exe file
     - Select "Properties" > "Compatibility" > "Change high DPI settings"
     - Check "Override high DPI scaling behavior"
     - Select "System (Enhanced)" from the dropdown

## OBS Integration Issues

### Capture Problems

**Symptoms:**
- OBS not capturing the scoreboard window
- Black screen in OBS when trying to capture

**Solutions:**
1. **Use Window Capture**
   - In OBS, use "Window Capture" instead of "Game Capture"
   - Select the "OBSScoreboard" window from the dropdown

2. **Try Display Capture**
   - If Window Capture doesn't work, try using "Display Capture" instead
   - Position the OBS Scoreboard window where it can be captured

3. **Check Graphics Settings**
   - If using a laptop with dual graphics (integrated and discrete), make sure OBS is using the same GPU as the scoreboard application

### Color Keying Issues

**Symptoms:**
- Unable to properly chroma key the background
- Background color bleeding into text

**Solutions:**
1. **Optimize Background Color**
   - Choose a solid background color that doesn't appear in any text (bright green or blue works well)
   - Right-click on the scoreboard and select "Colors" > "Background Color"

2. **Adjust OBS Chroma Key Settings**
   - In OBS, add a "Chroma Key" filter to the scoreboard source
   - Fine-tune the similarity, smoothness, and key color spill reduction settings
   - Use the preview to check the results

## Performance Issues

### High CPU Usage

**Symptoms:**
- Computer running slowly when scoreboard is active
- Fan running at high speed
- Other applications becoming unresponsive

**Solutions:**
1. **Close Unnecessary Applications**
   - Close other applications running in the background
   - Especially close other applications that might be using the same COM port

2. **Check for Infinite Loops**
   - If the application seems to be in an infinite loop processing data, restart it
   - This could happen if corrupted data is received from the timing system

3. **Update Drivers**
   - Ensure your serial port or USB-to-Serial adapter drivers are up to date

### Memory Leaks

**Symptoms:**
- Application uses more and more memory over time
- Performance degrades the longer the application runs

**Solutions:**
1. **Restart Periodically**
   - For long events, consider restarting the application during breaks
   - This will clear any accumulated memory issues

2. **Update to Latest Version**
   - Check for updates to the application that might fix memory leak issues

## Application Crashes

### Unexpected Shutdowns

**Symptoms:**
- Application closes without warning
- Error messages appear before closing

**Solutions:**
1. **Check Event Viewer**
   - Open Windows Event Viewer and check for application errors
   - Look for entries related to SRAYSScoreboard

2. **Run as Administrator**
   - Right-click on the SRAYSScoreboard.exe file
   - Select "Run as administrator"

3. **Check .NET Framework**
   - Ensure you have .NET Framework 4.7.2 or higher installed
   - Repair or reinstall .NET Framework if necessary

4. **Reinstall Application**
   - Uninstall the application
   - Download a fresh copy from the releases page
   - Install it again

## Reporting Issues

If you encounter an issue that isn't covered in this guide:

1. **Gather Information**
   - Note the exact steps that led to the issue
   - Record any error messages that appeared
   - Note your system specifications (Windows version, .NET version, etc.)
   - If possible, take screenshots of the issue

2. **Check for Known Issues**
   - Visit the GitHub repository's Issues page to see if your issue has already been reported

3. **Submit an Issue**
   - If your issue is new, create a new issue on the GitHub repository
   - Include all the information you gathered
   - Be as specific as possible to help the developers reproduce and fix the issue
