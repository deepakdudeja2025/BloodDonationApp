

ALTER PROCEDURE [usp_BloodGroup]
@QueryType    Tinyint,
@BloodGroupId     Int = NUll, 
@BloodGroup nvarchar(100) = NUll,
@IsActive Int=null
----------------------
-- EXEC usp_BloodGroup 3,1,'O+',1
-- EXEC usp_BloodGroup 1
-- EXEC usp_BloodGroup 4,1

AS
BEGIN
--GET ALL LIST OF BLOOD GROUP
IF(@QueryType=1)
SELECT BloodGroupID, BloodGroup, IsActive FROM donar..LOOKUPBLOODGROUP
--GET BLOODGROUP BY ID
IF(@QueryType=2)
SELECT BloodGroupID, BloodGroup, IsActive FROM donar..LOOKUPBLOODGROUP WHERE BloodGroupID=@BloodGroupId

--ADD UPDATE BLOOD GROUP
IF(@QueryType=3)
BEGIN
MERGE donar..LOOKUPBLOODGROUP AS BLDGP
USING (SELECT @BloodGroupId) AS S(BLOODGROUPID) ON BLDGP.BLOODGROUPID=S.BLOODGROUPID
WHEN MATCHED THEN
UPDATE SET BLOODGROUP=@BloodGroup
WHEN NOT MATCHED THEN
INSERT(Bloodgroup, IsActive) values(@BloodGroup,@IsActive);
END
-- DELETE BLOOD GROUP
IF(@QueryType=4)
BEGIN
SELECT * FROM donar..lookupBloodGroup
UPDATE donar..lookupBloodGroup SET IsActive=0 WHERE BloodGroupID=@BloodGroupId
END


	
END




