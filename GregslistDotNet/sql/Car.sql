-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE
    IF NOT EXISTS cars(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        make VARCHAR(255) NOT NULL,
        model VARCHAR(255) NOT NULL,
        year int NOT NULL CHECK (year >= 1886),
        price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
        description VARCHAR(255),
        imgUrl VARCHAR(255) DEFAULT "https://www.autolist.com/assets/listings/default_car.jpg"
    );


INSERT INTO cars(make, model, year, price, description, imgUrl)
VALUES ("Nissan", "Skyline GTR R34", 2002, 300000, "Best Jdm car to exist", "https://dealeraccelerate-all.s3.amazonaws.com/international/marketing_assets/178/BLUE_R34_GTR-6.jpg");

SELECT * FROM cars;

SELECT * FROM cars WHERE id = 1;

UPDATE cars SET description = "Bestest JDM Car to Exist!" WHERE Id = 1;

UPDATE cars SET description = "BESTEST JDM CAR TO EXIST, NO CAP!" WHERE id = 1;