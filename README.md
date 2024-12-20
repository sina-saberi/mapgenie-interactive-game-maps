# MapGenie Interactive Game Maps

This is a clone of the [MapGenie](https://mapgenie.io) interactive maps, created using **Next.js** and **.NET**. Please note that this project may lack some features of the original MapGenie platform.

## Features

- Interactive game maps for various titles.
- Built using modern technologies like Next.js and .NET.
- PostgreSQL database support for data storage.

## Quick Start

Follow these steps to set up and run the project on your local machine:

### Prerequisites

1. Install **PostgreSQL** on your system.
2. Install **Node.js** and **npm** (or **yarn**) for managing the frontend.
3. Install **.NET SDK** for the backend.

### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd mapgenie-interactive-game-maps
   ```

2. **Run the migration commands to update the database schema accordingly.**

    ```bash
    dotnet ef database update
    ```
3. **Initialize your maps data:** Since this is a fresh clone of the repository, there won't be any maps or data preloaded. However, the application includes scrapers that you can use to populate your database and create a starting map for yourself. Refer to the scrapers' documentation or scripts in the repository to get started.
