# SRAYSScoreboard

A Windows application that displays real-time swimming competition data from the Omega ARES 21 timing system. This scoreboard display is optimized for a ten-lane pool and provides a clean, easy-to-read interface for spectators and officials.

![SRAYSScoreboard Screenshot](https://github.com/fvishram/SRAYSScoreboard/raw/main/screenshots/scoreboard.png)

## Overview

SRAYSScoreboard was developed by Silver Rays Swim Club to provide a simple, reliable way to display swimming competition data from the Omega ARES 21 timing system. The application connects to the timing system via a serial port and displays:

- Event name and number
- Running time
- Swimmer names
- Finishing places
- Swimmer times

The application is designed to be displayed on a secondary monitor or projector for spectators to view during swim meets. It also includes a dedicated interface for Open Broadcaster Software (OBS) integration, allowing for easy streaming of competition data.

## System Requirements

- Windows operating system (Windows 7 or newer)
- .NET Framework 4.7.2 or higher
- Available serial port (COM port) for connection to the Omega ARES 21 timing system
- Display with resolution of at least 1024x768 (higher resolution recommended)

## Installation

1. Download the latest release from the [Releases](https://github.com/fvishram/SRAYSScoreboard/releases) page
2. Extract the ZIP file to a location of your choice
3. Run `SRAYSScoreboard.exe` to start the application

Alternatively, you can build the application from source:

1. Clone this repository
2. Open `SRAYSScoreboard.sln` in Visual Studio (2017 or newer recommended)
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

## Configuration

### Timing System Setup

Before using SRAYSScoreboard, you must configure your Omega ARES 21 timing system:

1. Set the ARES system to output in Venus ERTD scoreboard format
2. Connect the ARES system to your computer using a serial cable (typically RS-232)
   - Note: If your computer doesn't have a serial port, you may need a USB-to-Serial adapter

### Application Setup

1. Launch SRAYSScoreboard
2. Click on "Settings" in the menu bar
3. Enter the COM port that your timing system is connected to (e.g., COM1, COM2)
4. Click "OK" to save the settings

## Usage

1. Start the application before the beginning of the swim meet
2. The application will automatically display data as it is received from the timing system
3. The display will update in real-time as events progress
4. To exit the application, click on "File" > "Exit" in the menu bar

## Features

- Real-time display of swimming competition data
- Support for 10-lane pool configurations
- Customizable colors for all display elements
- Easy COM port selection through context menu
- Dedicated OBS interface for live streaming
- Automatic saving and loading of user preferences
- Comprehensive error handling and connection management

## Troubleshooting

For common issues and their solutions, please see the [Troubleshooting Guide](docs/TROUBLESHOOTING.md).

For more detailed information about specific aspects of the application, refer to:

- [Protocol Documentation](docs/PROTOCOL.md) - Details about the Venus ERTD protocol
- [Customization Guide](docs/CUSTOMIZATION.md) - How to customize the appearance and behavior
- [Architecture Overview](docs/ARCHITECTURE.md) - Technical details about the application structure

## Development

SRAYSScoreboard is written in C# using Windows Forms. The main components are:

- `Scoreboard.cs`: The main form that displays the scoreboard interface
- `AresDataHandler.cs`: Processes the data received from the timing system
- `Settings.cs`: Handles the configuration of the COM port

### Data Format

The application expects data in the Venus ERTD format from the Omega ARES 21 timing system. The data is parsed according to specific header codes that identify different types of information (event name, running time, swimmer names, results).

## Contributing

Contributions to improve SRAYSScoreboard are welcome! Here's how you can contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature-name`)
3. Make your changes
4. Commit your changes (`git commit -m 'Add some feature'`)
5. Push to the branch (`git push origin feature/your-feature-name`)
6. Create a new Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

## Acknowledgments

- Silver Rays Swim Club for supporting the development of this application
- Omega for their timing system documentation
- All contributors who have helped improve this project

## Contact

For questions or support, please open an issue on the [GitHub repository](https://github.com/fvishram/SRAYSScoreboard/issues).
