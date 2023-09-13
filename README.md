# Zuyd on Wheels - Sustainable Transportation Project

![Zuyd on Wheels Logo](https://avatars.slack-edge.com/2023-09-13/5890460198580_38fa7376891430aa5949_132.png)

Welcome to the Zuyd on Wheels project! This project aims to promote sustainable transportation options for Zuyd University students and staff, reducing traffic congestion and carbon emissions.

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

4. **Build and Run**:
   - Open the project in Visual Studio or Visual Studio Code.
   - Build and run the application.

5. **Database Migrations**:
   - Use Entity Framework migrations to create the database schema.
   ```sh
   dotnet ef database update
   ```

6. **Explore the Application**:
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
