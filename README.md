# 🔍 Tile-Based Pathfinding Visualizer for Unity

**Diploma Project – Pathfinding Algorithms in Turn-Based Games**

This Unity-based project is a visual and interactive system designed to compare the performance of multiple classic pathfinding algorithms in a grid-based, turn-based game environment. It provides a practical and educational tool to observe how different algorithms behave under identical conditions.

## 🎯 Features

- **Real-time Visualization** of four pathfinding algorithms:  
  - 🔵 A*  
  - 🟡 Dijkstra  
  - 🔴 Breadth-First Search (BFS)  
  - 🟣 Greedy Best-First Search (GBFS)

- **Color-coded Path Display** using `LineRenderer` for each algorithm.
- **Performance Metrics UI** displaying:
  - Path cost
  - Path length
  - Execution time (ms)
- **Dynamic Map Loading** – select from multiple map prefabs with varied obstacle layouts.
- **Custom Tile Cost System** – tiles display different movement costs via color:  
  🟩 Green (1) • 🟨 Yellow (2) • 🟥 Red (3+) • ⬜ Gray (impassable)

## 🧠 Architecture

- `GridManager` – Initializes grid and manages tiles.
- `Unit` and `Player` – Abstract and concrete movable units on the grid.
- `BasePathfinder` & Algorithm Classes – Modular implementations of A*, Dijkstra, BFS, GBFS.
- `MultiPathfindingManager` – Executes and benchmarks all algorithms simultaneously.
- `PathfindingUIController` – Updates algorithm performance data on screen.
- `MapSelectionUI` – Allows switching between different maps dynamically.
- `CameraController` – Smooth camera movement and zoom.

## 🕹️ How It Works

1. **Launch the scene** – A default map loads with a movable player unit.
2. **Click on a tile** – All four algorithms will simultaneously calculate and draw the shortest path.
3. **Watch the results** – Compare cost, length, and time directly in the UI.
4. **Switch maps** – Try different scenarios using the map selector buttons.

## 🧪 Purpose

This project was developed as part of a bachelor's thesis exploring pathfinding systems in turn-based strategy games. It is aimed at game developers, students, and AI enthusiasts who want to study the performance trade-offs of different algorithms in a practical and visual way.
