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

## 🗺️ Example Maps

Below are sample grid maps used in the project. Each map presents a different type of environment and challenge for the pathfinding algorithms.

### 🔹 Map Previews

This project includes three distinct tile-based maps, each designed to demonstrate different challenges for pathfinding algorithms.

| Small Weighted Maze | Medium Unweighted Maze | Medium Obstacle Map |
|---------------------|------------------------|----------------------|
| ![Small Weighted Maze](https://github.com/user-attachments/assets/af110b5e-1223-4648-96e8-817130cdc0fd) | ![Medium Maze](https://github.com/user-attachments/assets/2481fe8e-ce03-4412-b606-0b33eec8a4ed) | ![Obstacle Map](https://github.com/user-attachments/assets/467a19b4-baaf-4d39-b177-e64469e8e1d4)|


Each map includes:
- Unique **obstacle placement** and **tile cost variations**.
- Testing conditions for **algorithm behavior**, **path optimality**, and **performance under complexity**.

You can add new maps by creating a prefab with a `GridManager` component and placing tiles with appropriate cost and walkability properties.


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
