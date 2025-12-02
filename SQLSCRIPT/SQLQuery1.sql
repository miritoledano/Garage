-- יצירת בסיס הנתונים
CREATE DATABASE GarageDb;
GO

-- שימוש בבסיס הנתונים שנוצר
USE GarageDb;
GO

-- יצירת הטבלה Garage
CREATE TABLE Garage
(
    _id INT IDENTITY(1,1) PRIMARY KEY,
    mispar_mosah INT NOT NULL,
    shem_mosah NVARCHAR(255) NOT NULL,
    cod_sug_mosah INT NOT NULL,
    sug_mosah NVARCHAR(255) NOT NULL,
    ktovet NVARCHAR(255),
    yishuv NVARCHAR(255),
    telephone NVARCHAR(50),
    mikud INT,
    cod_miktzoa INT,
    miktzoa NVARCHAR(255),
    menahel_miktzoa NVARCHAR(255),
    rasham_havarot BIGINT,
    TESTIME NVARCHAR(255)
);
GO
