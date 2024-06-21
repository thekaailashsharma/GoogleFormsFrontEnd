# .NET MAUI Multiplatform Application for Form Submissions

This is a multiplatform desktop application built with .NET MAUI for managing form submissions. The application allows users to view existing submissions, navigate through them using navigation buttons, and create new submissions with various fields. Keyboard shortcuts are implemented for efficient navigation and form submission.

## Table of Contents
- [Introduction](#introduction)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Features](#features)
  - [View Submissions](#view-submissions)
  - [Create New Submission](#create-new-submission)
- [Platform Considerations](#platform-considerations)
- [Future Development](#future-development)
- [License](#license)

## Introduction

This desktop application is developed using .NET MAUI, a multiplatform framework that allows for building applications across multiple operating systems, including Windows, macOS, and more. While initially developed on macOS due to platform availability, the application is designed to be easily portable to Windows for future internship opportunities or platform-specific requirements.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/thekaailashsharma/GoogleFormsFrontEnd.git
    cd your-repo-name
    ```

2. Open the solution file (`YourSolutionName.sln`) in Visual Studio or JetBrains Rider.

3. Build the solution to restore packages and dependencies.

## Running the Application

1. Set the startup project to the frontend application (if necessary).

2. Run the application using the debugger in your IDE or by pressing `F5`.

3. The application will launch and be ready to use on your desktop platform.

## Features

### View Submissions

- Clicking "View Submissions" opens a form to view existing submissions.
- Navigate through submissions using "Previous" and "Next" buttons.
- By default, the first submitted form entry is displayed.

### Create New Submission

- Clicking "Create New Submission" opens a form to create a new submission.
- Editable fields include Name, Email, Phone Number, GitHub repo link.
- A button controls the start and pause of a stopwatch (preserving elapsed time).
- Submit button sends the form details to the backend server for storage.

## Platform Considerations

This application is developed primarily on macOS using .NET MAUI due to platform availability. However, .NET MAUI supports building applications for various platforms including Windows. Future development can include optimizations or adaptations for specific platform requirements.

## Future Development

- **Transition to Windows**: Aspiring to transition development to Windows environment for potential internship or platform-specific opportunities.
- **Enhanced Features**: Consider adding advanced functionalities such as form editing, data visualization, or integration with additional APIs to expand application capabilities.


