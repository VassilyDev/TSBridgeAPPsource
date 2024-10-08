![GitHub](https://img.shields.io/github/license/rufus31415/sharer) ![.NET Framework 4.8](https://img.shields.io/badge/.NET_Framework-4.8-blueviolet)

TSBridge is an Arduino library for controlling Train Simulator, based on RailDriver.dll and Sharer.dll. The project is completed by a Windows application that must run when Train Simulator is running, communicating with the board with a referesh rate of about 10Hz.
This project is in development, and any contribution is appreciated.

# Bridge application development notes
* App is compiled in VisualStudio, targeting .NET Framework 4.8. Required references are [Sharer](https://github.com/Rufus31415/Sharer) and Raildriver.dll (available in TrainSimulator plugins folder).
* Data is exchanged with the game via the Raildriver.dll API. Every locomotive/engine has a limited set of available data, and the names can change between them.
* The available data is extracted using the "generate loco report" button, and stored in the application directory.
* The data is processed and remapped correctly in the Decoder.cs using the LocoData.xml database (for example the throttle name can change between VirtualThrottle, Regulator, ThrottleAndBrake).
