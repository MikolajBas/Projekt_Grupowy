
INSERT INTO users (login, password, email, name, surname, url, guid, account_type)
VALUES ('mietek','1a1dc91c907325c69271ddf0c944bc72', 'takimail@gmail.com','Krzysztof','Ibisz','www.mamfajnewlosy.pl', '27708050-44c2-4663-8c7b-a912ed852448', 1); 
INSERT INTO users (login, password, email, name, surname, url, guid, account_type)
VALUES ('zdzichu','1a1dc91c907325c69271ddf0c944bc72', 'innnymail@gmail.com','Rafał','Sosnowski','www.drzewka.pl', '342f373d-d6f4-42f7-b1ab-7d79f1f2c4f5', 1); 
INSERT INTO users (login, password, email, name, surname, url, guid, account_type)
VALUES ('lubieplacki','1a1dc91c907325c69271ddf0c944bc72', 'zdzichu@gmail.com','Michał','Ostrowski','www.sprzedajajka.pl', 'fced6f6d-9441-4673-8d79-409f78402760', 2); 


INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.111','products/discounts','firefox','android','1000X800','mobile', 'sox', 221, 1, 'cheap','2016-12-10 11:30:45'); 
INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.144','products/discounts','opera','linux','1000X800','desktop', 'sandals', 312, 1, 'cheap','2016-12-24 19:30:45'); 
INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.133','products/elegant','firefox','ios','1000X800','desktop', 'tie', 2, 1, 'exclusive','2016-05-11 12:30:45'); 
INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.122','products/sport','chrome','osx','1000X800','mobile', 'tshirt', 333, 1, 'sport','2016-07-10 18:30:45'); 
INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.011','/books','chrome','android','1000X800','mobile', 'Harry Mopper', 32, 2, 'fantasy','2016-12-11 21:30:45'); 
INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.121','shop/rtv','safari','windows','1000X800','desktop', 'Asus', 3, 43, 'computers','2016-06-10 11:30:45'); 
INSERT INTO sites_data (ip, url, browser, system, screen_resolution, agent, product_name, product_id, user_id, category, visit_date)
VALUES ('198.123.88.131','shop/other','firefox','windows','1000X800','mobile', 'some bullshit', 3765, 3, 'gadgets','2016-11-10 21:30:45'); 

INSERT INTO data_property_configurations (name, type_id, user_id)
VALUES ('Price',2,1); 
INSERT INTO data_property_configurations (name, type_id, user_id)
VALUES ('Price',2,2); 
INSERT INTO data_property_configurations (name, type_id, user_id)
VALUES ('Size',1,2); 
INSERT INTO data_property_configurations (name, type_id, user_id)
VALUES ('Mark',1,2); 
INSERT INTO data_property_configurations (name, type_id, user_id)
VALUES ('Price',2,3); 
INSERT INTO data_property_configurations (name, type_id, user_id)
VALUES ('Country',1,3); 


INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('12.36', 1, 1); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('44.88', 1, 2); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('112.22', 1, 3); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('33.56', 1, 4); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('11.99', 2, 5); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('XXL', 3, 5); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('Adidas', 4, 5); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('1110', 5, 6); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('USA', 6, 7); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('11', 5, 6); 
INSERT INTO data_properties (property_value, property_id, data_id)
VALUES ('China', 6, 7); 
 
