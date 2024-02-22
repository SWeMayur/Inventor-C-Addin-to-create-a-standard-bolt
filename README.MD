# Inventor C# Add-In: Standard Bolt Creator

## Overview

This Inventor C# add-in allows you to create a standard bolt using Autodesk Inventor. The add-in provides a user-friendly interface for inputting bolt parameters such as diameter, length, thread depth, and thread pitch. It utilizes Windows Forms for user interaction within Autodesk Inventor environment.

## Features

- Create a standard bolt with specified dimensions.
- Utilizes Autodesk Inventor API for features like Extrude, Sketch, Profile, Part Component Definition, and Thread.
- User-friendly interface for inputting bolt parameters.
- Threaded feature added to the bolt.

## Technologies Used

- C# Language
- Autodesk Inventor API
- Windows Forms for User Interface

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/SWeMayur/InventorStandardBoltAddin.git
    ```

2. Open the solution in Visual Studio.

3. Build the solution.

4. Run the add-in within Autodesk Inventor.

## Usage

1. Open Autodesk Inventor.

2. Load the add-in:

   - Navigate to the "Add-Ins" tab.
   - Click "External Tools."
   - Choose "Standard Bolt Creator."

3. The "Create Bolt" button will appear in the "Part" tab.

4. Click the "Create Bolt" button to open the Bolt Parameters form.

5. Enter the bolt parameters (Diameter, Length, Thread Depth, Thread Pitch).

6. Click "OK" to create the standard bolt.

## How It Works

1. **Create Part Document:** Initializes a new part document using the `PartDocument` class.

2. **Sketch Creation:** Uses the `Sketches` property of `PartComponentDefinition` to add sketches for creating the bolt shape.

3. **Extrude Feature:** Utilizes the `ExtrudeFeatures` property to create an extrude feature for the bolt shape.

4. **Thread Feature:** Uses the `ThreadFeatures` property to add a threaded feature to the bolt.

## Contributing

If you'd like to contribute to this project, please follow these steps:

1. Fork the repository.

2. Create a new branch:

    ```bash
    git checkout -b feature/new-feature
    ```

3. Make your changes and commit them:

    ```bash
    git commit -am 'Add new feature'
    ```

4. Push to the branch:

    ```bash
    git push origin feature/new-feature
    ```

5. Create a pull request.

