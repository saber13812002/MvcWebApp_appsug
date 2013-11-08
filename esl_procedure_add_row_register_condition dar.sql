alter PROCEDURE esl_set_userid_by_deviceid
	-- Add the parameters for the stored procedure here
	@esl_user_id nvarchar(30) = "saber",
	@esl_device_id nvarchar(64) = "000000000000000000",
	@esl_mobile_number nvarchar(11) = "09306181311"
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SELECT * FROM [appsugg_db].[dbo].['worksheet-name$']
	-- where name=@app_full_name

BEGIN
   INSERT INTO esl_tbl_users_devices (idUser,idDevice,mobilenumber,modifyDateTime)
	VALUES (@esl_user_id,@esl_device_id,@esl_mobile_number, GETDATE());

END
END
GO


create TABLE esl_tbl_users_devices
(
id_user_dev int IDENTITY PRIMARY KEY ,
idUser varchar(30),
idDevice varchar(64),
modifyDateTime datetime2,
mobilenumber varchar(11)
); 

ALTER TABLE esl_tbl_users_devices DROP COLUMN id_user_dev 
ALTER TABLE esl_tbl_users_devices ADD id_user_dev int IDENTITY PRIMARY KEY 
ALTER TABLE esl_tbl_users_devices ADD mobilenumber varchar(11)