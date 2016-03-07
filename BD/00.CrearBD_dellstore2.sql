CREATE DATABASE dellstore2
  WITH OWNER = postgres
       TABLESPACE = pg_default
       CONNECTION LIMIT = -1;

 CREATE ROLE dellstore2  
 WITH LOGIN PASSWORD 'dellstore2'
  SUPERUSER INHERIT CREATEDB CREATEROLE REPLICATION;
  
  
  ' Cargar los datos desde consola 
 ' psql -U dellstore2 -d dellstore2 -f normal.sql -h localhost