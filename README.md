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

## Development Steps 📝

Building an ASP.NET Core MVC application involves several key steps:

1. **Setup Development Environment**:
   - Install Visual Studio or Visual Studio Code.
   - Ensure you have the .NET SDK installed.

2. **Create a New ASP.NET MVC Project**:
   - Choose the "MVC" template.

3. **Define Your Models**:
   - Create C# classes to represent your data entities.

4. **Create a DbContext**:
   - Define an Entity Framework DbContext class for database connectivity.

5. **Configure Dependency Injection**:
   - Set up dependency injection in `Startup.cs` to inject services and repositories.

6. **Create Controllers**:
   - Handle HTTP requests by creating controllers and actions.

7. **Create Views**:
   - Develop Razor views (.cshtml files) for rendering HTML templates.

8. **Implement Routing**:
   - Configure URL routing in `Startup.cs` to map URLs to controller actions.

9. **Implement CRUD Operations**:
   - Create methods in controllers for Create, Read, Update, and Delete (CRUD) operations.

10. **Apply Validation**:
    - Add data validation to models using annotations or custom logic.

11. **Implement Authentication and Authorization** (if needed):
    - Configure user authentication and authorization.

12. **Testing**:
    - Write unit tests for controllers and services using testing frameworks like xUnit or NUnit.

13. **Logging**:
    - Configure logging for debugging and monitoring.

14. **Styling and Client-Side Scripts**:
    - Enhance UI with CSS styles and client-side scripts.

15. **Deployment**:
    - Prepare for deployment to a web server or cloud platform.

16. **Testing in a Production-Like Environment**:
    - Ensure your app functions correctly in a staging environment.

17. **Documentation**:
    - Create documentation including installation instructions and usage guides.

18. **Optimization**:
    - Optimize for performance and scalability.

19. **Security**:
    - Implement security best practices.

20. **Monitoring and Error Handling**:
    - Set up monitoring and error tracking.

21. **Launch**:
    - Deploy your app to production.

22. **Maintenance**:
    - Regularly maintain and update your app.

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

Here's an overview of the project's folder structure:

- `Controllers`: Contains MVC controller classes.
- `Views`: Organized by controller actions for rendering HTML views.
- `Models`: Entity classes and data models.
- `Data`: Entity Framework DbContext and migrations.
- `Services`: Business logic and services.
- `wwwroot`: Static files like CSS, JavaScript, and images.

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
![Screenshot 2023-11-03 at 16 18 45](https://github.com/nahnova/Sustatron/assets/56248103/a11d8c4d-ece8-431c-a10a-9a9c63659e34)


2. **Use Case Diagram**: Visualizes the use cases per actor.
![Screenshot 2023-11-06 at 18 50 36](https://github.com/nahnova/Sustatron/assets/56248103/75f70124-f2aa-4d42-a0ec-12ef238d306a)


3. **Entity Class Diagrams**: Visualize the relationships between entities in your code, including classes, properties, and methods.
![image 1](https://github.com/nahnova/Sustatron/assets/56248103/6932e21f-d434-4877-9933-98eb839132da)

4. **Sequence Diagram**: Visualize the application flow and their related models.
![image 3](https://github.com/nahnova/Sustatron/assets/56248103/44b4a338-d328-4361-b45c-176f502aae13)

## Testing and Contributions

We welcome contributions to improve Zuyd on Wheels! Please follow these guidelines:

- Write unit tests for new features and ensure all tests pass.
- Adhere to the coding standards and conventions.

## License

This project is licensed under the [MIT License](LICENSE.md).

## Acknowledgments

- The Zuyd on Wheels team thanks all contributors for their dedication to sustainability and greener commuting!

---

**Let's make Zuyd University's commute eco-friendly! 🌍🚲**
