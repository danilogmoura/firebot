# Firebot

Firebot is a bot designed for the game Firestone Idle RPG. This bot aims to enhance the gaming experience by automating various tasks and providing useful features for players.

## About
This project is a mod for the game Firestone Idle RPG, using [MelonLoader](https://github.com/LavaGang/MelonLoader) Nightly V0.7.2+.

## Features
- **Offline Progress**: Automatically claims offline progress rewards
- **Tools Production** (Engineer): Automatically collects produced tools from the Engineer
- **Warfront Campaign**: Automatically collects Warfront campaign scrolls
- **Missions**: Manages missions automatically - claims completed mission rewards and starts new missions with available squads
- **Expeditions**: Manages expeditions - claims completed expedition rewards and starts new expeditions when available
- **Firestone Research** (Library): Automatically starts research and claims completed research
- **Oracle Rituals**: Claims completed rituals and starts new rituals when available
- **Guardian Training** (Magic Quarters): Automatically initiates guardian training

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/firebot.git
   ```
2. Navigate to the project directory:
   ```bash
   cd firebot
   ```
3. Build the project using your preferred method (e.g., Visual Studio, command line).

## Configuration
The bot configuration file can be found at `Firestone\UserData\FirebotPreferences.cfg`.

For now, all configuration must be done directly through this file. A configuration display interface will be implemented in the future.


## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

## Disclaimer: Not a Cheat

Firebot is not a cheat. It does not modify game resources, grant unfair advantages, interfere with server logic, or alter game files. The bot only automates actions that a player could perform manually, without bypassing any security or protection mechanisms of the game.

## Technical Details

- Firebot is implemented as a mod using MelonLoader, enabling automation of repetitive tasks within the game client itself.
- All actions performed by the bot simulate clicks and commands that a user would normally do, without modifying server data or circumventing security systems.
- The code is open source and auditable, ensuring transparency about its operation.