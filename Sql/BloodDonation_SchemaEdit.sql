
----------------------------------------------------------------------------------------
CREATE TABLE lookupDonarType
(
DonarTypeID INT IDENTITY(1,1) NOT NULL,
DonarType VARCHAR(50) NOT NULL,
IsActive BIT NOT NULL
)
ALTER TABLE lookupDonarType ADD CONSTRAINT [pk_lookupDonarType_DonarTypeID] PRIMARY KEY CLUSTERED
(
DonarTypeID ASC
) 
----------------------------------------------------------------------------------------
CREATE TABLE lookupBloodGroup
(
BloodGroupID INT IDENTITY(1,1) NOT NULL,
BloodGroup VARCHAR(50) NOT NULL,
IsActive BIt NOT NULL
)
ALTER TABLE lookupBloodGroup ADD CONSTRAINT [pk_lookupBloodGroup_BloodGroupID] PRIMARY KEY CLUSTERED
(
BloodGroupID ASC
)
----------------------------------------------------------------------------------------------
CREATE TABLE lookupDonationType
(
DonationTypeID INT IDENTITY(1,1) NOT NULL,
DonationType VARCHAR(50) NOT NULL,
IsActive BIT NOT NULL
)
ALTER TABLE lookupDonationType ADD CONSTRAINT [pk_lookupDonationType_DonationTypeID] PRIMARY KEY CLUSTERED
(
DonationTypeID ASC
)
------------------------------------------------------------------------------------------
CREATE TABLE [USER]
(
UserID INT IDENTITY(1,1) NOT NULL,
LoginID VARCHAR(100) NOT NULL,
Name VARCHAR(300) NOT NULL,
EmailID VARCHAR(100) NULL,
[Password] VARCHAR(500) NULL,
CreatedById INT NULL,
CreatedDate Date NOT NULL,
LastModifiedById INT NULL,
LastModifiedDate Date NOT NULL
)
ALTER TABLE [USER] ADD CONSTRAINT [pk_user_UserID] PRIMARY KEY CLUSTERED
(
UserID ASC
)
ALTER TABLE [USER] ADD CONSTRAINT [df_user_CreatedDate] DEFAULT(GETDATE()) FOR CreatedDate

ALTER TABLE [USER] ADD CONSTRAINT [df_user_LastModifiedDate] DEFAULT(GETDATE()) FOR LastModifiedDate
------------------------------------------------------------------------------------------------------
CREATE TABLE [Donar]
(
DonarID INT IDENTITY(1,1) NOT NULL,
UserID INT,
DonarName VARCHAR(100),
Age INT,
DateOfBirth DATE,
Gender INT,
City INT,
District INT,
[State] INT,
Country INT,
Location VARCHAR(500),
Pincode INT,
Langitute FLOAT,
Latitute FLOAT,
DonarType INT,
BloodGroup INT,
DonationType INT,
EmailID Varchar(100),
Mobile INT,
AlternatePhone INT,
Profile VARCHAR(500),
CreatedById INT NULL,
CreatedDate Date NOT NULL,
LastModifiedById INT NULL,
LastModifiedDate Date NOT NULL
)
ALTER TABLE [Donar] ADD CONSTRAINT [pk_Donar_DonarID] PRIMARY KEY CLUSTERED
(
DonarID ASC
)
ALTER TABLE [Donar] ADD CONSTRAINT [df_donar_CreatedDate] DEFAULT(GETDATE()) FOR CreatedDate
ALTER TABLE [Donar] ADD CONSTRAINT [df_donar_LastModifiedDate] DEFAULT(GETDATE()) FOR LastModifiedDate

