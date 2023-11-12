# Zuyd on Wheels - Sustainable Transportation Project

![Zuyd on Wheels Logo](https://avatars.slack-edge.com/2023-09-13/5890460198580_38fa7376891430aa5949_132.png)

Welcome to the Zuyd on Wheels project! This project aims to promote sustainable transportation options for Zuyd University students and staff, reducing traffic congestion and carbon emissions.
[Assignment](https://mirri.link/1HdFU10)

# Table of Contents
1. [Zuyd on Wheels - Sustainable Transportation Project](#zuyd-on-wheels---sustainable-transportation-project)
2. [Project Overview](#project-overview)
3. [References](#references)
4. [Development Steps 📝](#development-steps-)
5. [Getting Started](#getting-started)
6. [GitHub Usage and Contributions](#github-usage-and-contributions)
7. [Folder Structure](#folder-structure)
8. [Testing and Contributions](#testing-and-contributions)
9. [License](#license)
10. [Acknowledgments](#acknowledgments)

## Project Overview

It's a fact: our roads are getting busier, and it's causing traffic jams and more greenhouse gas emissions. Zuyd University acknowledges its responsibility in addressing these issues. While idealistically, everyone should choose eco-friendly commuting options like public transport, cycling, or carpooling, the reality is that all parking spaces at Zuyd's Heerlen campus are often filled. This leads to students and staff having to park their cars in neighboring areas.

**Objective**:
- Create awareness about the impact of commuting choices.
- Encourage the Zuyd community to make sustainable travel decisions a part of their daily routine.

## References

- [ANWB Traffic Report - July 2023](https://www.anwb.nl/verkeer/nieuws/nederland/2023/juli/filezwaarte-juli-2023)
- [CBS Report on Sustainable Mobility](https://www.cbs.nl/nl-nl/longread/rapportages/2021/klimaatverandering-en-energietransitie-opvattingen-en-gedrag-van-nederlanders-in-2020/5-duurzame-mobiliteit)
- [Rijksoverheid Report on Sustainable Mobility](https://magazines.rijksoverheid.nl/ienw/duurzaamheidsverslag/2021/01/duurzame-mobiliteit)

## Getting Started

Follow these steps to set up the project locally and start contributing:

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/your-username/zuyd-on-wheels.git
   ```

2. **Set Up Development Environment**:
   - Install Visual Studio or Visual Studio Code.
   - Ensure you have the .NET SDK installed.

3. **Create Configuration Files**:
   - Duplicate `appsettings.example.json` and rename it to `appsettings.json`.
   - Configure database connection strings and other settings in `appsettings.json`.
   - Dont forget to do this is the Sustatron & SustatronApi both need a connection string

4. **Build and Run**:
   - Open the project in Visual Studio or Visual Studio Code.
   - Build and run the application.

5. **Database Migrations**:
   [docs](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
   - Use Entity Framework migrations to create the database schema.
   ```sh
   dotnet ef database update
   ```

7. **Explore the Application**:
   - u can run SustatronApi( to view the swagger ui with all endpoints)
   - u can run Sustatron( to view entire mvc applications)
   - Access the application in your web browser (usually at `http://localhost:port`).

## GitHub Usage and Contributions

We use GitHub for version control and collaborative development. Here are the steps to contribute:

1. **Branch Workflow**:
   - The `main` branch represents the production-ready code.
   - Create a `staging` branch off `main` for ongoing development and testing.
   - For each feature or bug fix, create a new branch with a linear branch name (e.g., `noaheutz/sus-34-test-issue`).
   - when commiting use [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)

2. **Pull Request (PR)**:
   - When your work is ready for review, open a PR from your feature branch to the `staging` branch.
   - Ensure that your PR includes detailed information about the changes made.

3. **Review Process**:
   - At least one team member must review your PR.
   - Reviewers check for code quality, adherence to standards, and functionality.
   - Make any necessary updates based on feedback.

4. **Quality Assurance (QA)**:
   - Before merging into `main`, the code undergoes testing in the `staging` branch.
   - Test thoroughly to ensure there are no regressions or new issues.
   
5. **Merge to Main**:
   - Once your PR is approved and passes QA, it can be merged into the `main` branch.
   - Only merge with a clean bill of health.

6. **Stay Updated**:
   - Pull frequently from `main` and rebase your feature branches to keep them up-to-date.

## Folder Structure

The solution consists of two main projects, Sustatron and SustatronAPI, each with its own set of directories and files tailored for specific roles within the overall architecture.

### Sustatron Project

- **Controllers**: Contains MVC controller classes for handling requests.
  - `CommuteController.cs`
  - `HomeController.cs`
  - `UsersController.cs`
  - `VehiclesController.cs`

- **Data**: Includes the Entity Framework DbContext and any database migrations.
  - `ApplicationDbContext.cs`

- **Models**: Entity classes and data models.

- **Views**: Organized by controller actions for rendering HTML views.

- **wwwroot**: Static files like CSS, JavaScript, and images.

- `appsettings.json`: Configuration settings for the application.

- `Program.cs`: The main entry point for the application.

### SustatronAPI Project (with Swagger)

- **Controllers**: Contains API controller classes for handling API requests.
  - `CommutesController.cs`
  - `UsersController.cs`
  - `VehiclesController.cs`

- **Data**: Houses the Entity Framework DbContext and migrations for the API project.

- **Models**: Entity classes and data models for API operations.

- `appsettings.json`: Configuration settings specific to the API.

- `Program.cs`: The entry point for the API application.

*Note*: The "SustatronAPI" project uses Swagger for API documentation and testing.


# Getting Started 🚀

Follow these steps to get started with the AutoProfix Garage Management System:

1. **Prerequisites**:
   - Make sure you have the following prerequisites installed on your development machine:
     - Visual Studio or Visual Studio Code.
     - .NET SDK (Software Development Kit).
     - SQL Server (or another preferred database system).

2. **Clone the Repository**:
   - Clone this GitHub repository to your local machine using the following command:
     ```
     git clone https://github.com/nahnova/Sustatron.git
     ```

3. **Open the Project**:
   - Open the project using your chosen development environment (Visual Studio or Visual Studio Code).

4. **Database Configuration**:
   - Configure your database connection string in the `appsettings.json` file. Ensure it points to your SQL Server instance or preferred database system.

5. **Database Migration**:
   - This project was created with Code First in mind, not Database First. Code First allows you to define your database schema using C# classes and generate the database from your model. Open a terminal within your project's root directory and run the following commands to apply the initial database migration:
     ```
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

6. **Run the Application**:
   - Build and run the application using your development environment. If using Visual Studio, press F5. If using Visual Studio Code, use the `dotnet run` command.

7. **Access the Application**:
   - Open your web browser and navigate to `http://localhost:5137` (or the port specified in your `Startup.cs` if different). You should see the AutoProfix Garage Management System homepage.

8. **Explore the Functionality**:
   - Explore the various features and functionalities 

9. **Customize and Extend**:
   - Customize the application to meet your specific requirements or extend its functionality as needed. You can modify controllers, views, models, and add new features to suit your needs.

10. **Testing and Deployment**:
    - Test the application thoroughly to ensure it meets your requirements and standards.
    - When ready, deploy the application to a production environment or hosting service to make it accessible to your team and customers.

11. **Documentation**:
    - Create documentation for your team, including user guides and admin instructions on how to use and maintain the system.

12. **Enjoy**:
    - Enjoy the benefits of the Sustatron, which will help streamline your emissions, improve customer service, and enhance your business sustainability.

Feel free to refer to the [Diagrams and Designs](#diagrams-and-designs) section for visual representations of the application's architecture, database schema, and user interface designs to gain a better understanding of the system's structure and functionality.

## Diagrams and Designs 📊🎨

1. **Wireframes and Mockups**: Design the user interface of your application using wireframes or mockups to outline the layout and user interaction flow.
<img width="1365" alt="Screenshot 2023-11-12 at 14 17 21" src="https://github.com/nahnova/Sustatron/assets/56248103/cbc6e137-7936-4de6-a3b4-7d60d70ce63d">

2. **Use Case Diagram**: Visualizes the use cases per actor.
![usecasediagram_png](https://github.com/nahnova/Sustatron/assets/56248472/550d91c1-8194-4b59-b735-be1c5b12d100)

4. **Entity Class Diagrams**: Visualize the relationships between entities in your code, including classes, properties, and methods.
<img width="1552" alt="Untitled" src="https://github.com/nahnova/Sustatron/assets/56248472/e6d5c031-62b1-4009-a64f-1894cfbda11e">

5. **Sequence Diagram**: Visualize the application flow and their related models.
<img width="1607" alt="Sequence Diagram (Community)" src="https://github.com/nahnova/Sustatron/assets/56248472/7f55333d-86ed-460d-bd50-c45f789922f1">


## Testplan 🧪🔧

#### Test Objectives
1. To verify the accurate addition of user information.
2. To ensure that vehicle registration functions as intended.
3. To validate the successful addition of commute details.
4. To confirm that vehicle emissions are calculated correctly based on commutes.
5. To test the functionality of the vehicle chart with current emissions.
6. To simulate the end of the month and reward points based on emissions reduction.

#### Test Scenarios and Test Cases

##### Test Scenario 1: User Registration (✅)
- **Test Case 1.1:** Verify that a new user can be registered successfully.
  - **Steps:**
    1. Access the system.
    2. Navigate to the user registration page.
    3. Enter unique user details (e.g., username, email, password).
    4. Click the "Register" button.
  - **Expected Result:** The system should save the user data, and a success message should be displayed.

##### Test Scenario 2: Vehicle Registration (✅)
- **Test Case 2.1:** Verify that a new vehicle can be registered successfully.
  - **Steps:**
    1. Access the system.
    2. Navigate to the vehicle registration page.
    3. Enter unique vehicle details (e.g., vehicle name, license plate).
    4. Click the "Register Vehicle" button.
  - **Expected Result:** The system should save the vehicle data, and a success message should be displayed.

##### Test Scenario 3: Commute Addition (✅)
- **Test Case 3.1:** Add a new commute.
  - **Steps:**
    1. Access the system.
    2. Navigate to the commute addition page.
    3. Provide commute details (e.g., origin, destination, distance).
    4. Click the "Add Commute" button.
  - **Expected Result:** The system should add the commute details, and a success message should be displayed.

##### Test Scenario 4: Emissions Calculation (✅)
- **Test Case 4.1:** Verify that `MaxEmission` is calculated correctly based on commutes.
  - **Steps:**
    1. Access the system.
    2. Register a vehicle.
    3. Add commutes that contribute to `MaxEmission`.
  - **Expected Result:** The `MaxEmission` for the vehicle should be calculated accurately based on the added commutes.

- **Test Case 4.2:** Verify that `CurrentEmission` is calculated correctly based on commutes.
  - **Steps:**
    1. Access the system.
    2. Register a vehicle.
    3. Add commutes that contribute to `CurrentEmission`.
  - **Expected Result:** The `CurrentEmission` for the vehicle should be calculated accurately based on the added commutes.

##### Test Scenario 5: Vehicle Chart (✅)
- **Test Case 5.1:** Check that the vehicle chart displays current emissions next to max emissions.
  - **Steps:**
    1. Access the system.
    2. Navigate to a vehicle chart page.
    3. Verify that the chart displays both current emissions and max emissions.
  - **Expected Result:** The chart should show current emissions alongside max emissions.

##### Test Scenario 6: End of the Month Simulation (✅)
- **Test Case 6.1:** Simulate the end of the month and reward points for emissions reduction.
  - **Steps:**
    1. Access the system.
    2. Navigate to the end-of-the-month simulation page.
    3. Initiate the simulation.
  - **Expected Result:** The system should calculate points based on emissions reduction and add them to the user's account.

#### Conclusion 📝
This extended test plan covers the additional features of the assignment, including the vehicle chart displaying current emissions, and the end-of-the-month simulation that rewards users based on emissions reduction. Executing these test cases will help ensure the functionality and reliability of these new features in the system.

## License

This project is licensed under the [MIT License](LICENSE.md).

## Acknowledgments

- The Zuyd on Wheels team thanks all contributors for their dedication to sustainability and greener commuting!

---

**Let's make Zuyd University's commute eco-friendly! 🌍🚲**
