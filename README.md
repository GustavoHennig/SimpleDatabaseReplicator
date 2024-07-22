# Simple Database Replicator

This is a very simple database data synchronizer. It loads a bunch of rows from the source and destination, compares them, and inserts or updates the differences into the destination.

This project was created in 2006 to resolve a database benchmarking problem, then it was abandoned. Now, I am resurrecting the project and fixing the old, ugly code.

> [!IMPORTANT]
> Since this is a very old project, it was created by an inexperienced developer, so don't expect good code quality. I am trying to fix it, but it is a slow process.

## Replication Purpose
 - It is a one-way data synchronizer.
 - Database agnostic: it should work with any database with some adjustments (well tested with SQL Server, Firebird, SQLite, MySQL, and Postgres).
 - Speed: it uses very little from the drivers; everything is done by simple queries.

## Known Issues / TODO
- [ ] Consider using an existing library for queries, like https://github.com/sqlkata/querybuilder.
- [ ] Delete is not implemented.  
- [ ] Use internal row identity to optimize synchronization (like Postgres xmin).  
- [ ] Schema must be identical.  
- [ ] Not tested with all database scenarios.  
- [ ] Blob type not supported.  
- [ ] Limited UI usability – implemented the minimum to work.  
- [ ] The internationalization was abandoned.  
- [ ] It's not using parameters for the queries, which causes problems according to the database collation and culture settings.  
- [ ] Sequence updates are not working properly.  
- [ ] Improve connection string configuration screen  
- [ ] Remove hard-coded database settings  
- [ ] Simulate synchronization (with changes preview)
- [ ] Export SQL queries to synchronize manually



Originally, this program had a simple schema migration function, but it was removed. For DDL and schema migration, there are many good programs available, such as this one: 
  http://fishcodelib.com/DBMigration.htm

Since this code is old, created in 2006 using .NET Framework 2.0 (now migrated to ~~.NET 4.5~~ .NET 8), some parts of the code could be simpler with some refactoring.

Please, feel free to contribute with Pull Requests ;)

## Screenshots

![alt text](https://raw.githubusercontent.com/GustavoHennig/SimpleDatabaseReplicator/master/Screenshots/main-stopped.png "Main screen stopped")
![alt text](https://raw.githubusercontent.com/GustavoHennig/SimpleDatabaseReplicator/master/Screenshots/main-running.png "Main screen running")
![alt text](https://raw.githubusercontent.com/GustavoHennig/SimpleDatabaseReplicator/master/Screenshots/configuring-connection.png "Configuring connection strings")
![alt text](https://raw.githubusercontent.com/GustavoHennig/SimpleDatabaseReplicator/master/Screenshots/selecting-tables.png "Selecting tables")

Gustavo Augusto Hennig

GH Software - [Plagius - Plagiarism Checker](https://www.plagius.com/en)