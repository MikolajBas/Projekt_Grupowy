CREATE DATABASE IF NOT EXISTS pg;

USE pg;

DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `visitors`;
DROP TABLE IF EXISTS `tags`;
DROP TABLE IF EXISTS `locations`;
DROP TABLE IF EXISTS `sites`;
DROP TABLE IF EXISTS `visits`;
DROP TABLE IF EXISTS `sites_tags`;
DROP TABLE IF EXISTS `sites_visits`;

CREATE TABLE users(
   id INT NOT NULL AUTO_INCREMENT,
   login VARCHAR(32) NOT NULL,
   password VARCHAR(128) NOT NULL,
   email VARCHAR(128) NOT NULL,
   name VARCHAR(32) NOT NULL,
   surname VARCHAR(128) NOT NULL,
   account_type INT NOT NULL,
   PRIMARY KEY ( id )
);

CREATE TABLE visitors(
   ip_address VARCHAR(32) NOT NULL,
   PRIMARY KEY ( ip_address )
);

CREATE TABLE tags(
   id INT NOT NULL AUTO_INCREMENT,
   tagname VARCHAR(32) NOT NULL,
   PRIMARY KEY ( id )
);

CREATE TABLE locations(
   id INT NOT NULL AUTO_INCREMENT,
   country VARCHAR(32),
   city VARCHAR(32),
   coords VARCHAR(100) NOT NULL,
   PRIMARY KEY ( id )
);

CREATE TABLE sites(
   id INT NOT NULL AUTO_INCREMENT,
   full_name VARCHAR(100) NOT NULL,
   domain_name VARCHAR(64) NOT NULL,
   submission_date DATE,
   PRIMARY KEY ( id )
);

CREATE TABLE visits(
   id INT NOT NULL AUTO_INCREMENT,
   duration LONG NOT NULL,
   visit_date DATE NOT NULL,
   location INT NOT NULL,
   visitor VARCHAR(32) NOT NULL,
   FOREIGN KEY (visitor) REFERENCES visitors(ip_address),
   FOREIGN KEY (location) REFERENCES locations(id),
   PRIMARY KEY ( id )
);

CREATE TABLE sites_visits(
   id INT NOT NULL AUTO_INCREMENT,
   site INT NOT NULL,
   visit INT NOT NULL,
   FOREIGN KEY (site) REFERENCES sites(id),
   FOREIGN KEY (visit) REFERENCES visits(id),
   PRIMARY KEY ( id )
);

CREATE TABLE sites_tags(
   id INT NOT NULL AUTO_INCREMENT,
   site INT NOT NULL,
   tag INT NOT NULL,
   FOREIGN KEY (site) REFERENCES sites(id),
   FOREIGN KEY (tag) REFERENCES tags(id),
   PRIMARY KEY ( id )
);


