This code implements functionality for a Unity game involving a moving sphere, spawning planes and obstacles, and controlling camera movement. Here's a brief description of each script:

### 1. **CameraMove.cs**
- **Purpose:** Controls the camera's position to follow the sphere.
- **Details:**
  - Uses `FixedUpdate` to continuously update the camera's position to stay behind the sphere at a fixed offset.

### 2. **PlaneSpawn.cs**
- **Purpose:** Spawns planes and obstacles in the game.
- **Details:**
  - Contains references to prefabs for bottom planes, top planes, and two types of obstacles.
  - Uses an array of positions to determine where to spawn planes.
  - Periodically spawns planes at random positions, with a chance to spawn obstacles on them.
  - If the sphere's y-position exceeds certain limits, it resets the sphere's position and destroys all spawned planes.

### 3. **SphereMove.cs**
- **Purpose:** Controls the movement and gravity inversion of the sphere, along with camera rotation.
- **Details:**
  - Moves the sphere forward and handles its horizontal movement based on user input.
  - Inverts gravity and rotates the camera when the spacebar is pressed.
  - Implements a cooldown to prevent rapid gravity inversion.
  - Checks for out-of-bound positions to trigger a game over state.
  - Detects collisions with planes to determine if the sphere is grounded.

### Summary of Key Functionalities:
1. **Camera Movement**:
   - The camera follows the sphere at a fixed offset using `CameraMove`.

2. **Plane and Obstacle Spawning**:
   - `PlaneSpawn` spawns planes and obstacles at random positions, resetting them when the sphere goes out of bounds.

3. **Sphere Movement and Gravity Inversion**:
   - `SphereMove` handles sphere movement, gravity inversion on spacebar press, and camera rotation to match the gravity direction.
   - Implements horizontal movement with arrow keys and checks for grounded state using collisions.
   - Detects when the sphere goes out of bounds to trigger game over and reset states.

These scripts together create a dynamic gameplay experience where the player controls a sphere that moves forward, can invert gravity, and interacts with randomly spawned planes and obstacles.
