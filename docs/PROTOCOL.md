# Venus ERTD Protocol

This document provides a brief overview of the Venus ERTD protocol used by the Omega ARES 21 timing system.

## Control Characters

The protocol uses the following ASCII control characters:

- SOH (Start of Header): ASCII 0x01
- STX (Start of Text): ASCII 0x02
- EOT (End of Transmission): ASCII 0x04

## Header Codes

The application recognizes the following header codes:

- Event information: 0040100069
- Running time: 0040100000
- Lane 1-10 swimmer names: 0040100200, 0040100236, etc.
- Lane 1-10 results: 0040100220, 0040100256, etc.

## Data Processing

1. The application reads data from the serial port
2. It processes each character according to the protocol
3. When a complete message is received, it updates the display

For more details, see the `AresDataHandler.cs` file which contains the implementation of the protocol parser.
