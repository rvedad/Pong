# Pong

A remake of the classic arcade game, built in **Unity 6** as my first Unity project. Play against a friend on the same keyboard, or against an AI opponent with three difficulty levels.

---

## Features

- **Two game modes** — VS Human (local two-player) or VS AI
- **Choose your side** — play as Player 1 (left) or Player 2 (right) against the AI
- **Three AI difficulties** — Easy, Medium and Hard
- **Ball speed-up** — the ball gets faster with every paddle hit, up to a maximum speed
- **First to 5 wins**, with a win screen and a Play Again button
- **Pause menu** — resume, return to the main menu, or quit
- **Sound effects** for paddle hits, wall bounces and goals
- **Score flash** when a point is scored
- **Ball trail** effect
- **Classic dashed center line**

---

## Controls

| Action | Player 1 (Left) | Player 2 (Right) |
|---|---|---|
| Move up | `W` | `↑` |
| Move down | `S` | `↓` |
| Pause / Resume | `Esc` | `Esc` |

In VS AI mode, you use the controls for the side you picked in the menu.

---

## How the AI Works

The AI paddle only tracks the ball while the ball is moving **toward** it. When the ball moves away, the paddle drifts back to the center at half speed. Difficulty controls how fast the AI paddle can move, so it can be beaten by angling the ball once it speeds up.

---

## Project Structure

```
Assets/
├── Scenes/
│   ├── MainMenu
│   └── Game
├── Scripts/
│   ├── MainMenuController.cs   Menu selections, saved with PlayerPrefs
│   ├── GameSetup.cs            Reads menu choices, enables player or AI control
│   ├── GameManager.cs          Score, win condition, restart (singleton)
│   ├── BallController.cs       Launch, bounce, speed-up, reset, sounds
│   ├── PaddleController.cs     Keyboard paddle movement
│   ├── AIController.cs         AI paddle movement and difficulty
│   ├── GoalController.cs       Detects goals with trigger colliders
│   ├── PauseMenu.cs            Pause, resume, main menu, quit
│   └── CenterLine.cs           Spawns the dashed center line
├── Prefabs/
├── Audio/
└── Materials/
```

---

## Running the Project

1. Open the project in **Unity 6** (Unity Hub → Add → select the project folder).
2. Open `Assets/Scenes/MainMenu`.
3. Press **Play**.

The `MainMenu` scene must be at index 0 in **File → Build Profiles → Scene List**, with `Game` at index 1.

---

## What I Learned

- GameObjects, components and the Inspector
- Rigidbody2D physics, colliders vs. triggers, and physics materials
- The Unity lifecycle: `Awake`, `Start`, `Update` and `FixedUpdate`
- Singletons for manager objects
- Coroutines for timed effects
- `PlayerPrefs` for passing settings between scenes
- UI with Canvas, TextMeshPro, buttons and the EventSystem
- `Time.timeScale` for pausing
- Prefabs and `Instantiate`
- Enabling and disabling components with `.enabled` vs. `SetActive`

---

## Known Issues

- The AI paddle can look slightly jittery when moving slowly.

---

## Credits

- Built by **Vedad**
- Based on *Pong* (Atari, 1972)
