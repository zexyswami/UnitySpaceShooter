# Unity Space Shooter

Welcome to the **Unity Space Shooter** project! This is a classic arcade-style space shooter game built using the Unity game engine. The project is designed to demonstrate foundational Unity skills, including game mechanics, physics, and UI development.

---

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Setup and Installation](#setup-and-installation)
- [Game Mechanics](#game-mechanics)
- [Controls](#controls)
- [Assets and Credits](#assets-and-credits)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Player Controls**: Move the spaceship to dodge obstacles and fire lasers.
- **Enemy Waves**: Multiple waves of enemies with increasing difficulty.
- **Power-ups**: Collect power-ups for enhanced abilities.
- **Scoring System**: Earn points for destroying enemies and surviving longer.
- **Game UI**: Health bar, score display, and game-over screen.
- **Visual and Audio Effects**: Explosions, particle effects, and dynamic background music.

---

## Requirements

- **Unity Version**: 2021.3 or newer
- **Operating System**: Windows 10, macOS 10.15+, or equivalent
- **Hardware**: 
  - Minimum 8GB RAM
  - Dedicated GPU recommended for smooth performance

---

## Setup and Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/unity-space-shooter.git
   ```

2. **Open the Project in Unity**:
   - Launch Unity Hub.
   - Click `Open Project` and navigate to the cloned repository folder.

3. **Install Dependencies**:
   - Unity will automatically detect and import all required packages.

4. **Play the Game**:
   - Click the `Play` button in the Unity Editor to test the game.

---

## Game Mechanics

### Player
- **Health**: Starts with 3 lives. Collisions with enemies or projectiles reduce health.
- **Weapons**: Fires lasers with a cooldown period.

### Enemies
- Appear in waves with increasing frequency and complexity.
- Destroyed enemies drop score points and occasional power-ups.

### Power-ups
- **Shield**: Grants temporary invincibility.
- **Double Laser**: Fires two lasers simultaneously.
- **Health Restore**: Restores one life.

### Scoring System
- Points are awarded for destroying enemies:
  - Basic enemy: 10 points
  - Advanced enemy: 20 points
- Bonus points for wave completion.

---

## Controls

| Action             | Input                 |
|--------------------|-----------------------|
| Move Up            | `W` / `Arrow Up`     |
| Move Down          | `S` / `Arrow Down`   |
| Move Left          | `A` / `Arrow Left`   |
| Move Right         | `D` / `Arrow Right`  |
| Fire Weapon        | `Space`              |
| Pause Game         | `P`                  |

---

## Assets and Credits

- **Visual Assets**:
  - Spaceship and enemy sprites from [Kenney Assets](https://kenney.nl/).
- **Audio**:
  - Background music and sound effects sourced from [Freesound](https://freesound.org/).
- **Font**:
  - Game UI font from [Google Fonts](https://fonts.google.com/).

---

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m 'Add new feature'
   ```
4. Push the branch:
   ```bash
   git push origin feature-name
   ```
5. Open a Pull Request on GitHub.

---

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use and modify it for personal or commercial projects.

---

Happy Shooting! 🚀
