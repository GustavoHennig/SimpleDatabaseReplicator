# Simple Database Replicator


This is a very simple database data synchronizer, it loads a bunch of rows from source and destination, compares, and insert or update in the destination what is different.

This project was created in 2006 to resolve a problem of database benchmarking, then it was abandoned. Now I'm resurrecting the project and fixing the very ugly code 12 years old.

The replication purpose:
 - It is a one-way data synchronizer;
 - Database agnostic, should work with any one, with some adjustments (well tested with SqlServer, Firebird, SqLite, MySql and Postgres);
 - Speed: it uses very little from the drivers, all is done by simple queries;
 
Known issues:
 - Delete was not implemented
 - Schema must be identical
 - Not testes with all databases scenarios
 - Blob type not supported
 - Limited UI usability – implemented the minimum to work
 - The internationalization was abandoned
 - It's not using parameters for the queries, it causes problems according to the database collation and culture settings
 - Sequences updates are not working properly 

Originally this program had a simple Schema migration function, but it was removed, for DDL and Schema migration, there are a lot of good programs, like this one: 
  http://fishcodelib.com/DBMigration.htm

This code was created in 2006, using .Net Framework 2.0, now it was migrated to .Net 4.5 some parts of the code still could be simpler with some refactoring.
Please, fell free to contribute with Pull Requests

Gustavo Augusto Hennig
GH Software
https://www.plagius.com/en
