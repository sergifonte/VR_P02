# Hidden Hues: Color Blindness Awareness App

**Hidden Hues** is an Augmented Reality (AR) application designed to simulate the world as perceived by people with various types of color vision deficiency (CVD). By using "inverse psychology," the app hides colors from non-color-blind users to foster empathy and encourage more inclusive UX/UI design.

## Key Features
* **AR Real-World Simulation:** Use your mobile camera to see how your own environment transforms under different color filters.
* **Interactive Challenges:**
    * **Cube Level:** Find and select specific colored cubes spawned in your room.
    * **Traffic Light Level:** A driving simulation where you must react (Gas/Brake) to a virtual traffic light that may look different depending on your vision filter.
* **High-Fidelity Filters:** Real-time simulation of **Protanopia**, **Deuteranopia**, and **Tritanopia** using optimized LUTs and URP Post-Processing.

## Why Hidden Hues?
While most apps try to "fix" color blindness, our goal is to **educate**. We want designers and users to experience the confusion of low-contrast environments firsthand, helping to create a world that is better adapted to everyone.

## Tech Stack
* **Engine:** Unity (Universal Render Pipeline)
* **AR:** AR Foundation & ARCore
* **Design:** Figma (UI/UX)
* **Assets:** Custom LUTs by Andrew Willmot & Colorblind Shader plugins.

## How to Run
1. Clone the repository.
2. Open in Unity 2022.3+.
3. Ensure **ARCore** is enabled in XR Plug-in Management.
4. Build for **Android** (minimum API level 24).

## The Team
* **Emma:** Research & Documentation
* **Sergi:** Filters & Cube Mechanics
* **Xènia:** UI & Team Organisation
* **Paula:** Content Collaboration
* **Marina:** Level Design & Traffic Light Level script
