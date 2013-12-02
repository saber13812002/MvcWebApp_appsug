alter PROCEDURE irib_get_report_by_projs_and_id
	-- Add the parameters for the stored procedure here
	@irib_proj_id int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SELECT * FROM [appsugg_db].[dbo].['worksheet-name$']
	-- where name=@app_full_name

SELECT * FROM irib_report_projs
                         WHERE id_proj = @irib_proj_id
                 
END
GO
drop TABLE irib_report_projs

create TABLE irib_report_projs
(
id_proj int IDENTITY PRIMARY KEY ,
name nvarchar(30),
[desc] nvarchar(64),
modifyDateTime nvarchar(10),
); 

ALTER TABLE irib_report_projs DROP COLUMN modifyDateTime 
-- ALTER TABLE esl_tbl_users_devices ADD id_user_dev int IDENTITY PRIMARY KEY 
ALTER TABLE irib_report_projs ADD modifyDateTime varchar(8)


alter PROCEDURE irib_set_new_proj
	-- Add the parameters for the stored procedure here
	@irib_proj_name nvarchar(30) = "android default proj name",
	@irib_proj_desc nvarchar(64) = "this is a blank description",
	@irib_proj_date nvarchar(11) = "13920101"
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SELECT * FROM [appsugg_db].[dbo].['worksheet-name$']
	-- where name=@app_full_name

BEGIN
   INSERT INTO irib_report_projs (name,[desc],modifyDateTime)
	VALUES (@irib_proj_name,@irib_proj_desc, @irib_proj_date);
	-- VALUES (@irib_proj_name,@irib_proj_desc, GETDATE());

END
END
GO


select * from irib_report_projs