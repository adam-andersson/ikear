# IKEAR
This is an application that allows the user to design rooms with furnitures using Augmented Reality. The application is developed using Unity 2020.3.29f1. It is built for iOS and tested on an iPhone XS running iOS 15.3.1.

## Main Scene
The main scene for the game is  [`IKEAR.unity`](./Assets/Scenes/IKEAR.unity).

# Controls
The UI for the application is divided into two parts. The bottom part of the screen is used for selecting furniture to be placed. The top part is used when manipulating furniture. 

### Scanning the surroundings
The first step to to using the AR application is to scan the surroundings. Move the camera around and point it towards different planes. The planes will be scanned and there will be yellow planes on some surfaces indicating that these planes have been registered. 

### Placing furniture
To place a piece of furniture, select the furniture to be placed from the bottom UI. Each furniture have a preview image of what the furniture looks like. With a furniture selected, tap anywhere on the screen (except for any UI or other furniture) in order to place the furniture. The furniture will be placed in the center of the screen on the corresponding plane. There is a crosshair indicating where the furniture will be placed.

### Manipulating furniture
The furniture may be moved, rotated and deleted after being placed. This takes place with an "active item" system. Select any placed furniture by tapping on it. When this furniture have been correctly selected, a red hitbox will surround the furniture, indicating that this is the active furniture. When a furniture is active, the user can perform several actions:
- Move a furniture. This is done by holding the finger on the active furniture and dragging it to its new location. This new location can be anywhere on any detected plane.
- Rotate a furniture. This is done by holding the finger on the active furniture and keeping it stationary. The furniture will start to rotate clockwise at a constant pace.
- Remove a furniture. This is done by tapping the remove button (<img src="./Assets/Textures/cancel.png" alt="delete button" width="12"/>) in the top UI. This will immediately remove the currently active furniture without any prompt.
- Deselect the furniture. This is done by tapping the confirm button (<img src="./Assets/Textures/confirm.png" alt="confirm button" width="12"/>) in the top UI. This will remove the hitbox around the furniture and actions such as tapping the delete button will no longer remove this furniture.
- Select another furniture. By tapping on another piece of furniture the active furniture changes. There can only be one active furniture at a time. It is always the furniture with the hitbox that is the currently selected furniture.

# Resources
### Packages
In this project, the following packages are used and needs to be downloaded using the Package Manager:
- AR Foundation 
- ARCore XR Plugin
- ARKit XR Plugin

### Objects
- Big Furniture Pack
- AR project preset in Unity. This project was created using the AR preset, but no objects was used that was included in the preset.
- Cancel and Confirm icons from Flaticon (<a href="https://www.flaticon.com/free-icons/correct" title="correct icons">Correct icons created by Aldo Cervantes - Flaticon</a>).