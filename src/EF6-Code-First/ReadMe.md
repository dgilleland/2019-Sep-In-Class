# Entity Framework - Data Modeling

## Background

Entity Framework 6 (*EF6*) offers two basic approaches to creating a model that maps to the structure of a database. In earlier versions of Entity Framework, much emphasis was placed on using the EF Designer to model the database structure visually. The model was stored as an XML file (`.edmx`), and you could either start with "drawing" the model (and have it generate the database) or you could take an existing database and "reverse-engineer" it to generate the EDMX model. This approach is still supported in EF6.

While the visual nature of this approach appealed to some developers, it has the drawback of not always working well for teams using a version control system. Even minor changes to the visual model (such as "moving" an entity a few pixels on the diagram) would make changes to the underlying XML, and it would be easy to get merge conflicts in version control; these particular merge conflicts could be tricky to resolve.

Code-First is the newer (and oft recommended_ approach to modeling the database with Entity Framework. You can use this approach with or without a pre-existing database. Typically, when developers refer to using the code-first approach, they are working without a pre-existing database. In this approach, the "design" of the database is produced by creating an object model in code and then letting Entity Framework generate the database automatically. The code-first approach is often used in conjunction with Database Migrations, a set of tooling introduced to EF to help with the evolution of database designs as the needs of the system changes.

## Demos and Practice

### Blogs and Posts

Follow the instructions in the [Code First to a New Database](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database) article, which walks through generating a database using the code-first approach. It also covers much of the basics of Navigational Properties.

### Fairview Mall

Fairview Mall is an example of using a code-first model to generate a database. The database is then used as the basis for creating a Database Project in Visual Studio.

### Tables

- **Bays**
  - BayID : char(1) - A-R
  - Area
  - ReservedUse
- **BayRentals**
  - BayID
  - RentalID
  - Quadrants (enum)
- **Rentals**
  - RentalID
  - CompanyName
  - CompanyUrl
  - PhoneNumber
  - ContactName
  - RentalTerm (months)
  - MonthlyRentalRate
  - StartingDate
  - ClosingDate
