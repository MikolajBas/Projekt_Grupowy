CREATE DATABASE IF NOT EXISTS pgdb;

USE pgdb;

DROP TABLE IF EXISTS `event_logs`;
DROP TABLE IF EXISTS `notifications`;
DROP TABLE IF EXISTS `notification_configurations`;
DROP TABLE IF EXISTS `data_properties`;
DROP TABLE IF EXISTS `data_property_configurations`;
DROP TABLE IF EXISTS `sites_data`;
DROP TABLE IF EXISTS `event_configuration_properties`;
DROP TABLE IF EXISTS `event_configurations`;
DROP TABLE IF EXISTS `users`;

CREATE TABLE users(
   id INT NOT NULL AUTO_INCREMENT,
   login VARCHAR(32) NOT NULL,
   password VARCHAR(128) NOT NULL,
   email VARCHAR(128) NOT NULL,
   name VARCHAR(32) NOT NULL,
   surname VARCHAR(128) NOT NULL,
   url VARCHAR(128) NOT NULL,
   guid VARCHAR(128) NOT NULL,
   account_type INT NOT NULL,
   PRIMARY KEY ( id )
);

CREATE TABLE sites_data(
   id INT NOT NULL AUTO_INCREMENT,
   ip VARCHAR(32) NOT NULL,
   url VARCHAR(128) NOT NULL,
   browser VARCHAR(128),
   system VARCHAR(32),
   screen_resolution VARCHAR(128),
   agent VARCHAR(32),
   product_name VARCHAR(64),
   product_id INT,
   user_id INT NOT NULL,
   category VARCHAR(128) NOT NULL,
   visit_date DATETIME,
   FOREIGN KEY (user_id) REFERENCES users(id),
   PRIMARY KEY ( id )
);

CREATE TABLE data_property_configurations(
   id INT NOT NULL AUTO_INCREMENT,
   name VARCHAR(32) NOT NULL,
   type_id INT NOT NULL,
   user_id INT NOT NULL,
   FOREIGN KEY (user_id) REFERENCES users(id),
   PRIMARY KEY ( id )
);

CREATE TABLE data_properties(
   id INT NOT NULL AUTO_INCREMENT,
   property_value VARCHAR(32) NOT NULL,
   property_id INT NOT NULL,
   data_id INT NOT NULL,
   FOREIGN KEY (data_id) REFERENCES sites_data(id),
   PRIMARY KEY ( id )
);

CREATE TABLE event_configurations(
   id INT NOT NULL AUTO_INCREMENT,
   property_value VARCHAR(32) NOT NULL,
   operator VARCHAR(32) NOT NULL,
   property_operator VARCHAR(32) NOT NULL,
   result_value INT NOT NULL,
   event_function VARCHAR(32),
   period INT NOT NULL,
   property_id INT NOT NULL,
   template VARCHAR(512),
   template_properties VARCHAR(512),
   user_id INT NOT NULL,
   category_id INT NOT NULL,
   category VARCHAR(128) NOT NULL,
   FOREIGN KEY (user_id) REFERENCES users(id),
   PRIMARY KEY ( id )
);

CREATE TABLE event_configuration_properties(
   id INT NOT NULL AUTO_INCREMENT,
   property_id INT NOT NULL,
   event_configuration_id INT NOT NULL,
   position INT NOT NULL,
   FOREIGN KEY (event_configuration_id) REFERENCES event_configurations(id),
   PRIMARY KEY ( id )
);

CREATE TABLE event_logs(
   id INT NOT NULL AUTO_INCREMENT,
   ip VARCHAR(32) NOT NULL,
   user_id INT NOT NULL,
   event_configuration_id INT NOT NULL,
   event_date DATETIME NOT NULL,
   FOREIGN KEY (user_id) REFERENCES users(id),
   FOREIGN KEY (event_configuration_id) REFERENCES event_configurations(id),
   PRIMARY KEY ( id )
);

CREATE TABLE notification_configurations(
   id INT NOT NULL AUTO_INCREMENT,
   property_id INT NOT NULL,
   property_operator_id INT NOT NULL,
   property_value VARCHAR(32) NOT NULL,
   operator_id VARCHAR(32) NOT NULL,
   result_value VARCHAR(32) NOT NULL,
   function_id VARCHAR(32),
   period INT NOT NULL,
   message VARCHAR(64),
   user_id INT NOT NULL,
   category VARCHAR(128) NOT NULL,
   FOREIGN KEY (user_id) REFERENCES users(id),
   FOREIGN KEY (property_id) REFERENCES data_properties(id),
   PRIMARY KEY ( id )
);

CREATE TABLE notifications(
   id INT NOT NULL AUTO_INCREMENT,
   message VARCHAR(64) NOT NULL,
   user_id INT NOT NULL,
   notification_configuration_id INT NOT NULL,
   notification_date DATETIME NOT NULL,
   FOREIGN KEY (user_id) REFERENCES users(id),
   FOREIGN KEY (notification_configuration_id) REFERENCES notification_configurations(id),
   PRIMARY KEY ( id )
);