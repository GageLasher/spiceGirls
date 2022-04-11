CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  accountId varchar(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE recipes;
CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL,
  title varchar(255),
  subTitle varchar(255),
  category VARCHAR(255),
  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  picture TEXT
) default charset utf8 COMMENT '';
ALTER TABLE
  recipes
MODIFY
  COLUMN picture TEXT;
CREATE TABLE IF NOT EXISTS ingredients(
    id INT NOT NULL primary key AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255),
    quantity varchar(255),
    recipeId INT NOT NULL,
    FOREIGN KEY (recipeId) REFERENCES recipes(id)
  ) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS steps(
    id INT NOT NULL primary key AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    stepOrder INT,
    body varchar(255),
    recipeId INT NOT NULL,
    FOREIGN KEY (recipeId) REFERENCES recipes(id)
  ) default charset utf8 COMMENT '';
INSERT INTO
  steps (`stepOrder`, body, `recipeId`)
VALUES
  (3, "put in over and done", 4);